using System;
namespace Sprint0
{
    public class DamageLinkCommand : ICommand
    {
        private Sprint3 game;
        public DamageLinkCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setDamaged();
        }
    }
}
