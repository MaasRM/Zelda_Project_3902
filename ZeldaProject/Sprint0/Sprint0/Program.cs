using System;

namespace Sprint0
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Sprint0())
                game.Run();
        }
    }
}
