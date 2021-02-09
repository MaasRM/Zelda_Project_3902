using System;
namespace Sprint0
{
    public class LinkAttackCommand: ICommand
    {
        private Sprint2 game;
        public LinkAttackCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            this.game.getPlayer().getLinkStateMachine().setAttack();
        }
    }
}
