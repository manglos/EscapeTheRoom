
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace EscapeTheRoomConsole.Games
{
    public class Easter2024ScavengerHunt : EggScavengerHunt
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question(@"
                You only notice me
                when I don't work.
                But when I'm broken
                I can be a jerk.

                If I want your attention,
                I'm out for blood.
                Treat me right
                Or you'll get a flood.
                ", "We"),

            new Question(@"
                If I tell you what I hold
                I'd give myself away,
                and that wouldn't be any fun.
                So... let's play!

                Instead, I'll tell you the opposite
                And here is my tale
                What I definitely don't hold...
                ...is femail.
                ", "love"),

            new Question(@"
                Everyone is a joker
                Always making yuk yuks

                Saying that I blow
                Or worse, that I suck
                ", "you"),

            new Question(@"
                I have one purpose in life
                and it's one I hold dear.
                Without me, you'd find it difficult
                To raise holiday cheer.

                Like the carrot and stick, this riddle
                is meant to dangle.
                I'm round, yes,
                But my best friend's a triangle.
                
                ", "automatically"),

            new Question(@"
                 
                ", "dudes")

        };

        private static string _finalRiddle = @"
                It's really dark down here.
                Under the wheres??
    
                Not under the stars
                But under the...";

        public Easter2024ScavengerHunt() : base(_questions, _finalRiddle, 5) { }

        public override void ShowEditionWelcomeBanner()
        {
            ColorfulConsole.Clear();
            var soundPlayer = new SoundPlayer("Sounds/oh yeah.wav");
            soundPlayer.Play();
            ColorfulConsole.WriteLine(@"
                 _______     ___           _______.___________. _______ .______      
                |   ____|   /   \         /       |           ||   ____||   _  \     
                |  |__     /  ^  \       |   (----`---|  |----`|  |__   |  |_)  |    
                |   __|   /  /_\  \       \   \       |  |     |   __|  |      /     
                |  |____ /  _____  \  .----)   |      |  |     |  |____ |  |\  \----.
                |_______/__/     \__\ |_______/       |__|     |_______|| _| `._____|
                                                                                     
                                 ___     ___    ___    _  _                                          
                                |__ \   / _ \  |__ \  | || |                                         
                                   ) | | | | |    ) | | || |_                                        
                                  / /  | | | |   / /  |__   _|                                       
                                 / /_  | |_| |  / /_     | |                                         
                                |____|  \___/  |____|    |_|                                         
                                                                                     
                 _______  _______   __  .___________. __    ______   .__   __.       
                |   ____||       \ |  | |           ||  |  /  __  \  |  \ |  |       
                |  |__   |  .--.  ||  | `---|  |----`|  | |  |  |  | |   \|  |       
                |   __|  |  |  |  ||  |     |  |     |  | |  |  |  | |  . `  |       
                |  |____ |  '--'  ||  |     |  |     |  | |  `--'  | |  |\   |       
                |_______||_______/ |__|     |__|     |__|  \______/  |__| \__|       
                                                                                ", System.ConsoleColor.Magenta);
            Thread.Sleep(2000);
        }

    }
}
