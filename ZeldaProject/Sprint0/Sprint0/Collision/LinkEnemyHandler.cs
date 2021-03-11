using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class LinkEnemyHandler
    {
        public LinkEnemyHandler()
        {
            
        }

        public static void HandleCollision(IPlayer player, IEnemy enemy)
        {
            if(enemy is Wallmaster)
            {
                PlayerWallmasterCollisionHandler(player, (Wallmaster)enemy);
            }
            else if(enemy is Trap)
            {
                player.Damage();
            }
        }

        private static void PlayerWallmasterCollisionHandler(IPlayer player, Wallmaster wallmaster)
        {
            Rectangle linkPos = player.LinkPosition();
            Rectangle wallPos = wallmaster.GetNPCLocation();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;

            if (!player.Attacking())
            {
                if (!wallmaster.Grabbing() && linkX >= wallPos.X && linkX < wallPos.X + wallPos.Width && linkY > wallPos.Y && linkY < wallPos.Y + wallPos.Height)
                {
                    wallmaster.GrabPlayer();
                }
                else
                {
                    player.SetPosition(new Rectangle(wallPos.X, wallPos.Y, linkPos.Width, linkPos.Height));
                    player.MakeImmobile();
                }
            }
            else
            {
                //Wallmaster damage
            }
        }
    }
}