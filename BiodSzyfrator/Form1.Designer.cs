namespace BiodSzyfrator
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
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.tbOutcome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bChooseBaseFile = new System.Windows.Forms.Button();
            this.bOutput = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bEncrypt = new System.Windows.Forms.Button();
            this.bDecrypt = new System.Windows.Forms.Button();
            this.bInfo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.Location = new System.Drawing.Point(27, 24);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.ReadOnly = true;
            this.tbSourceFile.Size = new System.Drawing.Size(358, 20);
            this.tbSourceFile.TabIndex = 0;
            // 
            // tbOutcome
            // 
            this.tbOutcome.Location = new System.Drawing.Point(27, 129);
            this.tbOutcome.Name = "tbOutcome";
            this.tbOutcome.ReadOnly = true;
            this.tbOutcome.Size = new System.Drawing.Size(358, 20);
            this.tbOutcome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ścieżka pliku wyjściowego";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ścieżka pliku wejsciowego";
            // 
            // bChooseBaseFile
            // 
            this.bChooseBaseFile.Location = new System.Drawing.Point(392, 22);
            this.bChooseBaseFile.Name = "bChooseBaseFile";
            this.bChooseBaseFile.Size = new System.Drawing.Size(122, 23);
            this.bChooseBaseFile.TabIndex = 4;
            this.bChooseBaseFile.Text = "Wczytaj plik";
            this.bChooseBaseFile.UseVisualStyleBackColor = true;
            this.bChooseBaseFile.Click += new System.EventHandler(this.bChooseBaseFile_Click);
            // 
            // bOutput
            // 
            this.bOutput.Location = new System.Drawing.Point(392, 127);
            this.bOutput.Name = "bOutput";
            this.bOutput.Size = new System.Drawing.Size(122, 23);
            this.bOutput.TabIndex = 5;
            this.bOutput.Text = "Wybierz ścieżkę";
            this.bOutput.UseVisualStyleBackColor = true;
            this.bOutput.Click += new System.EventHandler(this.bOutput_Click);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(27, 77);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(358, 20);
            this.tbKey.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Klucz szyfrujący/deszyfrujący";
            // 
            // bEncrypt
            // 
            this.bEncrypt.BackColor = System.Drawing.Color.MediumPurple;
            this.bEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bEncrypt.Location = new System.Drawing.Point(27, 188);
            this.bEncrypt.Name = "bEncrypt";
            this.bEncrypt.Size = new System.Drawing.Size(173, 51);
            this.bEncrypt.TabIndex = 8;
            this.bEncrypt.Text = "Szyfruj";
            this.bEncrypt.UseVisualStyleBackColor = false;
            this.bEncrypt.Click += new System.EventHandler(this.button3_Click);
            // 
            // bDecrypt
            // 
            this.bDecrypt.BackColor = System.Drawing.Color.MediumPurple;
            this.bDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bDecrypt.Location = new System.Drawing.Point(212, 188);
            this.bDecrypt.Name = "bDecrypt";
            this.bDecrypt.Size = new System.Drawing.Size(173, 51);
            this.bDecrypt.TabIndex = 9;
            this.bDecrypt.Text = "Deszyfruj";
            this.bDecrypt.UseVisualStyleBackColor = false;
            // 
            // bInfo
            // 
            this.bInfo.Location = new System.Drawing.Point(392, 216);
            this.bInfo.Name = "bInfo";
            this.bInfo.Size = new System.Drawing.Size(122, 23);
            this.bInfo.TabIndex = 10;
            this.bInfo.Text = "Info";
            this.bInfo.UseVisualStyleBackColor = true;
            this.bInfo.Click += new System.EventHandler(this.bInfo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ofdInFIle";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "ofdOutFile";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(535, 264);
            this.Controls.Add(this.bInfo);
            this.Controls.Add(this.bDecrypt);
            this.Controls.Add(this.bEncrypt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.bOutput);
            this.Controls.Add(this.bChooseBaseFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOutcome);
            this.Controls.Add(this.tbSourceFile);
            this.Name = "Form1";
            this.Text = "Szyfrator";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbSourceFile;
    private System.Windows.Forms.TextBox tbOutcome;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button bChooseBaseFile;
    private System.Windows.Forms.Button bOutput;
    private System.Windows.Forms.TextBox tbKey;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button bEncrypt;
    private System.Windows.Forms.Button bDecrypt;
    private System.Windows.Forms.Button bInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

