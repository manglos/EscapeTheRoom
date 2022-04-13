
using System.Collections.Generic;
using System.Drawing;
using System.Media;

namespace EscapeTheRoomConsole.Games
{
    public class EasterScavengerHunt : ScavengerHunt
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question(@"
                Type 1", "1"),
            new Question(@"
                Type 2", "2"),
            new Question(@"
                Type 3", "3"),
        };
        private static string _finalRiddle = @"
                Go to the place where... something something";

        public EasterScavengerHunt() : base(_questions, _finalRiddle, 5) { }

        public override void ShowEditionWelcomeBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/yay.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(@"
                 ____   __   ____  ____  ____  ____    ____  ____  __  ____  __  __   __ _ 
                (  __) / _\ / ___)(_  _)(  __)(  _ \  (  __)(    \(  )(_  _)(  )/  \ (  ( \
                 ) _) /    \\___ \  )(   ) _)  )   /   ) _)  ) D ( )(   )(   )((  O )/    /
                (____)\_/\_/(____/ (__) (____)(__\_)  (____)(____/(__) (__) (__)\__/ \_)__)", System.ConsoleColor.Magenta);
        }

    }
}
