using System.Collections.Generic;

namespace EscapeTheRoomConsole.Games
{
    public abstract class BdayScavengerHunt : ScavengerHunt
    {
        protected BdayScavengerHunt(List<Question> riddles, int maximumIncorrectAllowed) : base(riddles, maximumIncorrectAllowed, "gift")
        {
        }
    }
}
