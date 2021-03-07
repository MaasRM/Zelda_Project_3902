using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class AllCollisionHandler
    {
        private Tuple<IPlayer, List<IBlock>, List<IItem>, List<INPC>, List<IProjectile>> gameObjects;

        public AllCollisionHandler(Tuple<IPlayer, List<IBlock>, List<IItem>, List<INPC>, List<IProjectile>> obs)
        {
            gameObjects = obs;
        }
    }
}