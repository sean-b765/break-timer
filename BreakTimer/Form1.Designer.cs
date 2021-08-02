
namespace BreakTimer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CmbStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbDuration = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCaption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTimer = new System.Windows.Forms.Label();
            this.LblSound = new System.Windows.Forms.Label();
            this.CmbSound = new System.Windows.Forms.ComboBox();
            this.ChbEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CmbStyle
            // 
            this.CmbStyle.FormattingEnabled = true;
            this.CmbStyle.Location = new System.Drawing.Point(11, 146);
            this.CmbStyle.Name = "CmbStyle";
            this.CmbStyle.Size = new System.Drawing.Size(151, 28);
            this.CmbStyle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alert Style";
            // 
            // CmbDuration
            // 
            this.CmbDuration.FormattingEnabled = true;
            this.CmbDuration.Location = new System.Drawing.Point(11, 49);
            this.CmbDuration.Name = "CmbDuration";
            this.CmbDuration.Size = new System.Drawing.Size(151, 28);
            this.CmbDuration.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Break Between Alerts (Minutes)";
            // 
            // TxtCaption
            // 
            this.TxtCaption.Location = new System.Drawing.Point(12, 446);
            this.TxtCaption.Name = "TxtCaption";
            this.TxtCaption.Size = new System.Drawing.Size(357, 27);
            this.TxtCaption.TabIndex = 4;
            this.TxtCaption.Text = "Alert!";
            this.TxtCaption.TextChanged += new System.EventHandler(this.TxtCaption_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Caption";
            // 
            // LblTimer
            // 
            this.LblTimer.AutoSize = true;
            this.LblTimer.Location = new System.Drawing.Point(13, 520);
            this.LblTimer.Name = "LblTimer";
            this.LblTimer.Size = new System.Drawing.Size(0, 20);
            this.LblTimer.TabIndex = 6;
            // 
            // LblSound
            // 
            this.LblSound.AutoSize = true;
            this.LblSound.Location = new System.Drawing.Point(12, 209);
            this.LblSound.Name = "LblSound";
            this.LblSound.Size = new System.Drawing.Size(51, 20);
            this.LblSound.TabIndex = 8;
            this.LblSound.Text = "Sound";
            // 
            // CmbSound
            // 
            this.CmbSound.FormattingEnabled = true;
            this.CmbSound.Location = new System.Drawing.Point(12, 241);
            this.CmbSound.Name = "CmbSound";
            this.CmbSound.Size = new System.Drawing.Size(151, 28);
            this.CmbSound.TabIndex = 7;
            // 
            // ChbEnabled
            // 
            this.ChbEnabled.AutoSize = true;
            this.ChbEnabled.Location = new System.Drawing.Point(287, 13);
            this.ChbEnabled.Name = "ChbEnabled";
            this.ChbEnabled.Size = new System.Drawing.Size(83, 24);
            this.ChbEnabled.TabIndex = 9;
            this.ChbEnabled.Text = "Enable?";
            this.ChbEnabled.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 553);
            this.Controls.Add(this.ChbEnabled);
            this.Controls.Add(this.LblSound);
            this.Controls.Add(this.CmbSound);
            this.Controls.Add(this.LblTimer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtCaption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbDuration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbStyle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 600);
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "Form1";
            this.Text = "BreakTimer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCaption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTimer;
        private System.Windows.Forms.Label LblSound;
        private System.Windows.Forms.ComboBox CmbSound;
        private System.Windows.Forms.CheckBox ChbEnabled;
    }
}

