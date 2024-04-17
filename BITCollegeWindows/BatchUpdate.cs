using System;
using BITCollege_TA;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BITCollege_TA.Data;

namespace BITCollegeWindows
{
    public partial class BatchUpdate : Form
    {
        XDocument _xDocument;

        BITCollege_TAContext db = new BITCollege_TAContext();
        Batch batch = new Batch();

        public BatchUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Batch processing
        /// Further code to be added.
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                if (radSelect.Checked)
                {
                    // call process ransmission method for single transmission selection
                    string transmissionProgramAcronym = descriptionComboBox1.SelectedItem.ToString();
                    batch.ProcessTransmission(transmissionProgramAcronym);
                }
                else if (radAll.Checked)
                {
                    // iterate through each item in combox box
                    foreach (var item in descriptionComboBox1.Items)
                    {
                        string transmissionProgramAcronym = item.ToString();
                        // call process transmission for each
                        batch.ProcessTransmission(transmissionProgramAcronym);
                    }
                }
            }
            rtxtLog.AppendText("Batch processing has completed.\n");
        }

        /// <summary>
        /// given:  Always open this form in top right of frame.
        /// Further code to be added.
        /// </summary>
        private void BatchUpdate_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            //linq-sql.
            IEnumerable<string> academicDescription = db.AcademicPrograms.Select(a => a.Description).ToList();

            BindingSource academicBindingSource = new BindingSource();
            //academicProgramBindingSource.DataSource = academicIds;
            descriptionComboBox1.DataSource = academicDescription;

        }
        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelect.Checked)
            {
                descriptionComboBox1.Enabled = true;
            }
            else
            {
                descriptionComboBox1.Enabled = false;
            }
        }
    }
}
