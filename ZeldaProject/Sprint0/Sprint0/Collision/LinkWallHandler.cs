using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class LinkWallHandler
    {
        static IPlayer player;
        static int maxX;
        static int maxY;

        public LinkWallHandler(IPlayer link, int x, int y)
        {
            player = link;
            maxX = x;
            maxY = y;
        }

        public static void HandleLeftWall()
        {
            Rectangle newPosition = new Rectangle (120, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
            player.getLinkStateMachine().SetPositions(newPosition);
        }

        public static void HandleTopWall()
        {
            Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), 117, player.LinkPosition().Width, player.LinkPosition().Height);
            player.getLinkStateMachine().SetPositions(newPosition);
        }

        public static void HandleRightWall()
        {
            Rectangle newPosition = new Rectangle(maxX - 175, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
            player.getLinkStateMachine().SetPositions(newPosition);
        }

        public static void HandleBottomWall()
        {
            Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY-185, player.LinkPosition().Width, player.LinkPosition().Height);
            player.getLinkStateMachine().SetPositions(newPosition);
        }
    }
}