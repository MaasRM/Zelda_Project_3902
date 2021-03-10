using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class LinkItemHandler
    {
        private IPlayer link;
        private IItem itemToAdd

        public LinkItemHandler(IPlayer player, IItem item)
        {
            link = player;
            itemToAdd = item;
        }
    }
}