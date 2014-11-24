using System;
using System.Data;
using Cheke.Excel;
using Cheke.IExcelService;

namespace Cheke.ExcelService
{
    public class ExcelServiceFactory : MarshalByRefObject, IExcelServiceFactory
    {
        public DataTable GetSchemaTable(byte[] data)
        {
           ExcelReader reader = new ExcelReader();
           return reader.GetSchemaTable(data);
        }

        public string[] GetExcelSheetsList(byte[] data)
        {
            ExcelReader reader = new ExcelReader();
            return reader.GetExcelSheetsList(data);
        }

        public DataSet LoadIntoDataSet(byte[] data, bool header)
        {
            ExcelReader reader = new ExcelReader();
            return reader.LoadIntoDataSet(data, header);
        }

        public DataTable LoadIntoDataTable(byte[] data, string sheet, bool header)
        {
            ExcelReader reader = new ExcelReader();
            return reader.LoadIntoDataTable(data, sheet, header);
        }

    }
}