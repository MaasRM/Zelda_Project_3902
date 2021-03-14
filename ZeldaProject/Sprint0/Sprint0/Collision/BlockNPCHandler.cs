using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public static void HandleCollision(INPC enemy, IBlock block)
        {
            //the idea is 

            OverlapInRelationToEnemy overlap = GetOverlapDirection(enemy, block);
            Rectangle enemyRect = enemy.GetNPCLocation();

            if (enemy is Trap)
            {
                ((Trap)enemy).Return();
            }

            if (overlap == OverlapInRelationToEnemy.Up)
            {
                //return down;
                enemyRect.Y = enemyRect.Y - 12;
                enemy.SetPosition(enemyRect);
            }
            else if (overlap == OverlapInRelationToEnemy.Down)
            {
                //return up;
                enemyRect.Y = enemyRect.Y + 12;
                enemy.SetPosition(enemyRect);
            }
            else if (overlap == OverlapInRelationToEnemy.Left)
            {
                //return right;
                enemyRect.X = enemyRect.X + 12;
                enemy.SetPosition(enemyRect);
            }
            else
            {
                //return left;
                enemyRect.X = enemyRect.X - 12;
                enemy.SetPosition(enemyRect);
            }
        }

        private static OverlapInRelationToEnemy GetOverlapDirection(INPC enemy, IBlock block)
        {
            Rectangle enemyPos = enemy.GetNPCLocation();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToEnemy overlapX = OverlapInRelationToEnemy.Right;
            OverlapInRelationToEnemy overlapY = OverlapInRelationToEnemy.Left;

            int yOverDist = 0, xOverDist = 0;

            if (enemyPos.Y < blockPos.Y + blockPos.Height && enemyPos.Y >= blockPos.Y)
            {
                yOverDist = blockPos.Y + blockPos.Height - enemyPos.Y;
                overlapY = OverlapInRelationToEnemy.Up;
            }
            if (blockPos.Y < enemyPos.Y + enemyPos.Height && blockPos.Y >= enemyPos.Y)
            {
                yOverDist = enemyPos.Y + enemyPos.Height - blockPos.Y;
                overlapY = OverlapInRelationToEnemy.Down;
            }
            if (enemyPos.X < blockPos.X + blockPos.Width && enemyPos.X >= blockPos.X)
            {
                xOverDist = blockPos.X + blockPos.Width - enemyPos.X;
                overlapY = OverlapInRelationToEnemy.Right;
            }
            if (blockPos.X < enemyPos.X + enemyPos.Width && blockPos.X >= enemyPos.X)
            {
                xOverDist = enemyPos.X + enemyPos.Width - blockPos.X;
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
    }
}
