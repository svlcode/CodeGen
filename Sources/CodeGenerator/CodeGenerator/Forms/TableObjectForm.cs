using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using CodeGenerator.Helpers.BO;
using DevExpress.XtraEditors;

namespace CodeGenerator.Forms
{
    public partial class TableObjectForm : DevExpress.XtraEditors.XtraForm
    {
        public TableBo CurrentTable {get;set;}

        public TableObjectForm()
        {
            InitializeComponent();
        }

        private void TableObjectForm_Load(object sender, EventArgs e)
        {
            if(CurrentTable != null)
            {
                txtName.Text = CurrentTable.Name;
            }
        }
    }
}