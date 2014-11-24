using System;

namespace Cheke.EmailData
{
    [Serializable]
    public class EmailMessageData
    {
        private string _from = string.Empty;
        private string _fromDisplayName = string.Empty;
        private string _to = string.Empty;

        private string _subject = string.Empty;
        private string _body = string.Empty;
        private bool _isBodyHtml = false;

        private readonly AttachmentDataCollection _attachmentList = new AttachmentDataCollection();

        private string _templateName = string.Empty;
        private readonly TemplateKeyValueDataCollection _templateKeyValueList = new TemplateKeyValueDataCollection();

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        public string FromDisplayName
        {
            get { return _fromDisplayName; }
            set { _fromDisplayName = value; }
        }

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public bool IsBodyHtml
        {
            get { return _isBodyHtml; }
            set { _isBodyHtml = value; }
        }

        public AttachmentDataCollection AttachmentList
        {
            get { return _attachmentList; }
        } 

        public void AddAttachment(string name, byte[] data)
        {
            if(data == null || data.Length == 0)
                return;

            AttachmentData entity = new AttachmentData();
            entity.Name = name;
            entity.Data = new byte[data.Length];
            data.CopyTo(entity.Data, 0);

            this.AttachmentList.Add(entity);
        }

        public string TemplateName
        {
            get { return _templateName; }
            set { _templateName = value; }
        }

        public TemplateKeyValueDataCollection TemplateKeyValueList
        {
            get { return _templateKeyValueList; }
        }

        public void AddTemplateKeyValue(string key, string value)
        {
            this.TemplateKeyValueList.Add(new TemplateKeyValueData(key, value));
        }
    }
}