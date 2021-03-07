using System;
namespace Sprint0
{
    public class LinkAttackCommand: ICommand
    {
        private Sprint3 game;
        public LinkAttackCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            this.game.GetPlayer().getLinkStateMachine().setAttack();
        }
    }
}
