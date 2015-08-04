using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CodeGenerator.Forms
{
    public partial class GenerateForm : DevExpress.XtraEditors.XtraForm
    {
        public GenerateForm()
        {
            InitializeComponent();
        }

        private void chkGenerateSPs_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxControl1.Enabled = chkGenerateSPs.Checked;
        }

        private void GenerateForm_Load(object sender, EventArgs e)
        {
            checkedListBoxControl1.Items.Add(new CheckedListBoxItem("Get", true));
            checkedListBoxControl1.Items.Add(new CheckedListBoxItem("Exists", true));
            checkedListBoxControl1.Items.Add(new CheckedListBoxItem("Insert", true));
            checkedListBoxControl1.Items.Add(new CheckedListBoxItem("Update", true));
            checkedListBoxControl1.Items.Add(new CheckedListBoxItem("ListAll", true));
            checkedListBoxControl1.Items.Add(new CheckedListBoxItem("ListMin", true));
        }
    }
}