using System.Collections.Generic;

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

        public EasterEdition() : base(_questions, 3) { }

        public override string GetEditionWelcomeBanner()
        {
            return @"
 ____   __   ____  ____  ____  ____    ____  ____  __  ____  __  __   __ _ 
(  __) / _\ / ___)(_  _)(  __)(  _ \  (  __)(    \(  )(_  _)(  )/  \ (  ( \
 ) _) /    \\___ \  )(   ) _)  )   /   ) _)  ) D ( )(   )(   )((  O )/    /
(____)\_/\_/(____/ (__) (____)(__\_)  (____)(____/(__) (__) (__)\__/ \_)__)";
        }
    }
}
