﻿using System;
namespace Sprint0
{
    public class LinkBItemCommand : ICommand
    {
        private Sprint5 game;
        public LinkBItemCommand(Sprint5 sprint)
        {
            this.game = sprint;
        }

        public void Execute()
        {
            IItem item = game.GetPlayer().GetLinkInventory().currentItem;
            ICommand command = new NothingCommand(game);

            if (item is BombItem)
            {
                command = new LinkUseBombCommand(game);
            }
            else if (item is BoomerangItem)
            {
                command = new LinkUseBrownBoomerangCommand(game);
            }
            else if (item is BlueBoomerangItem)
            {
                command = new LinkUseBlueBoomerangCommand(game);
            }
            else if (item is BowItem)
            {
                command = new LinkUseBrownArrowCommand(game);
            }
            else if (item is BlueArrowItem)
            {
                command = new LinkUseBlueArrowCommand(game);
            }
            else if (item is CandleItem)
            {
                command = new LinkUseCandleCommand(game);
            }
            else if (item is RecorderItem)
            {
                command = new LinkUseRecorderCommand(game);
            }

            command.Execute();
        }
    }
}