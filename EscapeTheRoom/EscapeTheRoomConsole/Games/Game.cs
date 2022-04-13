using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading;

namespace EscapeTheRoomConsole.Games
{
    public abstract class Game
    {
        private readonly List<Question> _questions;
        private readonly int _maximumIncorrectAllowed;
        private readonly QuestionType _questionType;

        public Game(List<Question> questions, int maximumIncorrectAllowed, QuestionType questionType)
        {
            _questions = questions;
            _maximumIncorrectAllowed = maximumIncorrectAllowed;
            _questionType = questionType;
        }

        protected abstract void ShowWelcomeBanner();
        protected abstract void ShowInstructions();
        protected abstract void ShowSuccessMessage();

        public void Run()
        {
            ColorfulConsole.Clear();
            ColorfulConsole.WriteLine("Press Enter...");
            ColorfulConsole.ReadLine();
            ColorfulConsole.Clear();

            ShowWelcomeBanner();

            Thread.Sleep(2000);

            ColorfulConsole.Clear();

            ShowInstructions();

            Thread.Sleep(2000);
            ColorfulConsole.WriteLine("Press enter to begin...");
            ColorfulConsole.ReadLine();
            ColorfulConsole.Clear();

            var didWin = AskQuestions();

            ColorfulConsole.Clear();

            if (didWin)
            {
                ShowSuccessBanner();
                ShowSuccessMessage();
                ColorfulConsole.ReadLine();
                return;
            }

            ShowFailureBanner();
            ColorfulConsole.WriteLine("Press Enter to Accept Defeat...", System.ConsoleColor.Red);
            ColorfulConsole.ReadLine();
        }


        private bool AskQuestions()
        {
            var numberOfIncorrectAnswers = 0;

            for (var i = 0; i < _questions.Count; i++)
            {
                if (numberOfIncorrectAnswers >= _maximumIncorrectAllowed)
                {
                    return false;
                }

                var question = _questions[i];
                var numberOfGuessesLeft = _maximumIncorrectAllowed - numberOfIncorrectAnswers;
                ColorfulConsole.Clear();
                var soundPlayer = new SoundPlayer("Sounds/thinking.wav");
                soundPlayer.PlayLooping();
                ColorfulConsole.WriteLine($"{_questionType:G} {i + 1} of {_questions.Count}.", System.ConsoleColor.DarkYellow);
                Thread.Sleep(1000);
                ColorfulConsole.WriteLine($"You {(numberOfGuessesLeft == 1 ? "only" : "still")} have {numberOfGuessesLeft} incorrect {(numberOfGuessesLeft == 1 ? "guess" : "guesses")} left.", (numberOfGuessesLeft == 1 ? System.ConsoleColor.Red : System.ConsoleColor.DarkYellow));
                Thread.Sleep(1500);

                Type(question.QuestionMessage, System.ConsoleColor.White);
                var input = GetValidInput();

                Thread.Sleep(2000);
                if (question.IsCorrect(input))
                {
                    ShowCorrectAnswerMessage();
                    continue;
                }

                numberOfIncorrectAnswers++;
                ShowIncorrectAnswerMessage();
                i--;
            }

            return true;
        }

        protected void Type(string text, System.ConsoleColor color)
        {
            foreach (var character in text)
            {
                ColorfulConsole.Write(character, color);
                Thread.Sleep(character.Equals(' ') ? 10 : 50);
            }

            ColorfulConsole.WriteLine();
        }


        protected void ShowFailureBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/failure.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(@"
    ██╗   ██╗ ██████╗ ██╗   ██╗    ███████╗ █████╗ ██╗██╗     ███████╗██████╗ 
    ╚██╗ ██╔╝██╔═══██╗██║   ██║    ██╔════╝██╔══██╗██║██║     ██╔════╝██╔══██╗
     ╚████╔╝ ██║   ██║██║   ██║    █████╗  ███████║██║██║     █████╗  ██║  ██║
      ╚██╔╝  ██║   ██║██║   ██║    ██╔══╝  ██╔══██║██║██║     ██╔══╝  ██║  ██║
       ██║   ╚██████╔╝╚██████╔╝    ██║     ██║  ██║██║███████╗███████╗██████╔╝
       ╚═╝    ╚═════╝  ╚═════╝     ╚═╝     ╚═╝  ╚═╝╚═╝╚══════╝╚══════╝╚═════╝                                                                                                       
    ", System.ConsoleColor.Red);
            Thread.Sleep(5000);
        }

        protected  void ShowSuccessBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/success.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(@"
    ██████╗  ██████╗  ██████╗ ██████╗          ██╗ ██████╗ ██████╗ ██╗██╗
    ██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗         ██║██╔═══██╗██╔══██╗██║██║
    ██║  ███╗██║   ██║██║   ██║██║  ██║         ██║██║   ██║██████╔╝██║██║
    ██║   ██║██║   ██║██║   ██║██║  ██║    ██   ██║██║   ██║██╔══██╗╚═╝╚═╝
    ╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝    ╚█████╔╝╚██████╔╝██████╔╝██╗██╗
     ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝      ╚════╝  ╚═════╝ ╚═════╝ ╚═╝╚═╝
                 ", System.ConsoleColor.Green);
            Thread.Sleep(2000);
        }

        protected void ShowAsciiWithSomeGravitas(string text)
        {
            ColorfulConsole.WriteAscii(text);
            Thread.Sleep(500);
            ColorfulConsole.Clear();
        }

        protected void ShowWithLotsOfGravitas(string text, System.ConsoleColor color)
        {
            var soundPlayer = new SoundPlayer("Sounds/boom.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(text, color);
            Thread.Sleep(1500);
        }

        private string GetValidInput()
        {
            var result = string.Empty;

            while (string.IsNullOrEmpty(result))
            {
                result = ColorfulConsole.ReadLine();
            }

            return result;
        }

        private void ShowCorrectAnswerMessage()
        {
            Thread.Sleep(500);
            var soundPlayer = new SoundPlayer("Sounds/correct.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine($"That is correct.", System.ConsoleColor.Green);
            Thread.Sleep(4000);
        }

        private void ShowIncorrectAnswerMessage()
        {
            Thread.Sleep(500);
            var soundPlayer = new SoundPlayer("Sounds/incorrect.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine($"That is not correct.", System.ConsoleColor.Red);
            Thread.Sleep(4000);
        }
    }
}