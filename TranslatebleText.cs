using System;

namespace WTF_WIKI_TRANS_FUN
{
    internal class TranslatebleText
    {
        private string text;

        public string Text
        {
            get => text;
            set
            {
                CheckLength(value);
                text = value;
            }
        }

        public void CheckLength(String Message)
        {
            if (Message.Length > 100)
                throw new StringToLongException("Suchanfrage ist zu lang");
        }
    }
}