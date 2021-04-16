using System;
namespace Sprint0
{
    public class StartGameCommand : ICommand
    {
        private Sprint4 game;
        public StartGameCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.startGame();
            game.GetSongManager().Overworld();
        }
    }
}
