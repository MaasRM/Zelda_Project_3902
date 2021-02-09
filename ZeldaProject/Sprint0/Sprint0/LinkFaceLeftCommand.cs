using System;
namespace Sprint0
{
    public class LinkFaceLeftCommand : ICommand
    {
        private Sprint2 game;
        public LinkFaceLeftCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.getPlayer().getLinkStateMachine().faceLeft();
            game.getPlayer().getLinkStateMachine().changeXLocation(-5);
        }
    }
}
