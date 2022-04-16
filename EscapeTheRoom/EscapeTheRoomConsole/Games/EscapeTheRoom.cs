using System.Collections.Generic;
using System.Threading;
using System.Media;

namespace EscapeTheRoomConsole.Games
{
    public abstract class EscapeTheRoom : Game
    {
        private int _maximumIncorrectAllowed;
        private string _escapeCode;

        public EscapeTheRoom(List<Question> questions, string escapeCode, int maximumIncorrectAllowed) : base(questions, maximumIncorrectAllowed, QuestionType.Question)
        {
            _escapeCode = escapeCode;
            _maximumIncorrectAllowed = maximumIncorrectAllowed;
        }

        protected override void ShowInstructions()
        {
            var soundPlayer = new SoundPlayer("Sounds/instructions.wav");
            soundPlayer.Play();
            TypeLine("I'm going to ask you a bunch of questions.", System.ConsoleColor.Red);
            TypeLine("If you answer all the questions correctly, you will be given a passcode with which you can ESCAPE THE ROOM.", System.ConsoleColor.Red);
            TypeLine($"However, if you fail to answer all the questions correctly before using your {_maximumIncorrectAllowed} incorrect guesses, you will NEVER BE ALLOWED TO LEAVE.", System.ConsoleColor.Red);
        }

        protected override void ShowSuccessMessage()
        {
            ColorfulConsole.Write($"The passcode is: ");
            ColorfulConsole.WriteLine(_escapeCode, System.ConsoleColor.Green);
        }

        protected override void ShowWelcomeBanner()
        {

            ShowAsciiWithSomeGravitas("Get ");
            ShowAsciiWithSomeGravitas("Ready ");
            ShowAsciiWithSomeGravitas("To... ");

            Thread.Sleep(500);

            ShowWithLotsOfGravitas(@"
        ▓█████   ██████  ▄████▄   ▄▄▄       ██▓███  ▓█████ 
        ▓█   ▀ ▒██    ▒ ▒██▀ ▀█  ▒████▄    ▓██░  ██▒▓█   ▀ 
        ▒███   ░ ▓██▄   ▒▓█    ▄ ▒██  ▀█▄  ▓██░ ██▓▒▒███   
        ▒▓█  ▄   ▒   ██▒▒▓▓▄ ▄██▒░██▄▄▄▄██ ▒██▄█▓▒ ▒▒▓█  ▄ 
        ░▒████▒▒██████▒▒▒ ▓███▀ ░ ▓█   ▓██▒▒██▒ ░  ░░▒████▒
        ░░ ▒░ ░▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░ ▒▒   ▓▒█░▒▓▒░ ░  ░░░ ▒░ ░
         ░ ░  ░░ ░▒  ░ ░  ░  ▒     ▒   ▒▒ ░░▒ ░      ░ ░  ░
           ░   ░  ░  ░  ░          ░   ▒   ░░          ░   
           ░  ░      ░  ░ ░            ░  ░            ░  ░
                        ░                                  ", System.ConsoleColor.Red);

            ShowWithLotsOfGravitas(@"         
                ▄▄▄█████▓ ██░ ██ ▓█████ 
                ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ 
                ▒ ▓██░ ▒░▒██▀▀██░▒███   
                ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ 
                  ▒██▒ ░ ░▓█▒░██▓░▒████▒
                  ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░
                    ░     ▒ ░▒░ ░ ░ ░  ░
                  ░       ░  ░░ ░   ░   
                          ░  ░  ░   ░  ░", System.ConsoleColor.Red);

            ShowWithLotsOfGravitas(@"
             ██▀███   ▒█████   ▒█████   ███▄ ▄███▓
            ▓██ ▒ ██▒▒██▒  ██▒▒██▒  ██▒▓██▒▀█▀ ██▒
            ▓██ ░▄█ ▒▒██░  ██▒▒██░  ██▒▓██    ▓██░
            ▒██▀▀█▄  ▒██   ██░▒██   ██░▒██    ▒██ 
            ░██▓ ▒██▒░ ████▓▒░░ ████▓▒░▒██▒   ░██▒
            ░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░ ▒░▒░▒░ ░ ▒░   ░  ░
              ░▒ ░ ▒░  ░ ▒ ▒░   ░ ▒ ▒░ ░  ░      ░
              ░░   ░ ░ ░ ░ ▒  ░ ░ ░ ▒  ░      ░   
               ░         ░ ░      ░ ░         ░  ", System.ConsoleColor.Red);

            Thread.Sleep(2000);

            ShowEditionWelcomeBanner();
        }

        public abstract void ShowEditionWelcomeBanner();
    }
}
