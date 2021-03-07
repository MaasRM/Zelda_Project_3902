using System;
namespace Sprint0
{
    public class LinkFaceLeftCommand : ICommand
    {
        private Sprint3 game;
        public LinkFaceLeftCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceLeft();
        }
    }
}
