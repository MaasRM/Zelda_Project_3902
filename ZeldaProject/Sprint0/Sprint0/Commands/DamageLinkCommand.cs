using System;
namespace Sprint0
{
    public class DamageLinkCommand : ICommand
    {
        private Sprint4 game;
        public DamageLinkCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setDamaged();
        }
    }
}
