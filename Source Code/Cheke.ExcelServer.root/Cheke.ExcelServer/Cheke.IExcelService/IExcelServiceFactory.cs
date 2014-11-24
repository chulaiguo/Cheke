using System.Data;

namespace Cheke.IExcelService
{
    public interface IExcelServiceFactory
    {
        DataTable GetSchemaTable(byte[] data);
        string[] GetExcelSheetsList(byte[] data);

        DataSet LoadIntoDataSet(byte[] data, bool header);
        DataTable LoadIntoDataTable(byte[] data, string sheet, bool header);
    }
}