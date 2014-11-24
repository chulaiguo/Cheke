using Cheke.Email;
using Cheke.EmailData;
using Cheke.IEmailService;

namespace Cheke.EmailService
{
    public class BizEmailService : ServiceBase, IBizEmailService
    {
        public BizEmailService(SecurityToken token)
            : base(token)
        {
        }

        public string SendEmail(EmailMessageData data)
        {
            return EmailSender.SendEmail(data);
        }
    }
}