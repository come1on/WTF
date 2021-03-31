using System;

namespace WTF_WIKI_TRANS_FUN
{
    public class ConsolePrinter
    {
        private readonly TranslateResponse _transResponse;

        public ConsolePrinter(TranslateResponse transResponse)
        {
            _transResponse = transResponse;
        }

        private static void PrintTranslation(Translations translations)
        {
            Console.WriteLine("Übersetzung: " + translations.translated);
            Console.WriteLine("Dein Text: " + translations.text);
            Console.WriteLine("Sprache: " + translations.translation);
        }
    }
}