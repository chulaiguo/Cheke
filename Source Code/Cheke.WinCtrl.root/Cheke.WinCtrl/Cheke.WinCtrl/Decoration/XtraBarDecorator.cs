using Cheke.WinCtrl.Storage;
using DevExpress.XtraBars;

namespace Cheke.WinCtrl.Decoration
{
    public class XtraBarDecorator : DecoratorBase
    {
        protected BarManager _barManager = null;
        protected string _userId = string.Empty;
        private string _layoutFileName = string.Empty;

        public XtraBarDecorator(string userId, BarManager barManager)
        {
            this._userId = userId;
            this._barManager = barManager;

            this._layoutFileName = string.Format("{0}.XtraBarLayout.style", this._userId);
        }

        public override void Initialize()
        {
        }

        public void SaveLayout()
        {
            //using(StyleStorage storage = new StyleStorage(this._layoutFileName))
            //{
            //    storage.SaveLayout(this._barManager);
            //}
        }

        public void RestoreLayout()
        {
            //using (StyleStorage storage = new StyleStorage(this._layoutFileName))
            //{
            //    storage.RestoreLayout(this._userId, this._barManager);
            //}
        }
    }
}