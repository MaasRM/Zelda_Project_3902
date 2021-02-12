using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseItemCommand : ICommand
    {
        private Sprint2 game;
        public LinkUseItemCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute(int item)
        {
            game.GetPlayer().getLinkStateMachine().setUseItem();
            //Create item corresponding to param
        }
    }
}
