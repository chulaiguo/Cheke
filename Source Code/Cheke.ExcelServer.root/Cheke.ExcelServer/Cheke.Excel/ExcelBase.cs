using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;

namespace Cheke.Excel
{
    public class ExcelBase
    {
        protected DataTable GetSchemaTable(string path)
        {
            string connectionString = this.GetConnectionString(path, false);
            DataTable table;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                connection.Close();
            }

            return table;
        }

        protected string[] GetExcelSheetsList(DataTable schemaTable)
        {
            if (schemaTable == null)
                return new string[0];

            StringCollection strings = new StringCollection();
            foreach (DataRow row in schemaTable.Rows)
            {
                string str = row["TABLE_NAME"].ToString();
                if (!strings.Contains(str))
                {
                    strings.Add(str);
                }
            }

            string[] array = new string[strings.Count];
            strings.CopyTo(array, 0);
            return array;
        }

        protected DataSet LoadIntoDataSet(string path, bool header)
        {
            DataSet set = new DataSet();

            DataTable schemaTbale = this.GetSchemaTable(path);
            string[] sheets = this.GetExcelSheetsList(schemaTbale);
            foreach (string item in sheets)
            {
                DataTable table = this.LoadIntoDataTable(path, item, header);
                this.ProcessDataTable(table);

                DataTable cloneTable = table.Clone();
                cloneTable.TableName = item;
                foreach (DataRow row in table.Rows)
                {
                    cloneTable.ImportRow(row);
                }
                set.Tables.Add(cloneTable);
            }

            return set;
        }

        protected DataTable LoadIntoDataTable(string path, string sheet, bool header)
        {
            string connectionString = this.GetConnectionString(path, header);

            string command = "Select * From [" + sheet + "]";
            DataTable dataTable = new DataTable();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command, connectionString))
            {
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        protected void ProcessDataTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                bool flag = true;
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (row[column].ToString().Trim().Length != 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    row.Delete();
                }
            }

            dataTable.AcceptChanges();
        }

        private string GetConnectionString(string path, bool header)
        {
            string str = header ? "Yes" : "No";
            return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR={1};IMEX=1;\"", path, str);
        }
    }
}