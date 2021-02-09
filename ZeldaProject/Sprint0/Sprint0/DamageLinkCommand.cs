using System;
namespace Sprint0
{
    public class DamageLinkCommand : ICommand
    {
        private Sprint2 game;
        public DamageLinkCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            this.game.getPlayer().getLinkStateMachine().setDamaged();
        }
    }
}
