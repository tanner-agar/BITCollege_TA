namespace MaskedLabelTest
{
    partial class MaskedLabelTestForm
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
            if(disposing && (components != null))
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnmaskedText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMask = new System.Windows.Forms.ComboBox();
            this.txtPromptChar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIncludePrompt = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResultHint = new System.Windows.Forms.Label();
            this.lblHintPosition = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblFormatTest = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "The &Unmasked Text";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnmaskedText
            // 
            this.txtUnmaskedText.Location = new System.Drawing.Point(186, 53);
            this.txtUnmaskedText.Name = "txtUnmaskedText";
            this.txtUnmaskedText.Size = new System.Drawing.Size(201, 22);
            this.txtUnmaskedText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(94, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "The &Mask";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMask
            // 
            this.cboMask.FormattingEnabled = true;
            this.cboMask.Items.AddRange(new object[] {
            "00/00/0000",
            "00:00",
            "000-00-0000",
            "(000) 000-0000",
            "00000-9999"});
            this.cboMask.Location = new System.Drawing.Point(186, 23);
            this.cboMask.Name = "cboMask";
            this.cboMask.Size = new System.Drawing.Size(201, 24);
            this.cboMask.TabIndex = 1;
            // 
            // txtPromptChar
            // 
            this.txtPromptChar.Location = new System.Drawing.Point(186, 81);
            this.txtPromptChar.MaxLength = 1;
            this.txtPromptChar.Name = "txtPromptChar";
            this.txtPromptChar.Size = new System.Drawing.Size(37, 22);
            this.txtPromptChar.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "The &Prompt Character";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIncludePrompt
            // 
            this.chkIncludePrompt.Location = new System.Drawing.Point(229, 81);
            this.chkIncludePrompt.Name = "chkIncludePrompt";
            this.chkIncludePrompt.Size = new System.Drawing.Size(195, 24);
            this.chkIncludePrompt.TabIndex = 6;
            this.chkIncludePrompt.Text = "Include prompt character";
            this.chkIncludePrompt.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(84, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Result Hint";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResultHint
            // 
            this.lblResultHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultHint.Location = new System.Drawing.Point(186, 201);
            this.lblResultHint.Name = "lblResultHint";
            this.lblResultHint.Size = new System.Drawing.Size(201, 23);
            this.lblResultHint.TabIndex = 11;
            this.lblResultHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHintPosition
            // 
            this.lblHintPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHintPosition.Location = new System.Drawing.Point(186, 235);
            this.lblHintPosition.Name = "lblHintPosition";
            this.lblHintPosition.Size = new System.Drawing.Size(72, 23);
            this.lblHintPosition.TabIndex = 13;
            this.lblHintPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(84, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Hint Position";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(67, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Masked Label";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(186, 121);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(88, 32);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblFormatTest
            // 
            this.lblFormatTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFormatTest.Location = new System.Drawing.Point(186, 275);
            this.lblFormatTest.Name = "lblFormatTest";
            this.lblFormatTest.Size = new System.Drawing.Size(238, 75);
            this.lblFormatTest.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(84, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Format Test";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaskedLabel
            // 
            this.lblMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaskedLabel.Location = new System.Drawing.Point(186, 166);
            this.lblMaskedLabel.Name = "lblMaskedLabel";
            this.lblMaskedLabel.Size = new System.Drawing.Size(201, 23);
            this.lblMaskedLabel.TabIndex = 9;
            this.lblMaskedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaskedLabelTestForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(443, 369);
            this.Controls.Add(this.lblFormatTest);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblMaskedLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHintPosition);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblResultHint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkIncludePrompt);
            this.Controls.Add(this.txtPromptChar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnmaskedText);
            this.Controls.Add(this.label1);
            this.Name = "MaskedLabelTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaskedLabel Test Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnmaskedText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMask;
        private System.Windows.Forms.TextBox txtPromptChar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIncludePrompt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResultHint;
        private System.Windows.Forms.Label lblHintPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblMaskedLabel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblFormatTest;
        private System.Windows.Forms.Label label6;

    }
}

