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
            OverlapInRelationToEnemy overlapX = OverlapInRelationToEnemy.Right;
            OverlapInRelationToEnemy overlapY = OverlapInRelationToEnemy.Left;

            int yOverDist = 0, xOverDist = 0;

            if (enemyPos.Y < projectilePos.Y + projectilePos.Height && enemyPos.Y >= projectilePos.Y)
            {
                yOverDist = projectilePos.Y + projectilePos.Height - enemyPos.Y;
                overlapY = OverlapInRelationToEnemy.Up;
            }
            if (enemyPos.Y < enemyPos.Y + enemyPos.Height && projectilePos.Y >= enemyPos.Y)
            {
                yOverDist = enemyPos.Y + enemyPos.Height - projectilePos.Y;
                overlapY = OverlapInRelationToEnemy.Down;
            }
            if (enemyPos.X < projectilePos.X + projectilePos.Width && enemyPos.X >= projectilePos.X)
            {
                xOverDist = projectilePos.X + projectilePos.Width - enemyPos.X;
                overlapY = OverlapInRelationToEnemy.Right;
            }
            if (enemyPos.X < enemyPos.X + enemyPos.Width && projectilePos.X >= enemyPos.X)
            {
                xOverDist = enemyPos.X + enemyPos.Width - projectilePos.X;
                overlapY = OverlapInRelationToEnemy.Left;
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
