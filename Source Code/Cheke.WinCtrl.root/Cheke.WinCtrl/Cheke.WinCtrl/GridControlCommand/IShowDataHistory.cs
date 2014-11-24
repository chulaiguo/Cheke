using System;
using Cheke.BusinessEntity;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    public interface IShowDataHistory
    {
        void ShowEditEvents(GridView srcView, BusinessBase entity);
        void ShowDeleteEvents(GridView srcView, Type dataType);
    }
}