using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class LinkEnemyHandler
    {
        private enum OverlapInRelationToPlayer
        {
            Up,
            Right,
            Down,
            Left
        };

        public LinkEnemyHandler()
        {
            
        }

        public static void HandleCollision(IPlayer player, INPC enemy)
        {
            OverlapInRelationToPlayer overlap = GetOverlapDirection(player, enemy);

            if(enemy is Trap)
            {
                DamageThePlayer(player);
            }
            else if(player.Attacking())
            {
                PlayerAttackingCollisionHandler(player, enemy);
            }
            else if(enemy is Wallmaster)
            {
                WallmasterCollisionHandler(player, (Wallmaster) enemy);
            }
            else
            {
                DamageThePlayer(player);
            }
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, INPC enemy)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle enemyPos = enemy.GetNPCLocation();
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Left;

            int yOverDist = 0, xOverDist = 0;

            if(playerPos.Y < enemyPos.Y + enemyPos.Height && playerPos.Y >= enemyPos.Y)
            {
                yOverDist = enemyPos.Y + enemyPos.Height - playerPos.Y;
                overlapY = OverlapInRelationToPlayer.Up;
            }
            if (enemyPos.Y < playerPos.Y + playerPos.Height && enemyPos.Y >= playerPos.Y)
            {
                yOverDist = playerPos.Y + playerPos.Height - enemyPos.Y;
                overlapY = OverlapInRelationToPlayer.Down;
            }
            if (playerPos.X < enemyPos.X + enemyPos.Width && playerPos.X >= enemyPos.X)
            {
                xOverDist = enemyPos.X + enemyPos.Width - playerPos.X;
                overlapY = OverlapInRelationToPlayer.Right;
            }
            if (enemyPos.X < playerPos.X + playerPos.Width && enemyPos.X >= playerPos.X)
            {
                xOverDist = playerPos.X + playerPos.Width - enemyPos.X;
                overlapY = OverlapInRelationToPlayer.Left;
            }

            if(yOverDist > xOverDist)
            {
                return overlapY;
            }
            else
            {
                return overlapX;
            }
        }

        private static void PlayerAttackingCollisionHandler(IPlayer player, INPC enemy)
        {

        }

        private static void WallmasterCollisionHandler(IPlayer player, Wallmaster wallmaster)
        {
            Rectangle linkPos = player.LinkPosition();
            Rectangle wallPos = wallmaster.GetNPCLocation();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;

            if (!wallmaster.Grabbing() && linkX >= wallPos.X && linkX < wallPos.X + wallPos.Width && linkY > wallPos.Y && linkY < wallPos.Y + wallPos.Height)
            {
                wallmaster.GrabPlayer();
            }
            player.SetPosition(new Rectangle(wallPos.X, wallPos.Y, linkPos.Width, linkPos.Height));
            player.MakeImmobile();
        }

        private static void DamageThePlayer(IPlayer player)
        {
            
        }

        private static void DamageTheEnemy(INPC enemy)
        {

        }

        private Vector2 PlayerDamageVector(IPlayer Player)
        {
            Vector2 up = new Vector2(0, -3);
            Vector2 right = new Vector2(3, 0);
            Vector2 down = new Vector2(0, 3);
            Vector2 left = new Vector2(-3, 0);

            return up;
        }
    }
}