using Cheke.BusinessEntity;
using System.Drawing;

namespace Cheke.WinCtrl.Login
{
    public interface ILogin
    {
        void PrepareLogin();

        Result Login(string userId, string password);
        Result ChangePassword(string userId, string oldPassword, string newPassword);
        Result RecoverPassword(string userId);

        int MaxTryCount { get; }

        Image LoginImage { get;}
    }
}