using System;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;

namespace CodeGenerator.Helpers
{
    public class SqlConnectionDialog : IDisposable
    {
        public ConnectionData ConnectionData { get; private set; }

        public DialogResult ShowDialog()
        {
            ConnectionData = new ConnectionData();
            
            using (DataConnectionDialog dcd = new DataConnectionDialog())
            {
                DataSource.AddStandardDataSources(dcd);
                dcd.SelectedDataSource = DataSource.SqlDataSource;
                dcd.SelectedDataProvider = DataProvider.SqlDataProvider;

                var dialogResult = DataConnectionDialog.Show(dcd);
                if (dialogResult == DialogResult.OK)
                {
                    ConnectionData = new ConnectionData(dcd.ConnectionString);
                }
                return dialogResult;
            }
        }

        public void Dispose()
        {
            ConnectionData = null;
        }
    }
}