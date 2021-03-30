using EscapeTheRoomConsole.Editions;

namespace EscapeRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new EasterEdition();
            game.Run();
        }
    }
}
