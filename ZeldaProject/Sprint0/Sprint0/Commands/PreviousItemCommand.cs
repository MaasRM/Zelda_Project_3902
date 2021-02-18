using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class PreviousItemCommand : ICommand
    {
        private Sprint2 game;
        private List<IItem> items;
        public PreviousItemCommand(Sprint2 sprint)
        {
            game = sprint;
            items = new List<IItem>();
            items.Add(new BlueRupeeItem(new Rectangle(500, 100, 24, 48), new Rectangle(72, 16, 8, 16), game.GetItemSpriteSheet()));
            items.Add(new BombItem(new Rectangle(500, 100, 24, 42), new Rectangle(136, 0, 8, 14), game.GetItemSpriteSheet()));
            items.Add(new BoomerangItem(new Rectangle(500, 100, 15, 24), new Rectangle(129, 3, 5, 8), game.GetItemSpriteSheet()));
            items.Add(new BowItem(new Rectangle(500, 100, 24, 48), new Rectangle(144, 0, 8, 16), game.GetItemSpriteSheet()));
            items.Add(new ClockItem(new Rectangle(500, 100, 33, 48), new Rectangle(58, 0, 11, 16), game.GetItemSpriteSheet()));
            items.Add(new CompassItem(new Rectangle(500, 100, 33, 36), new Rectangle(258, 1, 11, 12), game.GetItemSpriteSheet()));
            items.Add(new FairyItem(new Rectangle(500, 100, 24, 48), new Rectangle(40, 0, 8, 16), game.GetItemSpriteSheet()));
            items.Add(new HeartContainerItem(new Rectangle(500, 100, 39, 39), new Rectangle(25, 1, 13, 13), game.GetItemSpriteSheet()));
            items.Add(new HeartItem(new Rectangle(500, 100, 21, 24), new Rectangle(0, 0, 7, 8), game.GetItemSpriteSheet()));
            items.Add(new KeyItem(new Rectangle(500, 100, 24, 48), new Rectangle(240, 0, 8, 16), game.GetItemSpriteSheet()));
            items.Add(new MapItem(new Rectangle(500, 100, 24, 48), new Rectangle(88, 0, 8, 16), game.GetItemSpriteSheet()));
            items.Add(new TriforceShardItem(new Rectangle(500, 100, 30, 48), new Rectangle(275, 3, 10, 16), game.GetItemSpriteSheet()));
            items.Add(new YellowRupeeItem(new Rectangle(500, 100, 24, 48), new Rectangle(72, 0, 8, 16), game.GetItemSpriteSheet()));
            items.Add(new Fire(new Rectangle(500, 100, 16, 16), new Rectangle(52, 11, 16, 16), game.GetNPCSpriteSheet()));
        }

        public void Execute()
        {
            int index = game.GetItemIndex();
            index--;
            if (index < 0)
            {
                index = items.Count - 1;
            }

            game.SetItem(items[index]);
            game.SetItemIndex(index);
        }
    }
}
