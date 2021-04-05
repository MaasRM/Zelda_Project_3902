using System;
namespace Sprint0
{
    public class LinkFaceUpCommand : ICommand
    {
        private Sprint4 game;
        public LinkFaceUpCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceUp();
        }
    }
}
