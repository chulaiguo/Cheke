using System;
using System.Configuration;

namespace Cheke.EmailService
{
    public class ServiceBase : MarshalByRefObject
    {
        private readonly SecurityToken _trustableToken = null;
        private readonly SecurityToken _originalToken = null;
        private readonly SecurityToken _anonymousToken = null;

        protected ServiceBase(SecurityToken token)
        {
            this._originalToken = token;

            this._trustableToken = new SecurityToken(token.UserId, string.Empty, this.AppsToken, token.Ticks);
            this._trustableToken.Password = token.Password;

            this._anonymousToken = new SecurityToken(this.AnonymousUser, this.AnonymousPassword, this.AppsToken);
        }

        protected string UserId
        {
            get { return this._originalToken.UserId; }
        }

        protected SecurityToken TrustableToken
        {
            get { return this._trustableToken; }
        }

        protected SecurityToken OriginalToken
        {
            get { return this._originalToken; }
        }

        protected SecurityToken AnonymousToken
        {
            get { return _anonymousToken; }
        }

        private string AppsToken
        {
            get
            {
                object token = ConfigurationManager.AppSettings["AppsToken"];
                return token == null ? string.Empty : token.ToString();
            }
        }

        private string AnonymousUser
        {
            get
            {
                object token = ConfigurationManager.AppSettings["AnonymousUser"];
                return token == null ? string.Empty : token.ToString();
            }
        }

        private string AnonymousPassword
        {
            get
            {
                object token = ConfigurationManager.AppSettings["AnonymousPassword"];
                return token == null ? string.Empty : token.ToString();
            }
        }

    }
}