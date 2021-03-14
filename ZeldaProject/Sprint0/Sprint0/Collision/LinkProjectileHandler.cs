using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class LinkProjectileHandler
    {
        private enum OverlapInRelationToPlayer
        {
            Up,
            Right,
            Down,
            Left
        };

        public LinkProjectileHandler()
        {
        }

        public static void HandleCollision(IPlayer player, IProjectile projectile)
        {
            OverlapInRelationToPlayer overlap = GetOverlapDirection(player, projectile);

            if (!player.Attacking() && CheckPlayerDirection(player, overlap))
            {
                if(projectile is AquamentusFireball)
                {
                    DamageThePlayer(player, projectile, overlap);
                }
                else
                {
                    DeflectProjectile(projectile, overlap);
                }
            }
            else
            {
                DamageThePlayer(player, projectile, overlap);
            }
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, IProjectile projectile)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle projPos = projectile.GetProjectileLocation();
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Left;

            int yOverDist = 0, xOverDist = 0;

            if (playerPos.Y < projPos.Y + projPos.Height && playerPos.Y >= projPos.Y)
            {
                yOverDist = projPos.Y + projPos.Height - playerPos.Y;
                overlapY = OverlapInRelationToPlayer.Up;
            }
            if (projPos.Y < playerPos.Y + playerPos.Height && projPos.Y >= playerPos.Y)
            {
                yOverDist = playerPos.Y + playerPos.Height - projPos.Y;
                overlapY = OverlapInRelationToPlayer.Down;
            }
            if (playerPos.X < projPos.X + projPos.Width && playerPos.X >= projPos.X)
            {
                xOverDist = projPos.X + projPos.Width - playerPos.X;
                overlapY = OverlapInRelationToPlayer.Right;
            }
            if (projPos.X < playerPos.X + playerPos.Width && projPos.X >= playerPos.X)
            {
                xOverDist = playerPos.X + playerPos.Width - projPos.X;
                overlapY = OverlapInRelationToPlayer.Left;
            }

            if (yOverDist > xOverDist)
            {
                return overlapY;
            }
            else
            {
                return overlapX;
            }
        }

        private static void DamageThePlayer(IPlayer player, IProjectile projectile, OverlapInRelationToPlayer overlap)
        {
            Vector2 damageDirection = PlayerDamageVector(overlap);

            player.SetDamageState(projectile.GetDamage(), damageDirection);
        }

        private static void DeflectProjectile(IProjectile projectile, OverlapInRelationToPlayer overlap)
        {
            Vector2 deflectorDirection = ProjectileDeflectionVector(overlap);

            ((IEnemyProjectile)projectile).Deflect(deflectorDirection);
        }

        private static Vector2 PlayerDamageVector(OverlapInRelationToPlayer overlap)
        {
            Vector2 up = new Vector2(0, -3);
            Vector2 right = new Vector2(3, 0);
            Vector2 down = new Vector2(0, 3);
            Vector2 left = new Vector2(-3, 0);

            if (overlap == OverlapInRelationToPlayer.Up)
            {
                return down;
            }
            else if (overlap == OverlapInRelationToPlayer.Down)
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

        private static Vector2 ProjectileDeflectionVector(OverlapInRelationToPlayer overlap)
        {
            Vector2 up = new Vector2(0, -2);
            Vector2 right = new Vector2(2, 0);
            Vector2 down = new Vector2(0,2);
            Vector2 left = new Vector2(-2, 0);

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

        private static bool CheckPlayerDirection(IPlayer player, OverlapInRelationToPlayer overlap)
        {
            Direction dir = player.getLinkStateMachine().getDirection();

            return ((dir == Direction.MoveLeft && overlap == OverlapInRelationToPlayer.Left)
                || (dir == Direction.MoveRight && overlap == OverlapInRelationToPlayer.Right)
                || (dir == Direction.MoveUp && overlap == OverlapInRelationToPlayer.Up)
                || (dir == Direction.MoveDown && overlap == OverlapInRelationToPlayer.Down));
        }
    }
}
