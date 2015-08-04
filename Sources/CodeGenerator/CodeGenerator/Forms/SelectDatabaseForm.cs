using System;
using System.Windows.Forms;
using CodeGenerator.Helpers;
using CodeGenerator.Helpers.Connection;
using DevExpress.XtraEditors;

namespace CodeGenerator.Forms
{
    public partial class SelectDatabaseForm : XtraForm
    {
        public string DatabaseName { get { return txtDatabaseName.Text;} }
        public string ConnectionString { get; private set; }

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
                ConnectionString = dlg.ConnectionData.ConnectionString;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                MessageBox.Show("Please select a database!");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
