using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class TrapCollisionHandler
    {

        private enum OverlapInRelationToTrapOne
        {
            Up,
            Right,
            Down,
            Left
        };

        public TrapCollisionHandler()
        {
        }

        public static void HandleCollision(Trap one, Trap two)
        {
            OverlapInRelationToTrapOne overlap = GetOverlapDirection(one, two);
            AdjustTrapLocations(one, two, overlap);
            one.Return();
            two.Return();
        }

        private static OverlapInRelationToTrapOne GetOverlapDirection(Trap one, Trap two)
        {
            Rectangle onePos = one.GetNPCLocation();
            Rectangle twoPos = two.GetNPCLocation();
            OverlapInRelationToTrapOne overlapX = OverlapInRelationToTrapOne.Right;
            OverlapInRelationToTrapOne overlapY = OverlapInRelationToTrapOne.Left;

            int yOverDist = 0, xOverDist = 0;

            if (onePos.Y < twoPos.Y + twoPos.Height && onePos.Y >= twoPos.Y)
            {
                yOverDist = twoPos.Y + twoPos.Height - onePos.Y;
                overlapY = OverlapInRelationToTrapOne.Up;
            }
            if (twoPos.Y < onePos.Y + onePos.Height && twoPos.Y >= onePos.Y)
            {
                yOverDist = onePos.Y + onePos.Height - twoPos.Y;
                overlapY = OverlapInRelationToTrapOne.Down;
            }
            if (onePos.X < twoPos.X + twoPos.Width && onePos.X >= twoPos.X)
            {
                xOverDist = twoPos.X + twoPos.Width - onePos.X;
                overlapY = OverlapInRelationToTrapOne.Right;
            }
            if (twoPos.X < onePos.X + onePos.Width && twoPos.X >= onePos.X)
            {
                xOverDist = onePos.X + onePos.Width - twoPos.X;
                overlapY = OverlapInRelationToTrapOne.Left;
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

        private static void AdjustTrapLocations(Trap one, Trap two, OverlapInRelationToTrapOne overlap)
        {
            Rectangle onePos = one.GetNPCLocation();
            Rectangle twoPos = two.GetNPCLocation();
            int overDist;

            if (overlap == OverlapInRelationToTrapOne.Up)
            {
                overDist = twoPos.Y + twoPos.Height - onePos.Y;
                one.SetPosition(new Rectangle(onePos.X, onePos.Y + overDist / 2, onePos.Width, onePos.Height));
                two.SetPosition(new Rectangle(twoPos.X, twoPos.Y - overDist / 2, twoPos.Width, twoPos.Height));
            }
            else if (overlap == OverlapInRelationToTrapOne.Down)
            {
                overDist = onePos.Y + onePos.Height - twoPos.Y;
                one.SetPosition(new Rectangle(onePos.X, onePos.Y - overDist / 2, onePos.Width, onePos.Height));
                two.SetPosition(new Rectangle(twoPos.X, twoPos.Y + overDist / 2, twoPos.Width, twoPos.Height));
            }
            else if (overlap == OverlapInRelationToTrapOne.Left)
            {
                overDist = twoPos.X + twoPos.Width - onePos.X;
                one.SetPosition(new Rectangle(onePos.X + overDist / 2, onePos.Y, onePos.Width, onePos.Height));
                two.SetPosition(new Rectangle(twoPos.X - overDist / 2, twoPos.Y, twoPos.Width, twoPos.Height));
            }
            else
            {
                overDist = onePos.X + onePos.Width - twoPos.X;
                one.SetPosition(new Rectangle(onePos.X - overDist / 2, onePos.Y, onePos.Width, onePos.Height));
                two.SetPosition(new Rectangle(twoPos.X + overDist / 2, twoPos.Y, twoPos.Width, twoPos.Height));
            }
        }
    }
}
