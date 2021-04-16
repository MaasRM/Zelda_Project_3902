using System;
namespace Sprint0
{
    public class DamageLinkCommand : ICommand
    {
        private Sprint5 game;
        public DamageLinkCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setColor(LinkColor.Damaged);
        }
    }
}
