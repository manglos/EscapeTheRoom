using System.Collections.Generic;

namespace EscapeTheRoomConsole.Games
{
    public abstract class EnvelopeScavengerHunt : ScavengerHunt
    {
        protected EnvelopeScavengerHunt(List<Question> riddles, string finalRiddle, int maximumIncorrectAllowed) : base(riddles, maximumIncorrectAllowed, "envelope")
        {
        }
    }
}
