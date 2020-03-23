using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Media.SpeechRecognition;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QuietMonday
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // create a speech recogniser object - listens
        private SpeechRecognizer speechRecognizer;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            speechRecognizer = new SpeechRecognizer();
            speechRecognizer.Timeouts.BabbleTimeout = 
                TimeSpan.FromSeconds(0);
            speechRecognizer.Timeouts.InitialSilenceTimeout = 
                TimeSpan.FromSeconds(5);
            speechRecognizer.Timeouts.EndSilenceTimeout = 
                TimeSpan.FromSeconds(0.5);

            // load the grammar file here
            var grammarFile = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri("ms-appx:///grammar.xml"));

            // adds constraints to the speech recogniser
            //speechRecognizer.Constraints.Add();
            speechRecognizer.Constraints.Add(
                new SpeechRecognitionGrammarFileConstraint(grammarFile));
            var result = await speechRecognizer.CompileConstraintsAsync();
            if (result.Status == SpeechRecognitionResultStatus.Success)
            {
                while (true)
                {
                    // listen in to the user
                    SpeechRecognitionResult srr =
                        await speechRecognizer.RecognizeAsync();
                    // use the Semantic Interpretation engine
                    // to get the commands
                    string myCommand = "No Command";
                    IReadOnlyList<string> values = null;

                    if(srr.SemanticInterpretation.Properties.TryGetValue(
                                            "command", out values) == true)
                    {
                        string ruleID = srr.RulePath[0];
                        // do something to start a game - call a method
                        myCommand = values.FirstOrDefault();
                        switch (myCommand)
                        {
                            case "new":
                                StartNewGame();
                                break;
                            case "quit":
                                QuitGame();
                                break;
                        }
                    }
                    // see if there is a move command
                    string player;
                    int position;
                    if (srr.SemanticInterpretation.Properties.TryGetValue(
                                "Player", out values) == true)
                    {
                        player = values.FirstOrDefault();
                        position =
                            Convert.ToInt32(srr.SemanticInterpretation.Properties["Position"].Single());
                        MakeAMove(player, position);
                    }

                }
            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog(
                    "Could load grammar...",
                    "Load error");
                await messageDialog.ShowAsync();
            }
        }

        private async void MakeAMove(string player, int position)
        {
            var messageDialog = new Windows.UI.Popups.MessageDialog(
                "Move " + player + " to position " + position + "...", 
                "Making A Move");
            await messageDialog.ShowAsync();
        }

        private async void QuitGame()
        {
            var messageDialog = new Windows.UI.Popups.MessageDialog(
                "Quitting Game, Not Saving, please wait...", "Quit Game");
            await messageDialog.ShowAsync();
        }

        private async void StartNewGame()
        {
            var messageDialog = new Windows.UI.Popups.MessageDialog(
                "Setting up a new game, please wait...","Starting New Game");
            await messageDialog.ShowAsync();
        }
    }

    }
