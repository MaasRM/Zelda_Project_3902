using System;
namespace Sprint0
{
    public class ResetGameCommand : ICommand
    {
        private Sprint2 game;
        public ResetGameCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            using (var game = new Sprint2())
                game.Run();
        }
    }
}