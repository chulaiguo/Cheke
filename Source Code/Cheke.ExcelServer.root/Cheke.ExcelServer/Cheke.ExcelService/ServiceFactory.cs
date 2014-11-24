using System;
using Cheke.IExcelService;

namespace Cheke.ExcelService
{
    public class ServiceFactory : MarshalByRefObject, IServiceFactory
    {
        public IBizReaderService GetReaderService()
        {
            return new BizBizReaderService();
        }
    }
}