using System;
using System.ComponentModel;
using System.Windows.Forms;

using EWSoftware.MaskedLabelControl;

namespace MaskedLabelTest
{
    public partial class MaskedLabelTestForm : Form
    {
        public MaskedLabelTestForm()
        {
            InitializeComponent();

            cboMask.SelectedIndex = 0;
            txtPromptChar.Text = lblMaskedLabel.PromptChar.ToString();
            chkIncludePrompt.Checked = lblMaskedLabel.IncludePrompt;
            txtUnmaskedText.Text = DateTime.Today.ToString("MMddyyyy");
        }

        /// <summary>
        /// Test the settings
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if(cboMask.Text.Length == 0)
                cboMask.SelectedIndex = 0;

            if(txtPromptChar.Text.Length == 0)
                txtPromptChar.Text = "_";

            lblMaskedLabel.Mask = cboMask.Text;
            lblMaskedLabel.IncludePrompt = chkIncludePrompt.Checked;
            lblMaskedLabel.PromptChar = txtPromptChar.Text[0];

            lblMaskedLabel.Text = txtUnmaskedText.Text;
            lblResultHint.Text = lblMaskedLabel.ResultHint.ToString();
            lblHintPosition.Text = lblMaskedLabel.HintPosition.ToString();

            lblFormatTest.Text = String.Format("Test of the Format " +
                "Method:\r\n'{0}'\r\n(Unmasked text is {1})",
                MaskedLabel.Format(cboMask.Text, txtUnmaskedText.Text,
                txtPromptChar.Text[0]),
                (lblMaskedLabel.ResultHint > 0) ? "valid" : "invalid");
        }
    }
}
