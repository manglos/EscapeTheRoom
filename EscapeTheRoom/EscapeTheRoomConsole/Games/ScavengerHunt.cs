
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace EscapeTheRoomConsole.Games
{

    public abstract class ScavengerHunt : Game
    {
        private int _maximumIncorrectAllowed;
        private string _finalRiddle;

        public ScavengerHunt(List<Question> riddles, string finalRiddle, int maximumIncorrectAllowed) : base(riddles, maximumIncorrectAllowed, QuestionType.Riddle)
        {
            _finalRiddle = finalRiddle;
            _maximumIncorrectAllowed = maximumIncorrectAllowed;
        }

        protected override void ShowInstructions()
        {
            var soundPlayer = new SoundPlayer("Sounds/riddle.wav");
            soundPlayer.Play();
            Type("I'm going to ask you some riddles.", System.ConsoleColor.Yellow);
            Type("Each riddle will lead you to a location with an egg.", System.ConsoleColor.Yellow);
            Type("Each egg will have a piece of a code which you will need to type in.", System.ConsoleColor.Yellow);
            Type("If you type in each piece of code correctly, I will give you a final riddle which will lead you to an AWESOME GIFT!", System.ConsoleColor.Green);
            Type($"However, If you fail to enter all the pieces of the code correctly before using your {_maximumIncorrectAllowed} incorrect guesses, you will GET NOTHING!", System.ConsoleColor.Red);
            soundPlayer = new SoundPlayer("Sounds/laugh.wav");
            soundPlayer.Play();
        }

        protected override void ShowSuccessMessage()
        {
            ColorfulConsole.Clear();
            Type("Congratulations, I will now tell you the final riddle...", System.ConsoleColor.Green);
            Thread.Sleep(3000);
            ColorfulConsole.Clear();
            Type(_finalRiddle, System.ConsoleColor.Blue);
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
