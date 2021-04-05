using System;
namespace Sprint0
{
    public class ResetGameCommand : ICommand
    {
        private Sprint4 game;
        public ResetGameCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
            using (var game = new Sprint4())
                game.Run();
        }
    }
}