using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class BlockNPCHandler
    {
        private enum OverlapInRelationToEnemy
        {
            Up,
            Right,
            Down,
            Left
        };

        public BlockNPCHandler()
        {
        }

        public static void HandleCollision(INPC enemy, IBlock block, Rectangle overlap)
        {
            //the idea is 

            OverlapInRelationToEnemy overlapSide = GetOverlapDirection(enemy, block, overlap);
            Rectangle enemyRect = enemy.GetNPCLocation();

            if(!(enemy is Keese))
            {
                if (enemy is Trap)
                {
                    ((Trap)enemy).Return();
                }

                if (overlapSide == OverlapInRelationToEnemy.Up)
                {
                    //return down;
                    enemyRect.Y = enemyRect.Y + overlap.Height;
                    enemy.SetPosition(enemyRect);
                }
                else if (overlapSide == OverlapInRelationToEnemy.Down)
                {
                    //return up;
                    enemyRect.Y = enemyRect.Y - overlap.Height;
                    enemy.SetPosition(enemyRect);
                }
                else if (overlapSide == OverlapInRelationToEnemy.Left)
                {
                    //return right;
                    enemyRect.X = enemyRect.X + overlap.Width;
                    enemy.SetPosition(enemyRect);
                }
                else if (overlapSide == OverlapInRelationToEnemy.Right)
                {
                    //return left;
                    enemyRect.X = enemyRect.X - overlap.Width;
                    enemy.SetPosition(enemyRect);
                }
            }
        }

        private static OverlapInRelationToEnemy GetOverlapDirection(INPC enemy, IBlock block, Rectangle overlap)
        {
            Rectangle enemyPos = enemy.GetNPCLocation();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToEnemy overlapX = OverlapInRelationToEnemy.Right;
            OverlapInRelationToEnemy overlapY = OverlapInRelationToEnemy.Up;

            if (overlap.Y == enemyPos.Y)
            {
                overlapY = OverlapInRelationToEnemy.Up;
            }
            else if (overlap.Y == blockPos.Y)
            {
                overlapY = OverlapInRelationToEnemy.Down;
            }

            if (overlap.X == blockPos.X)
            {
                overlapX = OverlapInRelationToEnemy.Right;
            }
            else if (overlap.X == enemyPos.X)
            {
                overlapX = OverlapInRelationToEnemy.Left;
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
    }
}
