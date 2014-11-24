using System.Collections.Generic;
using Cheke.BusinessEntity;

namespace Cheke.ClientSide
{
    public interface ILocalDataProcesser
    {
        void UpdateLocalData(List<BusinessBase> list);
    }
}