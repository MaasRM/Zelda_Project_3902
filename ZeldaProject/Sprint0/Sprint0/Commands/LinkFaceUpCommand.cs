using System;
namespace Sprint0
{
    public class LinkFaceUpCommand : ICommand
    {
        private Sprint3 game;
        public LinkFaceUpCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceUp();
        }
    }
}
