using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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

        private const int DAMAGEVECTORSIZE = 8;
        private const int RECOILVECTORSIZE = 2;

        public LinkProjectileHandler()
        {
        }

        public static void HandleCollision(IPlayer player, IProjectile projectile, SoundEffectInstance deflected)
        {
            OverlapInRelationToPlayer overlap = GetOverlapDirection(player, projectile);

            if (!player.Attacking() && CheckPlayerDirection(player, overlap))
            {
                if(projectile is AquamentusFireball || projectile is GohmaFireball || projectile is WizzrobeMagic)
                {
                    DamageThePlayer(player, projectile, overlap);
                }
                else
                {
                    deflected.Play();
                    if (projectile is IBoomerang) ((IBoomerang)projectile).GoBack();
                    else DeflectProjectile(projectile, overlap);
                }
            }
            else DamageThePlayer(player, projectile, overlap);

            projectile.Hit();
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, IProjectile projectile)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle projPos = projectile.GetProjectileLocation();
            Rectangle overlap = Rectangle.Intersect(playerPos, projPos);
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Left;

            if (overlap.Y == projPos.Y) overlapY = OverlapInRelationToPlayer.Down;
            else if (overlap.Y == playerPos.Y) overlapY = OverlapInRelationToPlayer.Up;

            if (overlap.X == playerPos.X) overlapX = OverlapInRelationToPlayer.Left;
            else if (overlap.X == projPos.X) overlapX = OverlapInRelationToPlayer.Right;

            if (overlap.Height < overlap.Width) return overlapY;
            else return overlapX;
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
            Vector2 up = new Vector2(0, -DAMAGEVECTORSIZE);
            Vector2 right = new Vector2(DAMAGEVECTORSIZE, 0);
            Vector2 down = new Vector2(0, DAMAGEVECTORSIZE);
            Vector2 left = new Vector2(-DAMAGEVECTORSIZE, 0);

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
            Vector2 up = new Vector2(0, -RECOILVECTORSIZE);
            Vector2 right = new Vector2(RECOILVECTORSIZE, 0);
            Vector2 down = new Vector2(0, RECOILVECTORSIZE);
            Vector2 left = new Vector2(-RECOILVECTORSIZE, 0);

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

            return ((dir == Direction.Left && overlap == OverlapInRelationToPlayer.Left)
                || (dir == Direction.Right && overlap == OverlapInRelationToPlayer.Right)
                || (dir == Direction.Up && overlap == OverlapInRelationToPlayer.Up)
                || (dir == Direction.Down && overlap == OverlapInRelationToPlayer.Down));
        }
    }
}
