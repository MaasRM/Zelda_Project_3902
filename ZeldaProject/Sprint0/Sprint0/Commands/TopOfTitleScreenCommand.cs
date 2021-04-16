using System;
namespace Sprint0
{
    public class TopOfTitleScreenCommand : ICommand
    {
        private Sprint5 game;
        public TopOfTitleScreenCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.TitleScreen().resetFrames();
        }
    }
}
