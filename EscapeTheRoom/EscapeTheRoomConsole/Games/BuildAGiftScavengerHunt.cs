using System.Collections.Generic;

namespace EscapeTheRoomConsole.Games
{
    public abstract class BuildAGiftScavengerHunt : ScavengerHunt
    {
        protected BuildAGiftScavengerHunt(List<Question> riddles, string finalRiddle, int maximumIncorrectAllowed) : base(riddles, maximumIncorrectAllowed, "gift")
        {
        }
    }
}
