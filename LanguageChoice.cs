namespace WTF_WIKI_TRANS_FUN
{
    internal class LanguageChoice
    {
        public string LanguageChoices(int Index)
        {
            string Language;

            if (Index == 1)
                Language = "yoda";
            else if (Index == 2)
                Language = "redneck";
            else if (Index == 3)
                Language = "klingon";
            else if (Index == 4)
                Language = "pirate";
            else if (Index == 5)
                Language = "kraut";
            else
                Language = "";

            return Language;
        }

        private string text;

        public string Text
        {
            get => text;
            set
            {
                text = value;
            }
        }
    }
}