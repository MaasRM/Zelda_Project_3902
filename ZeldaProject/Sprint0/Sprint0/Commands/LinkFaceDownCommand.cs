using System;
namespace Sprint0
{
    public class LinkFaceDownCommand : ICommand
    {
        private Sprint3 game;
        public LinkFaceDownCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceDown();
        }
    }
}
