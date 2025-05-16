using System.Collections.Generic;

namespace EscapeTheRoomConsole.Games
{
    public abstract class EggScavengerHunt : ScavengerHunt
    {
        protected EggScavengerHunt(List<Question> riddles, string finalRiddle, int maximumIncorrectAllowed) : base(riddles, maximumIncorrectAllowed, "egg")
        {
        }
    }
}
