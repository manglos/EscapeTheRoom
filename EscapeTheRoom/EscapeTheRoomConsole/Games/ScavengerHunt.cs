
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace EscapeTheRoomConsole.Games
{

    public abstract class ScavengerHunt : Game
    {
        private int _maximumIncorrectAllowed;
        private readonly string _thingBeingFound;

        public ScavengerHunt(List<Question> riddles, int maximumIncorrectAllowed, string thingBeingFound) : base(riddles, maximumIncorrectAllowed, QuestionType.Riddle)
        {
            _maximumIncorrectAllowed = maximumIncorrectAllowed;
            _thingBeingFound = thingBeingFound;
        }

        protected override void ShowInstructions()
        {
            //var soundPlayer = new SoundPlayer("Sounds/riddle.wav");
            //soundPlayer.Play();
            Type("I'm going to ask you ", System.ConsoleColor.Yellow);
            TypeLine("3 riddles.", System.ConsoleColor.Blue);
            
            Type("Each riddle will lead you to a ", System.ConsoleColor.Yellow); 
            Type("location ", System.ConsoleColor.Blue); 
            Type($"with an ", System.ConsoleColor.Yellow);
            TypeLine($"{_thingBeingFound}.", System.ConsoleColor.Green);

            Type($"Each {_thingBeingFound} will have a ", System.ConsoleColor.Yellow);
            Type("party favor for each of you ", System.ConsoleColor.Blue);
            TypeLine("which will help prepare you for the party.", System.ConsoleColor.Yellow);
            Type($"Also, each {_thingBeingFound} will contain a ", System.ConsoleColor.Yellow);
            Type("piece of a code ", System.ConsoleColor.Blue);
            TypeLine("which you will need to type in.", System.ConsoleColor.Yellow);

            Type("Once you type in ", System.ConsoleColor.Green);
            Type("each piece of code correctly ", System.ConsoleColor.Blue);
            TypeLine("the BDAY party can BEGIN!", System.ConsoleColor.Green);

            TypeLine($"However, If you fail to enter all the pieces of the code correctly before using your {_maximumIncorrectAllowed} incorrect guesses...", System.ConsoleColor.Yellow);
            TypeLine($"YOU WILL HAVE TO GO HOME!", System.ConsoleColor.Red);
            var soundPlayer = new SoundPlayer("Sounds/recordscratch.wav");
            soundPlayer.Play();
            Thread.Sleep(5000);
            soundPlayer = new SoundPlayer("Sounds/laugh.wav");
            soundPlayer.Play();
            TypeLine("(jk jk we'll probably just start the party anyway)", System.ConsoleColor.Yellow);
        }

        protected override void ShowSuccessMessage()
        {
            ColorfulConsole.Clear();
            var soundPlayer = new SoundPlayer($"Sounds/rickroll.wav");
            soundPlayer.PlayLooping();
            TypeLine("Congratulations, you WON!", System.ConsoleColor.Green);
            Thread.Sleep(3000);
            ColorfulConsole.Clear();
            ShowAsciiWithSomeGravitas("Let");
            ShowAsciiWithSomeGravitas("The");
            ShowAsciiWithSomeGravitas("Party");
            ShowAsciiWithSomeGravitas("Begin");

            ShowWithLotsOfGravitas(@"
            ░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓███████▓▒░░▒▓█▓▒░░▒▓█▓▒░░▒▓███████▓▒░ 
               ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        
               ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        
               ░▒▓█▓▒░   ░▒▓████████▓▒░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓███████▓▒░ ░▒▓██████▓▒░  
               ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░ 
               ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░ 
               ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓███████▓▒░  
                                                                                            ", System.ConsoleColor.Cyan);
            ShowWithLotsOfGravitas(@"
                                ░▒▓████████▓▒░▒▓██████▓▒░░▒▓███████▓▒░  
                                ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
                                ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
                                ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓███████▓▒░  
                                ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
                                ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
                                ░▒▓█▓▒░      ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░ 
                                                                        ", System.ConsoleColor.Cyan);
            ShowWithLotsOfGravitas(@"
            ░▒▓███████▓▒░░▒▓█▓▒░       ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓███████▓▒░ ░▒▓██████▓▒░  
            ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
            ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        
            ░▒▓███████▓▒░░▒▓█▓▒░      ░▒▓████████▓▒░░▒▓██████▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒▒▓███▓▒░ 
            ░▒▓█▓▒░      ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
            ░▒▓█▓▒░      ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ 
            ░▒▓█▓▒░      ░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░  
                                                                                      ", System.ConsoleColor.Cyan);
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
