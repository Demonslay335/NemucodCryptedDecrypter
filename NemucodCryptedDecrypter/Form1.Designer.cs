namespace NemucodCryptedDecrypter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.encryptedFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cleanFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.keyTextbox = new System.Windows.Forms.TextBox();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.FolderSelectedLabel = new System.Windows.Forms.Label();
            this.KeyStatusLabel = new System.Windows.Forms.Label();
            this.GenerateKeyButton = new System.Windows.Forms.Button();
            this.EncryptedFileButton = new System.Windows.Forms.Button();
            this.CleanFileButton = new System.Windows.Forms.Button();
            this.LineLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DecryptProgressLabel = new System.Windows.Forms.Label();
            this.decryptDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encryptedFileDialog
            // 
            this.encryptedFileDialog.Filter = "Encrypted File (*.crypted)|*.crypted";
            // 
            // cleanFileDialog
            // 
            this.cleanFileDialog.Filter = "Clean File|*";
            // 
            // keyTextbox
            // 
            this.keyTextbox.Location = new System.Drawing.Point(56, 93);
            this.keyTextbox.Name = "keyTextbox";
            this.keyTextbox.Size = new System.Drawing.Size(303, 20);
            this.keyTextbox.TabIndex = 2;
            this.keyTextbox.Click += new System.EventHandler(this.keyTextbox_TextChanged);
            this.keyTextbox.TextChanged += new System.EventHandler(this.keyTextbox_TextChanged);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.AutoSize = true;
            this.InstructionsLabel.Location = new System.Drawing.Point(22, 9);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(337, 13);
            this.InstructionsLabel.TabIndex = 3;
            this.InstructionsLabel.Text = "Please select a sample encrypted file, along with its clean counterpart.";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(22, 96);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(28, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Key:";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Enabled = false;
            this.DecryptButton.Location = new System.Drawing.Point(132, 286);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(118, 34);
            this.DecryptButton.TabIndex = 5;
            this.DecryptButton.Text = "Decrypt Files";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Enabled = false;
            this.SelectFolderButton.Location = new System.Drawing.Point(132, 206);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(118, 34);
            this.SelectFolderButton.TabIndex = 6;
            this.SelectFolderButton.Text = "Select Folder";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // FolderSelectedLabel
            // 
            this.FolderSelectedLabel.AutoSize = true;
            this.FolderSelectedLabel.Location = new System.Drawing.Point(143, 255);
            this.FolderSelectedLabel.Name = "FolderSelectedLabel";
            this.FolderSelectedLabel.Size = new System.Drawing.Size(98, 13);
            this.FolderSelectedLabel.TabIndex = 7;
            this.FolderSelectedLabel.Text = "No Folder Selected";
            // 
            // KeyStatusLabel
            // 
            this.KeyStatusLabel.AutoSize = true;
            this.KeyStatusLabel.Location = new System.Drawing.Point(161, 120);
            this.KeyStatusLabel.Name = "KeyStatusLabel";
            this.KeyStatusLabel.Size = new System.Drawing.Size(58, 13);
            this.KeyStatusLabel.TabIndex = 8;
            this.KeyStatusLabel.Text = "Key Status";
            this.KeyStatusLabel.Visible = false;
            // 
            // GenerateKeyButton
            // 
            this.GenerateKeyButton.Enabled = false;
            this.GenerateKeyButton.Location = new System.Drawing.Point(132, 148);
            this.GenerateKeyButton.Name = "GenerateKeyButton";
            this.GenerateKeyButton.Size = new System.Drawing.Size(118, 34);
            this.GenerateKeyButton.TabIndex = 9;
            this.GenerateKeyButton.Text = "Generate Key";
            this.GenerateKeyButton.UseVisualStyleBackColor = true;
            this.GenerateKeyButton.Click += new System.EventHandler(this.GenerateKeyButton_Click);
            // 
            // EncryptedFileButton
            // 
            this.EncryptedFileButton.Location = new System.Drawing.Point(25, 37);
            this.EncryptedFileButton.Name = "EncryptedFileButton";
            this.EncryptedFileButton.Size = new System.Drawing.Size(118, 35);
            this.EncryptedFileButton.TabIndex = 10;
            this.EncryptedFileButton.Text = "Browse Encrypted";
            this.EncryptedFileButton.UseVisualStyleBackColor = true;
            this.EncryptedFileButton.Click += new System.EventHandler(this.EncryptedFileButton_Click);
            // 
            // CleanFileButton
            // 
            this.CleanFileButton.Location = new System.Drawing.Point(241, 38);
            this.CleanFileButton.Name = "CleanFileButton";
            this.CleanFileButton.Size = new System.Drawing.Size(118, 34);
            this.CleanFileButton.TabIndex = 11;
            this.CleanFileButton.Text = "Browse Clean";
            this.CleanFileButton.UseVisualStyleBackColor = true;
            this.CleanFileButton.Click += new System.EventHandler(this.CleanFileButton_Click);
            // 
            // LineLabel
            // 
            this.LineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LineLabel.Location = new System.Drawing.Point(12, 193);
            this.LineLabel.Name = "LineLabel";
            this.LineLabel.Size = new System.Drawing.Size(356, 2);
            this.LineLabel.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(380, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "StatusStrip";
            // 
            // DecryptProgressLabel
            // 
            this.DecryptProgressLabel.AutoSize = true;
            this.DecryptProgressLabel.Location = new System.Drawing.Point(3, 350);
            this.DecryptProgressLabel.Name = "DecryptProgressLabel";
            this.DecryptProgressLabel.Size = new System.Drawing.Size(51, 13);
            this.DecryptProgressLabel.TabIndex = 14;
            this.DecryptProgressLabel.Text = "Progress:";
            // 
            // decryptDirectoryDialog
            // 
            this.decryptDirectoryDialog.ShowNewFolderButton = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "Coded by Michael Gillespie / Demonslay335, Special Thanks to Marcel H.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 367);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecryptProgressLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.LineLabel);
            this.Controls.Add(this.CleanFileButton);
            this.Controls.Add(this.EncryptedFileButton);
            this.Controls.Add(this.GenerateKeyButton);
            this.Controls.Add(this.KeyStatusLabel);
            this.Controls.Add(this.FolderSelectedLabel);
            this.Controls.Add(this.SelectFolderButton);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.keyTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NemucodCryptedDecrypter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog encryptedFileDialog;
        private System.Windows.Forms.OpenFileDialog cleanFileDialog;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.Label FolderSelectedLabel;
        private System.Windows.Forms.Label KeyStatusLabel;
        private System.Windows.Forms.Button GenerateKeyButton;
        private System.Windows.Forms.Button EncryptedFileButton;
        private System.Windows.Forms.Button CleanFileButton;
        private System.Windows.Forms.Label LineLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label DecryptProgressLabel;
        private System.Windows.Forms.FolderBrowserDialog decryptDirectoryDialog;
        public System.Windows.Forms.TextBox keyTextbox;
        private System.Windows.Forms.Label label1;
    }
}

