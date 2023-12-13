namespace CianBarrettWordle22
{
    public partial class MainPage : ContentPage
    {
        private string targetWord = "apple"; // Replace with your actual target word
        private int maxAttempts = 6;
        private int attemptsLeft;

        public MainPage()
        {
            InitializeComponent();
            ResetGame();
        }

        private void OnCheckGuessClicked(object sender, EventArgs e)
        {
            string userGuess = GuessEntry.Text.ToLower();

            if (string.IsNullOrEmpty(userGuess) || userGuess.Length != targetWord.Length)
            {
                ResultLabel.Text = "Invalid guess. Please enter a valid word.";
                return;
            }

            attemptsLeft--;

            if (userGuess == targetWord)
            {
                ResultLabel.Text = "Congratulations! You guessed the word!";
                ResetGame();
            }
            else if (attemptsLeft == 0)
            {
                ResultLabel.Text = $"Sorry, you've run out of attempts. The correct word was {targetWord}.";
                ResetGame();
            }
            else
            {
                ResultLabel.Text = $"Incorrect guess. {attemptsLeft} attempts left.";
            }
        }

        private void ResetGame()
        {
            attemptsLeft = maxAttempts;
            GuessEntry.Text = string.Empty;
            ResultLabel.Text = string.Empty;
        }
    }
}