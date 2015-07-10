using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenerator.Helpers;
using Microsoft.Data.ConnectionUI;

namespace CodeGenerator
{
    public partial class SelectDatabaseForm : Form
    {
        public SelectDatabaseForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SqlConnectionDialog dlg = new SqlConnectionDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                txtDatabaseName.Text = dlg.ConnectionData.DatabaseName;
                txtServer.Text = dlg.ConnectionData.Server;
            }
        }

       
    }
}
