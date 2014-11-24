using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Cheke.Translation
{
    public abstract class TranslatorBase
    {
        private readonly SortedList<string, Multilingual> _sortedList = new SortedList<string, Multilingual>();
        private bool _isEnglish = true;
        private bool _isGatherString = false;
        private bool _isTranslate = false;

        private Font _defaultUIFont = null;

        public bool IsEnglish
        {
            get { return _isEnglish; }
            set { _isEnglish = value; }
        }

        public bool IsGatherString
        {
            get { return _isGatherString; }
            set { _isGatherString = value; }
        }

        public SortedList<string, Multilingual> SortedList
        {
            get { return _sortedList; }
        }

        public bool IsTranslate
        {
            get { return _isTranslate; }
            set { _isTranslate = value; }
        }

        public Font DefaultUIFont
        {
            get { return _defaultUIFont; }
            set { _defaultUIFont = value; }
        }

        public void InitTranslator(string fileName)
        {
            MultilingualCollection list = new MultilingualCollection();
            list.LoadFromFile(fileName);
            if (list.Count == 0)
                return;

            this.SortedList.Clear();
            foreach (Multilingual item in list)
            {
                this.SortedList.Add(item.Key, item);
            }
        }

        public void InitTranslator(string executablePath, short firstLangID, short secondLangID)
        {
            this.SortedList.Clear();

            //First Language
            string firstFileName = this.GetDefaultFileName(executablePath, firstLangID);
            MultilingualCollection list = new MultilingualCollection();
            list.LoadFromFile(firstFileName);
            foreach (Multilingual item in list)
            {
                string firstLanguage = string.IsNullOrEmpty(item.Other) ? item.English : item.Other;
                if(!this.SortedList.ContainsKey(item.Key))
                {
                    Multilingual entity = new Multilingual();
                    entity.Key = item.Key;
                    entity.English = firstLanguage;
                    entity.Other = item.English;

                    this.SortedList.Add(item.Key, entity);
                }
                else
                {
                    this.SortedList[item.Key].English = firstLanguage;
                }
            }

            //Second Language
            string secondFileName = this.GetDefaultFileName(executablePath, secondLangID);
            list = new MultilingualCollection();
            list.LoadFromFile(secondFileName);
            foreach (Multilingual item in list)
            {
                string secondLanguage = string.IsNullOrEmpty(item.Other) ? item.English : item.Other;
                if (!this.SortedList.ContainsKey(item.Key))
                {
                    Multilingual entity = new Multilingual();
                    entity.Key = item.Key;
                    entity.English = item.English;
                    entity.Other = secondLanguage;

                    this.SortedList.Add(item.Key, entity);
                }
                else
                {
                    this.SortedList[item.Key].Other = secondLanguage;
                }
            }
        }

        public string GetDefaultFileName(string executablePath)
        {
            short langID = GetSystemDefaultLangID();
            return this.GetDefaultFileName(executablePath, langID);
        }

        public string GetDefaultFileName(string executablePath, short langID)
        {
            return string.Format("{0}.{1}.dat", executablePath, langID);
        }

        public MultilingualCollection GetMultilingualList()
        {
            MultilingualCollection list = new MultilingualCollection();
            foreach (KeyValuePair<string, Multilingual> pair in this.SortedList)
            {
                list.Add(pair.Value);
            }

            return list;
        }

        public string Translate(string key)
        {
            if (!this.SortedList.ContainsKey(key))
                return string.Empty;

            Multilingual result = this.SortedList[key];
            return this.IsEnglish ? result.English : result.Other;
        }

        public void AddTranslateString(string key, string english)
        {
            if(key.Length == 0 || english.Length == 0)
                return;

            if (this.SortedList.ContainsKey(key))
                return;

            Multilingual entity = new Multilingual();
            entity.Key = key;
            entity.English = english;
            this.SortedList.Add(key, entity);
        }

        public void RemoveTranslateString(string key)
        {
            if (!this.SortedList.ContainsKey(key))
                return;

            this.SortedList.Remove(key);
        }

        ///
        ///1025  �������� 
        ///1041  ����  
        ///1028  ��������
        ///1042  ������ 
        ///1029  �ݿ��� 
        ///1043  ������  
        ///1030  ������  
        ///1044  Ų����  
        ///1031  ����  
        ///1045  ������  
        ///1032  ϣ����  
        ///1046  �������� - ����  
        ///1033  Ӣ��  
        ///1049  ����  
        ///1034  �������� 
        ///1053  �����  
        ///1035  ������  
        ///1054  ̩��  
        ///1036  ����  
        ///1055  ��������  
        ///1037  ϣ������ 
        ///2052  ��������  
        ///1038  �������� 
        ///2070  ��������  
        ///1040  ������� 
        ///3076  ���� - ��� 
        /// 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern short GetSystemDefaultLangID();
    }
}