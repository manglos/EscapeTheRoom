
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace EscapeTheRoomConsole.Games
{

    public abstract class ScavengerHunt : Game
    {
        private int _maximumIncorrectAllowed;
        private readonly string _thingBeingFound;
        private string _finalRiddle;

        public ScavengerHunt(List<Question> riddles, string finalRiddle, int maximumIncorrectAllowed, string thingBeingFound) : base(riddles, maximumIncorrectAllowed, QuestionType.Riddle)
        {
            _finalRiddle = finalRiddle;
            _maximumIncorrectAllowed = maximumIncorrectAllowed;
            _thingBeingFound = thingBeingFound;
        }

        protected override void ShowInstructions()
        {
            var soundPlayer = new SoundPlayer("Sounds/riddle.wav");
            soundPlayer.Play();
            Type("I'm going to ask you some ", System.ConsoleColor.Yellow);
            TypeLine("riddles.", System.ConsoleColor.Blue);
            
            Type("Each riddle will lead you to a ", System.ConsoleColor.Yellow); 
            Type("location ", System.ConsoleColor.Blue); 
            TypeLine($"with an {_thingBeingFound}.", System.ConsoleColor.Yellow);

            Type($"Each {_thingBeingFound} will have a ", System.ConsoleColor.Yellow);
            Type("piece of a code ", System.ConsoleColor.Blue);
            TypeLine("which you will need to type in.", System.ConsoleColor.Yellow);

            Type("If you type in each piece of code correctly, I will give you a ", System.ConsoleColor.Green);
            Type("final riddle ", System.ConsoleColor.Blue);
            TypeLine("which will lead you to an AWESOME GIFT!", System.ConsoleColor.Green);

            TypeLine($"However, If you fail to enter all the pieces of the code correctly before using your {_maximumIncorrectAllowed} incorrect guesses, you will GET NOTHING!", System.ConsoleColor.Red);
            soundPlayer = new SoundPlayer("Sounds/laugh.wav");
            soundPlayer.Play();
        }

        protected override void ShowSuccessMessage()
        {
            ColorfulConsole.Clear();
            TypeLine("Congratulations, I will now tell you the final riddle...", System.ConsoleColor.Green);
            Thread.Sleep(3000);
            ColorfulConsole.Clear();
            TypeLine(_finalRiddle, System.ConsoleColor.Blue);
        }

        protected override void ShowWelcomeBanner()
        {

            ShowAsciiWithSomeGravitas("Are");
            ShowAsciiWithSomeGravitas("You");
            ShowAsciiWithSomeGravitas("Ready");
            ShowAsciiWithSomeGravitas("For");
            ShowAsciiWithSomeGravitas("A");

            Thread.Sleep(500);

            ShowWithLotsOfGravitas(@"
 ________  ________  ________  ___      ___ _______   ________   ________  _______   ________     
|\   ____\|\   ____\|\   __  \|\  \    /  /|\  ___ \ |\   ___  \|\   ____\|\  ___ \ |\   __  \    
\ \  \___|\ \  \___|\ \  \|\  \ \  \  /  / | \   __/|\ \  \\ \  \ \  \___|\ \   __/|\ \  \|\  \   
 \ \_____  \ \  \    \ \   __  \ \  \/  / / \ \  \_|/_\ \  \\ \  \ \  \  __\ \  \_|/_\ \   _  _\  
  \|____|\  \ \  \____\ \  \ \  \ \    / /   \ \  \_|\ \ \  \\ \  \ \  \|\  \ \  \_|\ \ \  \\  \| 
    ____\_\  \ \_______\ \__\ \__\ \__/ /     \ \_______\ \__\\ \__\ \_______\ \_______\ \__\\ _\ 
   |\_________\|_______|\|__|\|__|\|__|/       \|_______|\|__| \|__|\|_______|\|_______|\|__|\|__|
   \|_________|                                                                                   ", System.ConsoleColor.Cyan);
            ShowWithLotsOfGravitas(@"
                             ___  ___  ___  ___  ________   _________   
                            |\  \|\  \|\  \|\  \|\   ___  \|\___   ___\ 
                            \ \  \\\  \ \  \\\  \ \  \\ \  \|___ \  \_| 
                             \ \   __  \ \  \\\  \ \  \\ \  \   \ \  \  
                              \ \  \ \  \ \  \\\  \ \  \\ \  \   \ \  \ 
                               \ \__\ \__\ \_______\ \__\\ \__\   \ \__\
                                \|__|\|__|\|_______|\|__| \|__|    \|__|", System.ConsoleColor.Cyan);

            Thread.Sleep(2000);

            ShowEditionWelcomeBanner();
        }

        public abstract void ShowEditionWelcomeBanner();

    }
}
