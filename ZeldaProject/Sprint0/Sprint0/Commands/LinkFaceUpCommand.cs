using System;
namespace Sprint0
{
    public class LinkFaceUpCommand : ICommand
    {
        private Sprint5 game;
        public LinkFaceUpCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().Move(Direction.Up);
        }
    }
}
