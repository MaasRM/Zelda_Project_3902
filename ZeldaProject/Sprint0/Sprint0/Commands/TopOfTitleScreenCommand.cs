using System;
namespace Sprint0
{
    public class TopOfTitleScreenCommand : ICommand
    {
        private Sprint4 game;
        public TopOfTitleScreenCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.TitleScreen().resetFrames();
        }
    }
}
