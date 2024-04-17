﻿namespace BITCollegeWindows
{
    partial class BatchUpdate
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label descriptionLabel1;
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            this.radSelect = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptionComboBox1 = new System.Windows.Forms.ComboBox();
            descriptionLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_TA.Models.Student);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(descriptionLabel1);
            this.groupBox1.Controls.Add(this.descriptionComboBox1);
            this.groupBox1.Controls.Add(this.lnkProcess);
            this.groupBox1.Controls.Add(this.radSelect);
            this.groupBox1.Controls.Add(this.radAll);
            this.groupBox1.Location = new System.Drawing.Point(26, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 344);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Selection";
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Location = new System.Drawing.Point(41, 133);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(85, 15);
            this.lnkProcess.TabIndex = 2;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Batch";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // radSelect
            // 
            this.radSelect.AutoSize = true;
            this.radSelect.Location = new System.Drawing.Point(44, 59);
            this.radSelect.Name = "radSelect";
            this.radSelect.Size = new System.Drawing.Size(246, 19);
            this.radSelect.TabIndex = 1;
            this.radSelect.TabStop = true;
            this.radSelect.Text = "Select a Program to Grade and Register";
            this.radSelect.UseVisualStyleBackColor = true;
            this.radSelect.CheckedChanged += new System.EventHandler(this.radSelect_CheckedChanged);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(44, 36);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(233, 19);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "Grade and Register for ALL Programs";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(26, 239);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.ReadOnly = true;
            this.rtxtLog.Size = new System.Drawing.Size(714, 169);
            this.rtxtLog.TabIndex = 1;
            this.rtxtLog.Text = "";
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataSource = typeof(BITCollege_TA.Models.Course);
            // 
            // academicProgramBindingSource
            // 
            this.academicProgramBindingSource.DataSource = typeof(BITCollege_TA.Models.AcademicProgram);
            // 
            // descriptionLabel1
            // 
            descriptionLabel1.AutoSize = true;
            descriptionLabel1.Location = new System.Drawing.Point(43, 99);
            descriptionLabel1.Name = "descriptionLabel1";
            descriptionLabel1.Size = new System.Drawing.Size(58, 15);
            descriptionLabel1.TabIndex = 5;
            descriptionLabel1.Text = "Program:";
            // 
            // descriptionComboBox1
            // 
            this.descriptionComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.academicProgramBindingSource, "ProgramAcronym", true));
            this.descriptionComboBox1.DataSource = this.academicProgramBindingSource;
            this.descriptionComboBox1.DisplayMember = "Description";
            this.descriptionComboBox1.Enabled = false;
            this.descriptionComboBox1.FormattingEnabled = true;
            this.descriptionComboBox1.Location = new System.Drawing.Point(121, 96);
            this.descriptionComboBox1.Name = "descriptionComboBox1";
            this.descriptionComboBox1.Size = new System.Drawing.Size(121, 21);
            this.descriptionComboBox1.TabIndex = 6;
            // 
            // BatchUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.groupBox1);
            this.Name = "BatchUpdate";
            this.Text = "Batch Student Update";
            this.Load += new System.EventHandler(this.BatchUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.RadioButton radSelect;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private System.Windows.Forms.ComboBox descriptionComboBox1;
        private System.Windows.Forms.BindingSource academicProgramBindingSource;
    }
}