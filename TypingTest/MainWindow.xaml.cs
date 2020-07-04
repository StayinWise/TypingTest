using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TypingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Background 
        private Grid grid;

        // Title page components
        private TextBlock title;
        private Button startButton;

        // Main components
        private TextBlock countDown;
        private TextBlock wordDisplay;
        private TextBox userInput;

        // Result components
        private Rectangle resultsBackground;
        private TextBlock results;
        private Button menuButton;

        // Countdown variables
        private DispatcherTimer dt = new DispatcherTimer();
        private int time;


        public MainWindow()
        {
            InitializeComponent();
            // Countdown
            this.dt = new DispatcherTimer();
            this.dt.Tick += new EventHandler(Timer_Tick);
            this.dt.Interval = new TimeSpan(0, 0, 1);
        }


        // Prevent any possible way of cheating
        private void UserInput_PreviewExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste ||
                e.Command == ApplicationCommands.Undo ||
                e.Command == ApplicationCommands.Redo ||
                e.Command == ApplicationCommands.Delete) e.Handled = true;
        }


        private LinearGradientBrush OriginalGradient()
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0.5, 0),
                EndPoint = new Point(0.5, 1)
            };
            gradientBrush.GradientStops.Add(new GradientStop(Colors.DimGray, 0.01));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, .80));
            return gradientBrush;
        }

        private void ResetWords()
        {
            this.wordDisplay.Text = "";
            Random random = new Random();
            // A temporary array for the words to prevent any repeating
            string[] temp = new string[175];
            for (int i = 0; i < 175; i++)
            {
                // Get a random word from the 300 in the bank
                string word = Words.WordBank[random.Next(Words.WordBank.Length)].ToLower();
                if (!temp.Contains(word))
                {
                    this.wordDisplay.Text = this.wordDisplay.Text + word + " ";
                    temp[i] = word;
                }
                else
                {
                    i--;
                }
            }
        }
        
        private void GetResults()
        {
            int wpm = 0;
            int errors = 0;
            int characters = 0;
            // Seperate the user's words and the words displayed to an array
            string[] displayedWords = this.wordDisplay.Text.Split(' ');
            string[] userWords = this.userInput.Text.Split(' ');
            
            // Loop through the words the user's words
            for(int i = 0; i < userWords.Length; i++)
            {
                // If the word matches up with the displayed one, add to the score
                if(userWords[i].Equals(displayedWords[i]))
                {
                    wpm++;
                }
            }

            // Loop through the user's text
            for(int i = 0; i < this.userInput.Text.Length; i++)
            {
                // Check whether the specific characters match up
                if(!this.userInput.Text[i].Equals(this.wordDisplay.Text[i]))
                {
                    errors++;
                }
                else
                {
                    characters++;
                }
            }
            int accuracy = 100 * characters / (errors + characters);

            this.results.Text = "»»»»»»»»»»»»»【Results】«««««««««««««\n" +
                                "WPM (Words Per Minute): " + wpm +
                                "\nErrors: " + errors +
                                "\nCharacters: " + characters +
                                "\nAccuracy: " + accuracy + "%" + 
                                "\n»»»»»»»»»»»»»【Results】«««««««««««««";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Every tick, decrement the time
            this.time--;
            if (this.time == 0)
            {
                // Stop the countdown and disable the main screen
                this.dt.Stop();
                this.userInput.IsEnabled = false;
                this.grid.Background = OriginalGradient();
                // Show the result
                this.GetResults();
                this.resultsBackground.Visibility = Visibility.Visible;
                this.results.Visibility = Visibility.Visible;
                this.menuButton.Visibility = Visibility.Visible;
                this.menuButton.IsEnabled = true;
            }
            // Red blink effect for the last 10 seconds
            else if (this.time <= 10)
            {
                if(this.time % 2 == 0)
                {
                    this.countDown.Foreground = new SolidColorBrush(Colors.DarkRed);
                }
                else
                {
                    this.countDown.Foreground = new SolidColorBrush(Colors.AliceBlue);
                }
            }
            this.countDown.Text = this.time.ToString();
        }

        // Button clicking events
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide the main screen and results
            this.wordDisplay.Visibility = Visibility.Hidden;
            this.countDown.Visibility = Visibility.Hidden;
            this.userInput.Visibility = Visibility.Hidden;
            this.userInput.IsEnabled = false;
            this.resultsBackground.Visibility = Visibility.Hidden;
            this.results.Visibility = Visibility.Hidden;
            this.menuButton.Visibility = Visibility.Hidden;
            this.menuButton.IsEnabled = false;
            // Show the title screen
            this.startButton.IsEnabled = true;
            this.startButton.Visibility = Visibility.Visible;
            this.title.Visibility = Visibility.Visible;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide the title screen
            this.startButton.IsEnabled = false;
            this.startButton.Visibility = Visibility.Hidden;
            this.title.Visibility = Visibility.Hidden;
            // Show the main screen
            this.wordDisplay.Visibility = Visibility.Visible;
            this.countDown.Visibility = Visibility.Visible;
            this.userInput.Visibility = Visibility.Visible;
            this.userInput.IsEnabled = true;
            this.userInput.Focus();
            // Reset the main screen
            this.time = 60;
            this.countDown.Text = this.time.ToString();
            this.userInput.Clear();
            this.ResetWords();
        }

        // User type event
        private void UserInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Red linear gradient
            LinearGradientBrush gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0.5, 0),
                EndPoint = new Point(0.5, 1)
            };
            gradientBrush.GradientStops.Add(new GradientStop(Colors.DarkRed, 0.01));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, .80));
            // Error detection
            // When you mistype a character the background will become a reddish gradient 
            for (int i = 0; i < this.userInput.Text.Length; i++)
            {
                if (!this.userInput.Text[i].Equals(this.wordDisplay.Text[i]))
                {
                    this.grid.Background = gradientBrush;
                }
                else
                {
                    this.grid.Background = OriginalGradient();
                }
            }
            // Start the countdown as soon as you start typing
            if (this.userInput.Text.Length == 1)
            {
                this.dt.Start();
            }
        }

        // Iniitializing components
        // Main Screen
        private void UserInput_Initialized(object sender, EventArgs e)
        {
            this.userInput = (TextBox)sender;
        }

        private void WordDisplay_Initialized(object sender, EventArgs e)
        {
            this.wordDisplay = (TextBlock)sender;
        }

        private void Countdown_Initialized(object sender, EventArgs e)
        {
            this.countDown = (TextBlock)sender;
        }


        // Title Screen
        private void Title_Initialized(object sender, EventArgs e)
        {
            this.title = (TextBlock)sender;
        }

        private void StartButton_Initialized(object sender, EventArgs e)
        {
            this.startButton = (Button)sender;
        }


        // Results Popup
        private void ResultsBackground_Initialized(object sender, EventArgs e)
        {
            this.resultsBackground = (Rectangle)sender;
        }

        private void Results_Initialized(object sender, EventArgs e)
        {
            this.results = (TextBlock)sender;
        }

        private void MenuButton_Initialized(object sender, EventArgs e)
        {
            this.menuButton = (Button)sender;
        }


        // Background
        private void Grid_Initialized(object sender, EventArgs e)
        {
            this.grid = (Grid)sender;
        }
    }
}
