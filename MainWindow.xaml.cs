using System.Threading.Tasks;
using System.Windows;
using System;

namespace WTF_WIKI_TRANS_FUN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private LanguageChoice languageChoice = new LanguageChoice();
        public MainWindow()
        {
            InitializeComponent();

            start_popup pop_up_window = new start_popup();

            pop_up_window.ShowDialog();

            /* MessageBox.Show("Willkommen bei WTF! Hier kannst du entweder einen Text deiner Wahl in deine lieblings Fantasysprache übersetzten lassen oder" +
                "nach dem Thema deines Begehrens bei Wikipedia suchen! Wähle dazu einfach im Menü deine gewünschte Funktion aus und gebe im Suchfeld deine Anfrage ein. " +
                "Viel Spaß!");
            */
            
        }

        public void MenuChoiceUser(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (DropDownMenu.SelectedIndex == 1 && Languages != null && DropDownMenu.SelectedIndex != 2)
            {
                Languages.Visibility = Visibility.Visible;
                Bloedmann.Visibility = Visibility.Hidden;

                

                label_dein_text.Visibility = Visibility.Visible;
                label_translated_language.Visibility = Visibility.Visible;
                label_translated_text.Visibility = Visibility.Visible;
                
               
            }
            else if (DropDownMenu.SelectedIndex == 2 && Languages != null && DropDownMenu.SelectedIndex != 1)
            {
                Bloedmann.Visibility = Visibility.Visible;
                Languages.Visibility = Visibility.Hidden;

                label_dein_text.Visibility = Visibility.Hidden;
                label_translated_language.Visibility = Visibility.Hidden;
                label_translated_text.Visibility = Visibility.Hidden;
            }
            else if (Languages != null)
            {
                Languages.Visibility = Visibility.Hidden;
                Bloedmann.Visibility = Visibility.Hidden;

                label_dein_text.Visibility = Visibility.Hidden;
                label_translated_language.Visibility = Visibility.Hidden;
                label_translated_text.Visibility = Visibility.Hidden;
            }


        }

        

        private void DropDownMenu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        public string LanguageChoices()
        {
            string Language;

            if (Languages.SelectedIndex == 1)
                Language = "yoda";
            else if (Languages.SelectedIndex == 2)
                Language = "redneck";
            else if (Languages.SelectedIndex == 3)
                Language = "klingon";
            else if (Languages.SelectedIndex == 4)
                Language = "pirate";
            else if (Languages.SelectedIndex == 5)
                Language = "kraut";
            else
                Language = "";

            return Language;
        }
        private void TextSuche(object sender, RoutedEventArgs eventArgs)
        {
            Task<TranslateResponse> responseTask = null;
            TranslateRequest request = new TranslateRequest();
            try
            {
                responseTask = request.SearchTextAsync(Suchfeld.Text, LanguageChoices());
                if (responseTask != null)
                {
                    responseTask.GetAwaiter().OnCompleted(
                        () =>
                        {
                            try
                            {
                                TranslateResponse transResponse = responseTask.Result;
                                Translated.Text = transResponse.contents.translated;
                                Text.Text = transResponse.contents.text;
                                Translation.Text = transResponse.contents.translation;
                            }
                            catch (Exception e)
                            { MessageBox.Show(e.InnerException.Message); }

                            //Bloedmann.NavigateToString ( "<h1>Meine Ueberschrift</h1>");
                        }
                        );
                }
            }
            catch (TooManyRequestsException e)
            { MessageBox.Show(e.Message); }

        }

        private void WikiSuche(object sender, RoutedEventArgs eventArgs)
        {
            Task<string> responseTask = null;
            WikiRequest request = new WikiRequest();
            try
            {
                
                responseTask = request.SearchTextAsync(Suchfeld.Text);
                if (responseTask != null)
                {
                    responseTask.GetAwaiter().OnCompleted(
                        () =>
                        {
                            try
                            {
                                string wikiResponseRaw = responseTask.Result;
                                WikiResponseParser wikiResponseParser = new WikiResponseParser();
               
                                Bloedmann.Navigate(wikiResponseParser.Parse(wikiResponseRaw).URL);

                            }
                            catch (Exception e)
                            { MessageBox.Show(e.InnerException.Message); }

                            
                        }
                        );
                }
            }
            catch (TooManyRequestsException e)
            { MessageBox.Show(e.Message); }

        }

    }

}