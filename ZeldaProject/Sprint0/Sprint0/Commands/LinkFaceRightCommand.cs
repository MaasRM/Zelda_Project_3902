using System;
namespace Sprint0
{
    public class LinkFaceRightCommand : ICommand
    {
        private Sprint3 game;
        public LinkFaceRightCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceRight();
        }
    }
}
