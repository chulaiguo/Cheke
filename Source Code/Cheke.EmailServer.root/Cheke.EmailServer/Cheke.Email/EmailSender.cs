using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;
using Cheke.EmailData;

namespace Cheke.Email
{
    public static class EmailSender
    {
        public static string SendEmail(EmailMessageData data)
        {
            try
            {
                //Template File
                string templateFileName = string.Empty;
                if (data.TemplateName.Length > 0)
                {
                    templateFileName = ConfigurationManager.AppSettings[data.TemplateName];
                    if (string.IsNullOrEmpty(templateFileName))
                    {
                        return string.Format("The template file(TemplateNameKey=[{0}]) does't exist.", data.TemplateName);
                    }
                }

                MailMessage mail = new MailMessage();

                //From
                if (data.From.Length > 0)
                {
                    mail.From = new MailAddress(data.From, data.FromDisplayName);
                }

                //SendTo
                string[] splites = data.To.Split(';');
                foreach (string item in splites)
                {
                    if(item.Length == 0)
                        continue;
                    
                    mail.To.Add(new MailAddress(item));
                }
                
                //Subject & Body
                if (templateFileName.Length > 0)
                {
                    string contentOfFile = GetContentOfTemplateFile(templateFileName, data.TemplateKeyValueList);

                    mail.IsBodyHtml = true;
                    mail.Subject = GetTitle(contentOfFile);
                    mail.Body = contentOfFile;
                }
                else
                {
                    mail.Subject = data.Subject;
                    mail.IsBodyHtml = data.IsBodyHtml;
                    mail.Body = data.Body;
                }

                //Attachment
                foreach (AttachmentData item in data.AttachmentList)
                {
                    MemoryStream ms = new MemoryStream(item.Data);
                    mail.Attachments.Add(new Attachment(ms, item.Name));
                }

                SmtpClient client = new SmtpClient();
                client.Send(mail);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetTitle(string contentOfFile)
        {
            string beginTitle = "<title>";
            string endTitle = "</title>";

            int beginIndex = contentOfFile.IndexOf(beginTitle);
            if (beginIndex == -1)
                return string.Empty;

            int endIndex = contentOfFile.IndexOf(endTitle);
            if (endIndex == -1 || endIndex <= beginIndex)
                return string.Empty;

            return contentOfFile.Substring(beginIndex + beginTitle.Length, endIndex - beginIndex - beginTitle.Length);
        }

        private static string GetContentOfTemplateFile(string FileName, TemplateKeyValueDataCollection list)
        {
            StringBuilder builder = new StringBuilder();
            using (StreamReader reader = new StreamReader(FileName, Encoding.Default))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    builder.AppendLine(ProcessHTML(line, list));
                }
            }

            return builder.ToString();
        }

        private static string ProcessHTML(string html, TemplateKeyValueDataCollection list)
        {
            foreach (TemplateKeyValueData pair in list)
            {
                html = html.Replace(pair.Key, pair.Value);
            }

            return html;
        }
    }
}