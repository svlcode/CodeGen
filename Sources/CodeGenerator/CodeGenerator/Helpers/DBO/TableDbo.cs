using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using CodeGenerator.Helpers.BO;

namespace CodeGenerator.Helpers.DBO
{
    public class TableDbo
    {
        private readonly string _connString;

        public TableDbo(string connString)
        {
            _connString = connString;
        }

        public DataTable GetAllTablesDataTable()
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (var adapter = new SqlDataAdapter("SELECT object_id AS Id,name AS Name FROM sys.Tables", conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public BindingList<TableBo> GetTablesBindingList()
        {
            BindingList<TableBo> list = new BindingList<TableBo>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (var cmd = new SqlCommand("SELECT object_id AS Id,name AS Name FROM sys.Tables", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableBo bo = new TableBo();
                            bo.IsSelected = Constants.DEFAULT_SELECTION_STATE;
                            if (!reader.IsDBNull(0)) bo.Id = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) bo.Name = reader.GetString(1);
                            list.Add(bo);
                        }
                    }
                }
            }

            return list;
        }
    }
}