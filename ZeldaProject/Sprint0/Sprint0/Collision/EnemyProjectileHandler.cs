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

        private const int DAMAGEVECTORSIZE = 6;

        public EnemyProjectileHandler()
        {
        }

        public static void HandleCollision(INPC enemy, IProjectile projectile)
        {
            OverlapInRelationToEnemy overlap = GetOverlapDirection(enemy, projectile);

            if (projectile is BombProjectile) BombHandler((IEnemy)enemy, (BombProjectile)projectile, overlap);
            else if (projectile is IBoomerang)
            {
                if (enemy is Keese || enemy is Gel) DamageTheEnemy((IEnemy)enemy, projectile, overlap);
                else if (!(enemy is Darknut)) StunEnemy((IEnemy)enemy);

                ((IBoomerang)projectile).GoBack();
            }
            else if(projectile is CandleFireProjectile && enemy is Gibdo && !((Gibdo)enemy).IsBurned())((Gibdo)enemy).Burn();
            else if(enemy is Gohma) GohmaHandler((Gohma)enemy, projectile, overlap);
            else
            {
                if(!(enemy is Darknut || enemy is Dodongo)) DamageTheEnemy((IEnemy)enemy, projectile, overlap);
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

            if (overlap.Y == projectilePos.Y) overlapY = OverlapInRelationToEnemy.Down;
            else if (overlap.Y == enemyPos.Y) overlapY = OverlapInRelationToEnemy.Up;

            if (overlap.X == enemyPos.X) overlapX = OverlapInRelationToEnemy.Left;
            else if (overlap.X == projectilePos.X) overlapX = OverlapInRelationToEnemy.Right;

            if (overlap.Height < overlap.Width) return overlapY;
            else return overlapX;
        }

        private static void DamageTheEnemy(IEnemy enemy, IProjectile projectile, OverlapInRelationToEnemy overlap)
        {
            Vector2 damageDirection = EnemyDamageVector(overlap);

            enemy.SetDamageState(projectile.GetDamage(), damageDirection);
        }

        private static Vector2 EnemyDamageVector(OverlapInRelationToEnemy overlap)
        {
            Vector2 up = new Vector2(0, -DAMAGEVECTORSIZE);
            Vector2 right = new Vector2(DAMAGEVECTORSIZE, 0);
            Vector2 down = new Vector2(0, DAMAGEVECTORSIZE);
            Vector2 left = new Vector2(-DAMAGEVECTORSIZE, 0);

            if (overlap == OverlapInRelationToEnemy.Down) return up;
            else if (overlap == OverlapInRelationToEnemy.Up) return down;
            else if (overlap == OverlapInRelationToEnemy.Right) return left;
            else return right;
        }

        private static void StunEnemy(IEnemy enemy)
        {
            enemy.Stun();
        }

        private static void BombHandler(IEnemy enemy, BombProjectile bomb, OverlapInRelationToEnemy overlap)
        {
            if (bomb.Exploding())
            {
                if (!(enemy is Darknut || enemy is Dodongo || enemy is Gohma))
                {
                    DamageTheEnemy(enemy, bomb, overlap);
                }
                else if (enemy is Darknut && !CheckDarknutDirection((Darknut)enemy, overlap))
                {
                    DamageTheEnemy(enemy, bomb, overlap);
                }
            }
            else if(enemy is Dodongo)
            {
                DamageTheEnemy(enemy, bomb, overlap);
                bomb.Eaten();
            }
        }

        private static bool CheckDarknutDirection(Darknut darknut, OverlapInRelationToEnemy overlap)
        {
            Direction dir = darknut.DarknutDirection();

            return ((dir == Direction.Left && overlap == OverlapInRelationToEnemy.Left)
                || (dir == Direction.Right && overlap == OverlapInRelationToEnemy.Right)
                || (dir == Direction.Up && overlap == OverlapInRelationToEnemy.Up)
                || (dir == Direction.Down && overlap == OverlapInRelationToEnemy.Down));
        }

        private static void GohmaHandler(Gohma gohma, IProjectile projectile, OverlapInRelationToEnemy direction)
        {
            if(projectile is BrownArrowProjectile || projectile is BlueArrowProjectile)
            {
                if(direction == OverlapInRelationToEnemy.Down)
                {
                    Rectangle gohmaPos = gohma.GetNPCLocation();
                    Rectangle overlap = Rectangle.Intersect(gohmaPos, projectile.GetProjectileLocation());

                    if(overlap.X > gohmaPos.X + 3 * gohmaPos.Width / 4 && overlap.X > gohmaPos.X + 5 * gohmaPos.Width / 4)
                    {
                        DamageTheEnemy(gohma, projectile, direction);
                    }
                }
            }
        }
    }
}
