namespace BITCollegeWindows
{
    partial class Grading
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
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label courseTypeLabel;
            System.Windows.Forms.Label gradeLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lblExisting = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.courseTypeLabel1 = new System.Windows.Forms.Label();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            studentNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            courseTypeLabel = new System.Windows.Forms.Label();
            gradeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(descriptionLabel);
            this.groupBox1.Controls.Add(this.descriptionLabel1);
            this.groupBox1.Controls.Add(fullNameLabel);
            this.groupBox1.Controls.Add(this.fullNameLabel1);
            this.groupBox1.Controls.Add(studentNumberLabel);
            this.groupBox1.Controls.Add(this.studentNumberMaskedLabel);
            this.groupBox1.Location = new System.Drawing.Point(66, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(courseTypeLabel);
            this.groupBox2.Controls.Add(this.courseTypeLabel1);
            this.groupBox2.Controls.Add(titleLabel);
            this.groupBox2.Controls.Add(this.titleLabel1);
            this.groupBox2.Controls.Add(courseNumberLabel);
            this.groupBox2.Controls.Add(this.courseNumberMaskedLabel);
            this.groupBox2.Controls.Add(this.lnkReturn);
            this.groupBox2.Controls.Add(this.lnkUpdate);
            this.groupBox2.Controls.Add(this.lblExisting);
            this.groupBox2.Location = new System.Drawing.Point(130, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 197);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grading Information";
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(240, 161);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(117, 13);
            this.lnkReturn.TabIndex = 2;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Student Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Enabled = false;
            this.lnkUpdate.Location = new System.Drawing.Point(122, 161);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(74, 13);
            this.lnkUpdate.TabIndex = 1;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lblExisting
            // 
            this.lblExisting.AutoSize = true;
            this.lblExisting.Location = new System.Drawing.Point(240, 101);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Size = new System.Drawing.Size(174, 13);
            this.lblExisting.TabIndex = 0;
            this.lblExisting.Text = "Existing grades cannot be modified.";
            this.lblExisting.Visible = false;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_TA.Models.Student);
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(50, 43);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(87, 13);
            studentNumberLabel.TabIndex = 0;
            studentNumberLabel.Text = "Student Number:";
            // 
            // studentNumberMaskedLabel
            // 
            this.studentNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.studentNumberMaskedLabel.Location = new System.Drawing.Point(143, 43);
            this.studentNumberMaskedLabel.Name = "studentNumberMaskedLabel";
            this.studentNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.studentNumberMaskedLabel.TabIndex = 1;
            this.studentNumberMaskedLabel.Text = "maskedLabel1";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(298, 48);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(57, 13);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Full Name:";
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(361, 48);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(100, 23);
            this.fullNameLabel1.TabIndex = 3;
            this.fullNameLabel1.Text = "label1";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(61, 87);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Description:";
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "AcademicProgram.Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(130, 87);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(100, 23);
            this.descriptionLabel1.TabIndex = 5;
            this.descriptionLabel1.Text = "label1";
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_TA.Models.Registration);
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(58, 67);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(83, 13);
            courseNumberLabel.TabIndex = 3;
            courseNumberLabel.Text = "Course Number:";
            // 
            // courseNumberMaskedLabel
            // 
            this.courseNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseNumber", true));
            this.courseNumberMaskedLabel.Location = new System.Drawing.Point(147, 67);
            this.courseNumberMaskedLabel.Name = "courseNumberMaskedLabel";
            this.courseNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.courseNumberMaskedLabel.TabIndex = 4;
            this.courseNumberMaskedLabel.Text = "maskedLabel1";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(60, 91);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(30, 13);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "Title:";
            // 
            // titleLabel1
            // 
            this.titleLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.Title", true));
            this.titleLabel1.Location = new System.Drawing.Point(96, 91);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(100, 23);
            this.titleLabel1.TabIndex = 6;
            this.titleLabel1.Text = "label1";
            // 
            // courseTypeLabel
            // 
            courseTypeLabel.AutoSize = true;
            courseTypeLabel.Location = new System.Drawing.Point(234, 67);
            courseTypeLabel.Name = "courseTypeLabel";
            courseTypeLabel.Size = new System.Drawing.Size(70, 13);
            courseTypeLabel.TabIndex = 7;
            courseTypeLabel.Text = "Course Type:";
            // 
            // courseTypeLabel1
            // 
            this.courseTypeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseType", true));
            this.courseTypeLabel1.Location = new System.Drawing.Point(310, 67);
            this.courseTypeLabel1.Name = "courseTypeLabel1";
            this.courseTypeLabel1.Size = new System.Drawing.Size(100, 23);
            this.courseTypeLabel1.TabIndex = 8;
            this.courseTypeLabel1.Text = "label1";
            // 
            // gradeLabel
            // 
            gradeLabel.AutoSize = true;
            gradeLabel.Location = new System.Drawing.Point(149, 411);
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Size = new System.Drawing.Size(39, 13);
            gradeLabel.TabIndex = 3;
            gradeLabel.Text = "Grade:";
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Grade", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "P2"));
            this.gradeTextBox.Location = new System.Drawing.Point(194, 408);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(100, 20);
            this.gradeTextBox.TabIndex = 4;
            // 
            // Grading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(gradeLabel);
            this.Controls.Add(this.gradeTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Grading";
            this.Text = "Grading";
            this.Load += new System.EventHandler(this.Grading_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblExisting;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label fullNameLabel1;
        private EWSoftware.MaskedLabelControl.MaskedLabel studentNumberMaskedLabel;
        private System.Windows.Forms.Label courseTypeLabel1;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.Label titleLabel1;
        private EWSoftware.MaskedLabelControl.MaskedLabel courseNumberMaskedLabel;
        private System.Windows.Forms.TextBox gradeTextBox;
    }
}