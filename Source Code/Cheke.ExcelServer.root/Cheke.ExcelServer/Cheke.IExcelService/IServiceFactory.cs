namespace Cheke.IExcelService
{
    public interface IServiceFactory
    {
        IBizReaderService GetReaderService();
    }
}