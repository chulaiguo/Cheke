using System;
using System.Data;
using System.IO;

namespace Cheke.Excel
{
    public class ExcelReader : ExcelBase
    {
        public DataTable GetSchemaTable(byte[] data)
        {
            string path = this.GetTempExcelPath(data);
            try
            {
                return this.GetSchemaTable(path);
            }
            finally
            {
                File.Delete(path);
            }
        }

        public string[] GetExcelSheetsList(byte[] data)
        {
            DataTable table = this.GetSchemaTable(data);
            return this.GetExcelSheetsList(table);
        }

        public DataSet LoadIntoDataSet(byte[] data, bool header)
        {
            string path = this.GetTempExcelPath(data);
            try
            {
                return this.LoadIntoDataSet(path, header);
            }
            finally
            {
                File.Delete(path);
            }
        }

        public DataTable LoadIntoDataTable(byte[] data, string sheet, bool header)
        {
            if (!sheet.EndsWith("$"))
            {
                sheet = string.Format("{0}$", sheet);
            }

            string path = this.GetTempExcelPath(data);
            try
            {
                DataTable dataTable = this.LoadIntoDataTable(path, sheet, header);
                this.ProcessDataTable(dataTable);
                return dataTable;
            }
            finally 
            {
                File.Delete(path);
            }
        }

        private string GetTempExcelPath(byte[] data)
        {
            string fileName = string.Format("{0}Excel_{1}.xls", Path.GetTempPath(), Guid.NewGuid());
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }

            return fileName;
        }
    }
}