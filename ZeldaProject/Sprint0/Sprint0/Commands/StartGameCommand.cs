using System;
namespace Sprint0
{
    public class StartGameCommand : ICommand
    {
        private Sprint5 game;
        public StartGameCommand(Sprint5 sprint)
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
