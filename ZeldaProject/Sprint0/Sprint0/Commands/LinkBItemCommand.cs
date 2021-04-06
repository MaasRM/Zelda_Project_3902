using System;
namespace Sprint0
{
    public class LinkBItemCommand : ICommand
    {
        private Sprint4 game;
        public LinkBItemCommand(Sprint4 sprint)
        {
            this.game = sprint;
        }

        public void Execute()
        {
            IItem item = game.GetPlayer().GetLinkInventory().currentItem;
            ICommand command;

            if (item is BombItem)
            {
                command = new LinkUseBombCommand(game);
                command.Execute();
            }
            else if (item is BoomerangItem)
            {
                command = new LinkUseBrownBoomerangCommand(game);
                command.Execute();
            }
            else if (item is BowItem)
            {
                command = new LinkUseBrownArrowCommand(game);
                command.Execute();
            }
        }
    }
}