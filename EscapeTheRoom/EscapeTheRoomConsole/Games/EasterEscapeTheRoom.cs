using System.Collections.Generic;
using System.Media;

namespace EscapeTheRoomConsole.Games
{
    public class EasterEscapeTheRoom : EscapeTheRoom
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question(@"
                I am round but I won't bounce.
                I am clear but I won't break.
                I am hidden inside eggs, but I'm not candy.

                How many of me are there in the room?", "6"),
            new Question(@"
                One book to rule them all,
                one book to find them,
                One book to bring them all,
                and in the room bind them...

                Page 746, Paragraph 3, Line 3, last Word", "basket"),
            new Question(@"
                Where does the Easter Bunny eat breakfast?", "IHOP"),
        };

        public EasterEscapeTheRoom() : base(_questions, "The Easter Bunny Is Real", 3) { }

        public override void ShowEditionWelcomeBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/ding.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(@"
 ____   __   ____  ____  ____  ____    ____  ____  __  ____  __  __   __ _ 
(  __) / _\ / ___)(_  _)(  __)(  _ \  (  __)(    \(  )(_  _)(  )/  \ (  ( \
 ) _) /    \\___ \  )(   ) _)  )   /   ) _)  ) D ( )(   )(   )((  O )/    /
(____)\_/\_/(____/ (__) (____)(__\_)  (____)(____/(__) (__) (__)\__/ \_)__)", System.ConsoleColor.Magenta);
        }
    }
}
