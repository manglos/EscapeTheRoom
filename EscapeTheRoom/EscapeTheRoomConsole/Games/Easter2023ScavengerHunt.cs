
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace EscapeTheRoomConsole.Games
{
    public class Easter2023ScavengerHunt : EnvelopeScavengerHunt
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question(@"
                A tiger hunts the man
                Or is it the other way around
                Either way, he stares at me
                In a room of sound", "You"),
            new Question(@"
                I rest when it's sunny
                I work when it rains
                It's a thankless job to be sure
                In fact it's a drain", "make"),
            new Question(@"
                I'm ready for a trip
                Try hard now to think
                I'm going to stowaway
                Where the children keep their drinks", "us"),
            new Question(@"
                I admit I can get loud
                And I'm not working quite right
                In a room of rest
                Simply come to the light", "so"),
            new Question(@"
                Be careful who you say it to
                Lots of ignorants around, but
                Maybe you're the exception?
                ^
                ^
                ^
                (sometimes it's not the question that's important,
                but the way it's asked)", "proud"),
        };

        private static string _finalRiddle = @"
                We've always been best friends
                We're birds of a feather
                So we made a nest
                Where you prepare for cold weather";

        public Easter2023ScavengerHunt() : base(_questions, _finalRiddle, 5) { }

        public override void ShowEditionWelcomeBanner()
        {
            var soundPlayer = new SoundPlayer("Sounds/yay.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(@"
                 _____         _              ___ ___ ___ ___    _____   _ _ _   _         
                |   __|___ ___| |_ ___ ___   |_  |   |_  |_  |  |   __|_| |_| |_|_|___ ___ 
                |   __| .'|_ -|  _| -_|  _|  |  _| | |  _|_  |  |   __| . | |  _| | . |   |
                |_____|__,|___|_| |___|_|    |___|___|___|___|  |_____|___|_|_| |_|___|_|_|
                                                                                           ", System.ConsoleColor.Green);
            Thread.Sleep(2000);
        }

    }
}
