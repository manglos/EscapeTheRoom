
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace EscapeTheRoomConsole.Games
{
    public class Easter2022ScavengerHunt : EggScavengerHunt
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question(@"
                Some games are fun
                while others seem cursed.
                This game, by far,
                is definitely the worst.", "We"),
            new Question(@"
                You can gather around me
                the whole family together,
                and though I am hot
                I'm not great in cold weather.", "love"),
            new Question(@"
                When it's cold out, don't forget
                Your hat and mittens.
                This also could be
                a bed for a kitten.", "our"),
            new Question(@"
                I'm out here all day
                and all through the night.
                I have teeth, 
                but I don't bite.
                I have four legs, 
                but zero bones.
                My friend and I protect you
                when you are at home.", "amazing"),
            new Question(@"
                When it comes to decorations,
                I'm a one-stop-shop.
                But I have to admit:
                it's lonely at the top.", "daughters"),
        };
        private static string _finalRiddle = @"
                Turn me on when you leave
                and off when you arrive.
                I have four wheels...
                No wait! I have five.";

        public Easter2022ScavengerHunt() : base(_questions, _finalRiddle, 5) { }

        public override void ShowEditionWelcomeBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/yay.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(@"
                 ____   __   ____  ____  ____  ____    ____  ____  __  ____  __  __   __ _ 
                (  __) / _\ / ___)(_  _)(  __)(  _ \  (  __)(    \(  )(_  _)(  )/  \ (  ( \
                 ) _) /    \\___ \  )(   ) _)  )   /   ) _)  ) D ( )(   )(   )((  O )/    /
                (____)\_/\_/(____/ (__) (____)(__\_)  (____)(____/(__) (__) (__)\__/ \_)__)", System.ConsoleColor.Magenta);
            Thread.Sleep(2000);
        }

    }
}
