using Cheke.EmailData;

namespace Cheke.IEmailService
{
    public interface IBizEmailService
    {
        string SendEmail(EmailMessageData data);
    }
}