using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NemucodCryptedDecrypter
{
    public partial class Form1 : Form
    {
        // Background workers
        static BackgroundWorker generateKeyWorker = new BackgroundWorker(),
            decryptWorker = new BackgroundWorker();

        // Counters
        static int attempts = 0, decrypted = 0, skipped = 0;

        // Loaded key
        static int[] loadedKey;

        // Extension supported
        static string ext = ".crypted";

        // Files
        static string encryptedFileName = null, cleanFileName = null;

        // Directory to decrypt
        static string directory;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display version in title
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("NemucodCryptedDecrypter v{0}", version);
        }
        
        static public byte[] XOR_Decrypt(byte[] bytesToBeDecrypted, int[] key)
        {

            int readBytes = 0, i = 0;

            List<byte> bytesDecrypted = new List<byte>();

            // Iterate first 2048 bytes
            while(readBytes < 2048 && readBytes < bytesToBeDecrypted.Length)
            {
                int badByte = Convert.ToInt32(bytesToBeDecrypted[readBytes]);
                byte b = Convert.ToByte(key[i] ^ badByte);
                bytesDecrypted.Add(b);

                i++;
                    
                if (i > 254 || i >= key.Length)
                {
                    i = 0;
                }
                    
                readBytes++;
            }
            while(readBytes < bytesToBeDecrypted.Length)
            {
                bytesDecrypted.Add(bytesToBeDecrypted[readBytes++]);
            }

            return bytesDecrypted.ToArray();

        }
        
        private void StartKeyGeneration()
        {

            // Display attempts label
            KeyStatusLabel.Text = "Setting up...";
            KeyStatusLabel.Visible = true;

            Log("Starting key generation on " + cleanFileName);

            // Setup background worker thread
            generateKeyWorker.DoWork += GenerateKey;
            generateKeyWorker.RunWorkerCompleted += GenerateKeyRunWorkerCompleted;
            generateKeyWorker.ProgressChanged += GenerateKeyProgressChanged;
            generateKeyWorker.WorkerReportsProgress = true;
            generateKeyWorker.WorkerSupportsCancellation = true;

            generateKeyWorker.RunWorkerAsync();

        }

        private void GenerateKey(object sender, DoWorkEventArgs e)
        {

            // Key
            var keyBytes = new List<int>();

            // Load files
            byte[] cleanFile = File.ReadAllBytes(cleanFileName),
                encryptedFile = File.ReadAllBytes(encryptedFileName);

            int i = 0;

            int goodByte, badByte;

            while(i < 600)
            {

                goodByte = cleanFile[i];
                badByte = encryptedFile[i];

                keyBytes.Add(goodByte ^ badByte);

                i++;

                generateKeyWorker.ReportProgress(i / 600);
            }

            e.Result = keyBytes.ToArray();
        }

        void GenerateKeyProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            KeyStatusLabel.Text = "Generating key: " + e.ProgressPercentage + "%";
        }

        void GenerateKeyRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                KeyStatusLabel.Text = "Error: " + e.Error.Message;
                Log("Error: " + e.Error.ToString());
            }
            else if (!e.Cancelled)
            {
                // Verify key
                int[] keyFound = (int[])e.Result;
                String builtKey = BuildKey(keyFound);

                if (builtKey != null && builtKey.Length > 0 && builtKey.Distinct().Count() > 1)
                {
                    KeyStatusLabel.Text = "Key Found!";
                    keyTextbox.Text = builtKey;
                    Log("Key Found: " + keyTextbox.Text);
                }
                else
                {
                    KeyStatusLabel.Text = "Error with Key";
                    Log("Invalid Key: " + keyFound);
                }
            }
            else
            {
                Log("Key generation stopped");
            }
            GenerateKeyButton.Text = "Generate Key";
            CleanFileButton.Enabled = EncryptedFileButton.Enabled = true;
        }

        static public string BuildKey(int[] keyFound)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while (i < 255)
            {
                if(keyFound[i] == keyFound[i + 255])
                {
                    sb.Append(keyFound[i].ToString("X"));
                }
                i++;
            }
            return sb.ToString();
        }

        private void StartDecrypt()
        {
            // Reset counters
            decrypted = 0;
            skipped = 0;

            // Start background worker
            decryptWorker.DoWork += Decrypt;
            decryptWorker.ProgressChanged += DecryptProgressChanged;
            decryptWorker.RunWorkerCompleted += DecryptRunWorkerCompleted;
            decryptWorker.WorkerReportsProgress = true;

            decryptWorker.RunWorkerAsync(directory);
        }

        static private void Decrypt(object sender, DoWorkEventArgs e)
        {
            DecryptDirectory(e.Argument.ToString());
        }

        void DecryptProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            String file = e.UserState.ToString();
            String sub = file.Substring(Math.Max(0, file.Length - 55));
            if(sub.Length < file.Length)
            {
                sub = "..." + sub;
            }
            DecryptProgressLabel.Text = "Decrypted: " + sub;
            Log("Decrypted: " + file);
        }

        void DecryptRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                DecryptProgressLabel.Text = "Error: " + e.Error.Message;
                Log("Decrypt Error: " + e.Error.ToString());
            }
            else if (!e.Cancelled)
            {
                DecryptProgressLabel.Text = "Decrypted " + decrypted + " files!";
                if(skipped > 0)
                {
                    DecryptProgressLabel.Text += " Skipped" + skipped + " files.";
                }
            }
            else
            {
                DecryptProgressLabel.Text = "Decryption cancelled";
                Log("Decryption cancelled");
            }
        }

        static public bool DecryptFile(string file, int[] key)
        {
            
            byte[] bytesToBeDecrypted = File.ReadAllBytes(file);

            byte[] bytesDecrypted = XOR_Decrypt(bytesToBeDecrypted, key);
            
            if (bytesDecrypted == null)
            {
                return false;
            }

            File.WriteAllBytes(file, bytesDecrypted);
            string extension = System.IO.Path.GetExtension(file);
            string result = file.Substring(0, file.Length - extension.Length);
            System.IO.File.Move(file, result);
            
            return true;

        }

        static public void DecryptDirectory(string location)
        {

            try
            {
                string[] files = Directory.GetFiles(location);

                string[] childDirectories = Directory.GetDirectories(location);
                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i]);
                    if (extension == ext)
                    {
                        try
                        {
                            if (DecryptFile(files[i], loadedKey))
                            {
                                decrypted++;
                            }
                            else
                            {
                                skipped++;
                                Log("Skipped: " + files[i]);
                            }
                            decryptWorker.ReportProgress(0, files[i]);
                        }
                        catch (Exception e)
                        {
                            skipped++;
                            Log("Exception: [" +e.GetType().ToString()+"] "+e.Message);
                        }
                    }
                }
                for (int i = 0; i < childDirectories.Length; i++)
                {
                    DecryptDirectory(childDirectories[i]);
                }

            }
            catch (Exception e)
            {
                return;
            }

        }

        static void Log(String text)
        {

            using (StreamWriter log = new StreamWriter("log.txt", true))
            {

                log.WriteLine(text);

            }

        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            if(decryptDirectoryDialog.ShowDialog() == DialogResult.OK)
            {

                directory = decryptDirectoryDialog.SelectedPath;
                FolderSelectedLabel.Text = "Folder Selected";
                DecryptButton.Enabled = true;
            }
        }

        private void GenerateKeyButton_Click(object sender, EventArgs e)
        {
            if (!CheckLoadedFiles())
            {
                KeyStatusLabel.Text = "Please select an encrypted and clean copy of the same file";
                return;
            }

            if (!generateKeyWorker.IsBusy)
            {
                GenerateKeyButton.Text = "Pause Generation";
                EncryptedFileButton.Enabled = CleanFileButton.Enabled = false;
                StartKeyGeneration();
            }
            else
            {
                GenerateKeyButton.Text = "Generate Key";
                EncryptedFileButton.Enabled = CleanFileButton.Enabled = true;
                generateKeyWorker.CancelAsync();
            }

        }

        private void keyTextbox_TextChanged(object sender, EventArgs e)
        {

            String text = keyTextbox.Text;
            try {

                loadedKey = (from Match m in Regex.Matches(text, "..") select m.Value)
                    .Select(x => Convert.ToInt32(x, 16)).ToArray();
                    
                if (text != null && text.Length > 0)
                {
                    SelectFolderButton.Enabled = true;
                }

            }
            catch(Exception ex)
            {

            }

        }

        private void EncryptedFileButton_Click(object sender, EventArgs e)
        {

            if(encryptedFileDialog.ShowDialog() == DialogResult.OK)
            {

                encryptedFileName = encryptedFileDialog.FileName;

            }

            CheckLoadedFiles();

        }

        private void CleanFileButton_Click(object sender, EventArgs e)
        {

            if(cleanFileDialog.ShowDialog() == DialogResult.OK)
            {

                cleanFileName = cleanFileDialog.FileName;

            }

            CheckLoadedFiles();

        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (directory == null || directory == "")
            {
                FolderSelectedLabel.Text = "Please select a directory";
            }
            else if (keyTextbox.Text == null || keyTextbox.Text == "")
            {
                FolderSelectedLabel.Text = "Please enter the key";
            }
            else {
                StartDecrypt();
            }

        }

        private bool CheckLoadedFiles()
        {

            bool loaded = encryptedFileName != null && cleanFileName != null;
            
            // Toggle applicable form elements
            SelectFolderButton.Enabled = loaded;
            DecryptButton.Enabled = loaded;
            GenerateKeyButton.Enabled = loaded;

            return loaded;

        }
    }
}
