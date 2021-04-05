using System;
namespace Sprint0
{
    public class LinkFaceLeftCommand : ICommand
    {
        private Sprint4 game;
        public LinkFaceLeftCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceLeft();
        }
    }
}
