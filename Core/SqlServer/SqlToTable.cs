using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Core.Models;

namespace Core.SqlServer
{
    public class SqlToTable
    {
        public List<Table> ConverTables(string sqlConnection)
        {
            List<Table> tables = new List<Table>();
            SqlConnection connection = new SqlConnection(sqlConnection);

            connection.Open();
            SqlCommand command = new SqlCommand("select * from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'dbo' AND INFORMATION_SCHEMA.TABLES.TABLE_NAME NOT like '%sys%'", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dsTables = new DataSet();
            adapter.Fill(dsTables);
            for (int i = 0; i < dsTables.Tables[0].Rows.Count; i++)
            {
                tables.Add(new Table
                {
                    Name = dsTables.Tables[0].Rows[i]["TABLE_NAME"].ToString(),
                    Columns = GetColumnses(ref connection, dsTables.Tables[0].Rows[i]["TABLE_NAME"].ToString())
                });
            }
            connection.Close();
            return tables;
        }

        private List<Columns> GetColumnses(ref SqlConnection connection, string tableName)
        {
            List<Columns> columns = new List<Columns>();
            SqlCommand command = new SqlCommand("select * from INFORMATION_SCHEMA.COLUMNS where TABLE_SCHEMA = 'dbo' AND INFORMATION_SCHEMA.COLUMNS.TABLE_NAME ='" + tableName + "'", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dsColumns = new DataSet();
            adapter.Fill(dsColumns);
            for (int i = 0; i < dsColumns.Tables[0].Rows.Count; i++)
            {
                columns.Add(new Columns
                {
                    ColumnName = dsColumns.Tables[0].Rows[i]["COLUMN_NAME"].ToString(),
                    ColumnType = dsColumns.Tables[0].Rows[i]["DATA_TYPE"].ToString()
                });
            }
            return columns;
        }
    }
}
