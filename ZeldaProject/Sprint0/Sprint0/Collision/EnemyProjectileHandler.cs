using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class EnemyProjectileHandler
    {
        private enum OverlapInRelationToEnemy
        {
            Up,
            Right,
            Down,
            Left
        };

        public EnemyProjectileHandler()
        {
        }

        public static void HandleCollision(INPC enemy, IProjectile projectile)
        {
            OverlapInRelationToEnemy overlap = GetOverlapDirection(enemy, projectile);

            if (projectile is BombProjectile && ((BombProjectile)projectile).Exploding())
            {
                DamageTheEnemy((IEnemy)enemy, projectile, overlap);
            }
            else if (projectile is IBoomerang)
            {
                if (enemy is Keese || enemy is Gel)
                {
                    DamageTheEnemy((IEnemy)enemy, projectile, overlap);
                }
                else
                {
                    StunEnemy((IEnemy)enemy);
                }

                ((IBoomerang)projectile).GoBack();
            }
            else
            {
                DamageTheEnemy((IEnemy)enemy, projectile, overlap);
            }

            projectile.Hit();
        }

        private static OverlapInRelationToEnemy GetOverlapDirection(INPC enemy, IProjectile projectile)
        {
            Rectangle projectilePos = projectile.GetProjectileLocation();
            Rectangle enemyPos = enemy.GetNPCLocation();
            Rectangle overlap = Rectangle.Intersect(enemyPos, projectilePos);
            OverlapInRelationToEnemy overlapX = OverlapInRelationToEnemy.Right;
            OverlapInRelationToEnemy overlapY = OverlapInRelationToEnemy.Left;

            if (overlap.Y == projectilePos.Y)
            {
                overlapY = OverlapInRelationToEnemy.Down;
            }
            else if (overlap.Y == enemyPos.Y)
            {
                overlapY = OverlapInRelationToEnemy.Up;
            }

            if (overlap.X == enemyPos.X)
            {
                overlapX = OverlapInRelationToEnemy.Left;
            }
            else if (overlap.X == projectilePos.X)
            {
                overlapX = OverlapInRelationToEnemy.Right;
            }

            if (overlap.Height < overlap.Width)
            {
                return overlapY;
            }
            else
            {
                return overlapX;
            }
        }

        private static void DamageTheEnemy(IEnemy enemy, IProjectile projectile, OverlapInRelationToEnemy overlap)
        {
            Vector2 damageDirection = EnemyDamageVector(overlap);

            enemy.SetDamageState(projectile.GetDamage(), damageDirection);
        }

        private static Vector2 EnemyDamageVector(OverlapInRelationToEnemy overlap)
        {
            Vector2 up = new Vector2(0, -3);
            Vector2 right = new Vector2(3, 0);
            Vector2 down = new Vector2(0, 3);
            Vector2 left = new Vector2(-3, 0);

            if (overlap == OverlapInRelationToEnemy.Down)
            {
                return up;
            }
            else if (overlap == OverlapInRelationToEnemy.Up)
            {
                return down;
            }
            else if (overlap == OverlapInRelationToEnemy.Right)
            {
                return left;
            }
            else
            {
                return right;
            }
        }

        private static void StunEnemy(IEnemy enemy)
        {
            enemy.Stun();
        }
    }
}
