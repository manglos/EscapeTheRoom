using System.Collections.Generic;
using System.Drawing;
using System.Media;

namespace EscapeTheRoomConsole.Editions
{
    public class EasterEdition : Edition
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question("What is 1?", "1"),
            new Question("What is 2?", "2"),
            new Question("What is 3?", "3"),
        };

        public EasterEdition() : base(_questions, "The Easter Bunny Is Real", 3) { }

        public override void ShowEditionWelcomeBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/ding.wav");
            soundPlayer.Play();
            Colorful.Console.WriteLine(@"
 ____   __   ____  ____  ____  ____    ____  ____  __  ____  __  __   __ _ 
(  __) / _\ / ___)(_  _)(  __)(  _ \  (  __)(    \(  )(_  _)(  )/  \ (  ( \
 ) _) /    \\___ \  )(   ) _)  )   /   ) _)  ) D ( )(   )(   )((  O )/    /
(____)\_/\_/(____/ (__) (____)(__\_)  (____)(____/(__) (__) (__)\__/ \_)__)", Color.HotPink);
        }
    }
}
