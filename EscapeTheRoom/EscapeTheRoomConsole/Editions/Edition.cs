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
            Console.WriteLine($"I'm going to ask you a series of questions. If you answer all the questions correctly, you will be given a code with which you can ESCAPE THE ROOM. However, if you fail to answer all the questions correctly before using your {_maximumIncorrectAllowed} incorrect guesses, you will NEVER BE ALLOWED TO LEAVE.", Color.Red);
        }

        private void ShowFailureBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/scream.wav");
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

            Console.Write($"Your code is: ");
            Console.WriteLine(_escapeCode, Color.Green);
        }

        private bool AskQuestions()
        {
            var numberOfIncorrectAnswers = 0;

            for(var i = 0; i < _questions.Count; i++)
            {
                var question = _questions[i];

                if (numberOfIncorrectAnswers >= _maximumIncorrectAllowed)
                {
                    return false;
                }

                Thread.Sleep(500);
                Console.WriteLine($"{question.QuestionMessage}:");
                var input = Console.ReadLine();

                if (question.IsCorrect(input))
                {
                    ShowCorrectAnswerMessage(_questions.Count - i - 1);
                    continue;
                }

                numberOfIncorrectAnswers++;
                ShowIncorrectAnswerMessage(numberOfIncorrectAnswers);
                i--;
            }

            return true;
        }

        private void ShowCorrectAnswerMessage(int numberOfQuestionsLeft)
        {
            Thread.Sleep(500);
            
            if (numberOfQuestionsLeft == 0)
            {
                return;
            }

            Console.WriteLine($"That is correct. {numberOfQuestionsLeft} questions left", Color.Green);
        }

        private void ShowIncorrectAnswerMessage(int numberOfIncorrectAnswers)
        {
            Thread.Sleep(500);
            Console.WriteLine($"That is not correct. You have {_maximumIncorrectAllowed - numberOfIncorrectAnswers} incorrect guesses left.", Color.Red);
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
