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

        private const int LINKDAMAGEVECTOR = 8;
        private const int ENEMYDAMAGEVECTOR = 6;

        public LinkEnemyHandler()
        {
        }

        public static void HandleCollision(IPlayer player, INPC enemy)
        {
            OverlapInRelationToPlayer overlap = GetOverlapDirection(player, enemy);

            if (enemy is Trap)
            {
                DamageThePlayer(player, ((IEnemy)enemy).GetDamageValue(), overlap);
            }
            else if (player.Attacking() && CheckAttackDirection(player, overlap))
            {
                DamageTheEnemy((IEnemy)enemy, player.GetMeleeDamage(), overlap);
            }
            else if (enemy is Wallmaster)
            {
                WallmasterCollisionHandler(player, (Wallmaster)enemy, overlap);
            }
            else if (!((IEnemy)enemy).IsDamaged())
            {
                DamageThePlayer(player, ((IEnemy)enemy).GetDamageValue(), overlap);
            }
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, INPC enemy)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle enemyPos = enemy.GetNPCLocation();
            Rectangle overlap = Rectangle.Intersect(playerPos, enemyPos);
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Left;

            if (overlap.Y == enemyPos.Y)  overlapY = OverlapInRelationToPlayer.Down;
            else if (overlap.Y == playerPos.Y) overlapY = OverlapInRelationToPlayer.Up;

            if (overlap.X == playerPos.X) overlapX = OverlapInRelationToPlayer.Left;
            else if (overlap.X == enemyPos.X) overlapX = OverlapInRelationToPlayer.Right;

            if (overlap.Height < overlap.Width) return overlapY;
            else return overlapX;
        }

        private static void WallmasterCollisionHandler(IPlayer player, Wallmaster wallmaster, OverlapInRelationToPlayer overlap)
        {
            Rectangle linkPos = player.LinkPosition();
            Rectangle wallPos = wallmaster.GetNPCLocation();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;

            if (wallmaster.CanGrab())
            {
                wallmaster.GrabPlayer();
            }

            if(!wallmaster.Grabbing())
            {
                DamageThePlayer(player, wallmaster.GetDamageValue(), overlap);
            }
            else
            {
                player.SetPosition(new Rectangle(wallPos.X, wallPos.Y, linkPos.Width, linkPos.Height));
            }

        }

        private static void DamageThePlayer(IPlayer player, int damage, OverlapInRelationToPlayer overlap)
        {
            Vector2 damageDirection = PlayerDamageVector(overlap);

            player.SetDamageState(damage, damageDirection);
        }

        private static void DamageTheEnemy(IEnemy enemy, int damage, OverlapInRelationToPlayer overlap)
        {
            Vector2 damageDirection = EnemyDamageVector(overlap);

            enemy.SetDamageState(damage, damageDirection);
        }

        private static Vector2 PlayerDamageVector(OverlapInRelationToPlayer overlap)
        {
            Vector2 up = new Vector2(0, -LINKDAMAGEVECTOR);
            Vector2 right = new Vector2(LINKDAMAGEVECTOR, 0);
            Vector2 down = new Vector2(0, LINKDAMAGEVECTOR);
            Vector2 left = new Vector2(-LINKDAMAGEVECTOR, 0);

            if(overlap == OverlapInRelationToPlayer.Up)
            {
                return down;
            }
            else if(overlap == OverlapInRelationToPlayer.Down)
            {
                return up;
            }
            else if (overlap == OverlapInRelationToPlayer.Left)
            {
                return right;
            }
            else
            {
                return left;
            }
        }

        private static Vector2 EnemyDamageVector(OverlapInRelationToPlayer overlap)
        {
            Vector2 up = new Vector2(0, -ENEMYDAMAGEVECTOR);
            Vector2 right = new Vector2(ENEMYDAMAGEVECTOR, 0);
            Vector2 down = new Vector2(0, ENEMYDAMAGEVECTOR);
            Vector2 left = new Vector2(-ENEMYDAMAGEVECTOR, 0);

            if (overlap == OverlapInRelationToPlayer.Up)
            {
                return up;
            }
            else if (overlap == OverlapInRelationToPlayer.Down)
            {
                return down;
            }
            else if (overlap == OverlapInRelationToPlayer.Left)
            {
                return left;
            }
            else
            {
                return right;
            }
        }

        private static bool CheckAttackDirection(IPlayer player, OverlapInRelationToPlayer overlap)
        {
            Direction dir = player.getLinkStateMachine().getDirection();

            return ((dir == Direction.Left && overlap == OverlapInRelationToPlayer.Left)
                || (dir == Direction.Right && overlap == OverlapInRelationToPlayer.Right)
                || (dir == Direction.Up && overlap == OverlapInRelationToPlayer.Up)
                || (dir == Direction.Down && overlap == OverlapInRelationToPlayer.Down));
        }
    }
}