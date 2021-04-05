using System;
namespace Sprint0
{
    public class ResetGameCommand : ICommand
    {
        private Sprint3 game;
        public ResetGameCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
            using (var game = new Sprint3())
                game.Run();
        }
    }
}