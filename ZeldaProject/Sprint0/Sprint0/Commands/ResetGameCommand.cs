using System;
namespace Sprint0
{
    public class ResetGameCommand : ICommand
    {
        private Sprint5 game;
        public ResetGameCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
            using (var game = new Sprint5())
                game.Run();
        }
    }
}