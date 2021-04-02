using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;
using System.Media;

namespace EscapeTheRoomConsole.Editions
{
    public abstract class Edition
    {
        private List<Question> _questions;
        private int _maximumIncorrectAllowed;
        private string _escapeCode;

        public Edition(List<Question> questions, string escapeCode, int maximumIncorrectAllowed)
        {
            _questions = questions;
            _escapeCode = escapeCode;
            _maximumIncorrectAllowed = maximumIncorrectAllowed;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Press Enter...");
            Console.ReadLine();
            Console.Clear();

            ShowWelcomeBanner();

            Thread.Sleep(2000);

            Console.Clear();

            ShowWelcomeMessage();

            ShowInstructions();

            Thread.Sleep(10000);
            Console.WriteLine("Press enter to begin...");
            Console.ReadLine();
            Console.Clear();

            var hasEscaped = AskQuestions();

            Console.Clear();

            if (hasEscaped)
            {
                ShowEscapedBanner();
                Console.ReadLine();
                return;
            }

            ShowFailureBanner();
            Console.WriteLine("Press Enter to Accept Defeat...", Color.Red);
            Console.ReadLine();
        }

        private void ShowInstructions()
        {
            var soundPlayer = new SoundPlayer("Sounds/instructions.wav");
            soundPlayer.Play();
            Console.WriteLine($"I'm going to ask you a bunch of questions. If you answer all the questions correctly, you will be given a passcode with which you can ESCAPE THE ROOM. However, if you fail to answer all the questions correctly before using your {_maximumIncorrectAllowed} incorrect guesses, you will NEVER BE ALLOWED TO LEAVE.", Color.Red);
        }

        private void ShowFailureBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/failure.wav");
            soundPlayer.Play();
            Console.WriteLine(@"
    ▄██   ▄    ▄██████▄  ███    █▄          ▄████████    ▄████████  ▄█   ▄█          ▄████████ ████████▄  
    ███   ██▄ ███    ███ ███    ███        ███    ███   ███    ███ ███  ███         ███    ███ ███   ▀███ 
    ███▄▄▄███ ███    ███ ███    ███        ███    █▀    ███    ███ ███▌ ███         ███    █▀  ███    ███ 
    ▀▀▀▀▀▀███ ███    ███ ███    ███       ▄███▄▄▄       ███    ███ ███▌ ███        ▄███▄▄▄     ███    ███ 
    ▄██   ███ ███    ███ ███    ███      ▀▀███▀▀▀     ▀███████████ ███▌ ███       ▀▀███▀▀▀     ███    ███ 
    ███   ███ ███    ███ ███    ███        ███          ███    ███ ███  ███         ███    █▄  ███    ███ 
    ███   ███ ███    ███ ███    ███        ███          ███    ███ ███  ███▌    ▄   ███    ███ ███   ▄███ 
     ▀█████▀   ▀██████▀  ████████▀         ███          ███    █▀  █▀   █████▄▄██   ██████████ ████████▀  
                                                                        ▀                                 
    ", Color.Red);
            Thread.Sleep(5000);
        }

        private void ShowEscapedBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/success.wav");
            soundPlayer.Play();
            Console.WriteLine(@"
    ██████╗  ██████╗  ██████╗ ██████╗          ██╗ ██████╗ ██████╗ ██╗██╗
    ██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗         ██║██╔═══██╗██╔══██╗██║██║
    ██║  ███╗██║   ██║██║   ██║██║  ██║         ██║██║   ██║██████╔╝██║██║
    ██║   ██║██║   ██║██║   ██║██║  ██║    ██   ██║██║   ██║██╔══██╗╚═╝╚═╝
    ╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝    ╚█████╔╝╚██████╔╝██████╔╝██╗██╗
     ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝      ╚════╝  ╚═════╝ ╚═════╝ ╚═╝╚═╝
                 ", Color.Green);
            Thread.Sleep(2000);

            Console.Write($"The passcode is: ");
            Console.WriteLine(_escapeCode, Color.Green);
        }

        private bool AskQuestions()
        {
            var numberOfIncorrectAnswers = 0;

            for(var i = 0; i < _questions.Count; i++)
            {
                if (numberOfIncorrectAnswers >= _maximumIncorrectAllowed)
                {
                    return false;
                }

                var question = _questions[i];
                var numberOfGuessesLeft = _maximumIncorrectAllowed - numberOfIncorrectAnswers;
                Console.Clear();
                var soundPlayer = new SoundPlayer("Sounds/thinking.wav");
                soundPlayer.PlayLooping();
                Console.WriteLine($"Question {i + 1} of {_questions.Count}.", Color.Tan);
                Thread.Sleep(1000);
                Console.WriteLine($"You {(numberOfGuessesLeft == 1 ? "only" : "still")} have {numberOfGuessesLeft} incorrect {(numberOfGuessesLeft == 1 ? "guess" : "guesses")} left.", (numberOfGuessesLeft == 1 ? Color.Red : Color.Tan));
                Thread.Sleep(1500);

                Console.WriteLine($"{question.QuestionMessage}:");
                var input = Console.ReadLine();

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

        private void ShowCorrectAnswerMessage()
        {
            Thread.Sleep(500);
            var soundPlayer = new SoundPlayer("Sounds/correct.wav");
            soundPlayer.Play();
            Console.WriteLine($"That is correct.", Color.Green);
            Thread.Sleep(4000);
        }

        private void ShowIncorrectAnswerMessage()
        {
            Thread.Sleep(500);
            var soundPlayer = new SoundPlayer("Sounds/incorrect.wav");
            soundPlayer.Play();
            Console.WriteLine($"That is not correct.", Color.Red);
            Thread.Sleep(4000);
        }

        private void ShowWelcomeMessage()
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.AppendLine("Do you think you have what it takes to Escape the Room??");

        }

        private void ShowWelcomeBanner()
        {

            Console.WriteAscii("Get ");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteAscii("Ready ");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteAscii("To... ");
            Thread.Sleep(500);
            Console.Clear();

            Thread.Sleep(500);

            var soundPlayer = new SoundPlayer("Sounds/boom.wav");
            soundPlayer.Play();
            Console.WriteLine(@"
        ▓█████   ██████  ▄████▄   ▄▄▄       ██▓███  ▓█████ 
        ▓█   ▀ ▒██    ▒ ▒██▀ ▀█  ▒████▄    ▓██░  ██▒▓█   ▀ 
        ▒███   ░ ▓██▄   ▒▓█    ▄ ▒██  ▀█▄  ▓██░ ██▓▒▒███   
        ▒▓█  ▄   ▒   ██▒▒▓▓▄ ▄██▒░██▄▄▄▄██ ▒██▄█▓▒ ▒▒▓█  ▄ 
        ░▒████▒▒██████▒▒▒ ▓███▀ ░ ▓█   ▓██▒▒██▒ ░  ░░▒████▒
        ░░ ▒░ ░▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░ ▒▒   ▓▒█░▒▓▒░ ░  ░░░ ▒░ ░
         ░ ░  ░░ ░▒  ░ ░  ░  ▒     ▒   ▒▒ ░░▒ ░      ░ ░  ░
           ░   ░  ░  ░  ░          ░   ▒   ░░          ░   
           ░  ░      ░  ░ ░            ░  ░            ░  ░
                        ░                                  ", Color.Red);

            Thread.Sleep(1500);

            soundPlayer.Play();
            Console.WriteLine(@"         
                ▄▄▄█████▓ ██░ ██ ▓█████ 
                ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ 
                ▒ ▓██░ ▒░▒██▀▀██░▒███   
                ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ 
                  ▒██▒ ░ ░▓█▒░██▓░▒████▒
                  ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░
                    ░     ▒ ░▒░ ░ ░ ░  ░
                  ░       ░  ░░ ░   ░   
                          ░  ░  ░   ░  ░", Color.Red);

            Thread.Sleep(1500);

            soundPlayer.Play();
            Console.WriteLine(@"
             ██▀███   ▒█████   ▒█████   ███▄ ▄███▓
            ▓██ ▒ ██▒▒██▒  ██▒▒██▒  ██▒▓██▒▀█▀ ██▒
            ▓██ ░▄█ ▒▒██░  ██▒▒██░  ██▒▓██    ▓██░
            ▒██▀▀█▄  ▒██   ██░▒██   ██░▒██    ▒██ 
            ░██▓ ▒██▒░ ████▓▒░░ ████▓▒░▒██▒   ░██▒
            ░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░ ▒░▒░▒░ ░ ▒░   ░  ░
              ░▒ ░ ▒░  ░ ▒ ▒░   ░ ▒ ▒░ ░  ░      ░
              ░░   ░ ░ ░ ░ ▒  ░ ░ ░ ▒  ░      ░   
               ░         ░ ░      ░ ░         ░  ", Color.Red);

            Thread.Sleep(2000);

            ShowEditionWelcomeBanner();
        }

        public abstract void ShowEditionWelcomeBanner();
    }
}
