using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class WallmasterStateMachine
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum Activity
        {
            Waiting,
            OutWall,
            Moving,
            BackIn
        }

        public enum State
        {
            Normal,
            Damaged,
            Stun
        }

        public Direction initialDirection { get; set; }
        public Direction secondDirection { get; set; }
        public Activity activity { get; set; }
        public State state { get; set; }

        private Vector2 damageDirection;
        private int xLoc;
        private int yLoc;
        private int frame;
        private int stunFrames;
        private int damageFrames;
        private Tuple<int, int> initial;
        private bool grab;

        

        public WallmasterStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            frame = 0;
            initial = new Tuple<int, int>(x, y);
            grab = false;
            activity = Activity.Waiting;
            stunFrames = 0;
            damageFrames = 0;
            state = State.Normal;
            damageDirection = new Vector2(1, 1);
            SetDirection();
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, WallmasterConstants.WIDTHANDHEIGHT * GameConstants.SCALE, WallmasterConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if (grab || (activity == Activity.Moving && frame % 2 == 1))
            {
                return new Rectangle(410, 11, WallmasterConstants.WIDTHANDHEIGHT, WallmasterConstants.WIDTHANDHEIGHT);
            }
            else
            {
                return new Rectangle(392, 11, WallmasterConstants.WIDTHANDHEIGHT, WallmasterConstants.WIDTHANDHEIGHT);
            }
        }

        public void Move()
        {
            if (state == State.Normal) {
                NormalMove();
            }
            else if(state == State.Damaged) {
                xLoc += (int)damageDirection.X * GameConstants.SCALE;
                yLoc += (int)damageDirection.Y * GameConstants.SCALE;
                damageFrames++;
            }
            else if(state == State.Stun) {
                stunFrames++;
            }

            ReturnToNormal();
        }

        private void NormalMove()
        {
            frame++;
            if (activity == Activity.OutWall) {
                if (initialDirection == Direction.Down) yLoc += WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                else if (initialDirection == Direction.Up) yLoc -= WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                else if (initialDirection == Direction.Left) xLoc -= WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                else xLoc += WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                ChangeActivity();
            }
            else if (activity == Activity.Moving) {
                if (secondDirection == Direction.Down) yLoc += WallmasterConstants.FLOORMOVEDIST * GameConstants.SCALE;
                else if (secondDirection == Direction.Up) yLoc -= WallmasterConstants.FLOORMOVEDIST * GameConstants.SCALE;
                else if (secondDirection == Direction.Left) xLoc -= WallmasterConstants.FLOORMOVEDIST * GameConstants.SCALE;
                else xLoc += WallmasterConstants.FLOORMOVEDIST * GameConstants.SCALE;
                ChangeActivity();
            }
            else if (activity == Activity.BackIn) {
                if (initialDirection == Direction.Down) yLoc -= WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                else if (initialDirection == Direction.Up) yLoc += WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                else if (initialDirection == Direction.Left) xLoc += WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                else xLoc -= WallmasterConstants.WALLMOVEDIST * GameConstants.SCALE;
                ChangeActivity();
            }
        }

        private void ChangeActivity()
        {
            if (activity == Activity.OutWall && frame > WallmasterConstants.WALLFRAMECOUNT)
            {
                frame = -1;
                activity = Activity.Moving;
            }
            if (activity == Activity.Moving && frame > WallmasterConstants.MOVEFRAMECOUNT)
            {
                frame = -1;
                activity = Activity.BackIn;
            }
            if (activity == Activity.BackIn && frame > WallmasterConstants.WALLFRAMECOUNT)
            {
                grab = false;
                frame = 0;
                activity = Activity.Waiting;
                xLoc = initial.Item1;
                yLoc = initial.Item2;
            }
        }


        public void SetWallmaster()
        {
            if(activity == Activity.Waiting)
            {
                activity = Activity.OutWall;
                frame = 0;

                int num = RandomNumberGenerator.GetInt32(2) % 2;

                if (initialDirection == Direction.Down || initialDirection == Direction.Up)
                {
                    if (num == 0) secondDirection = Direction.Left;
                    else secondDirection = Direction.Right;
                }
                else
                {
                    if (num == 0) secondDirection = Direction.Up;
                    else secondDirection = Direction.Down;
                }
            }
        }

        public void GrabLink()
        {
            grab = true;
        } 

        public Direction GetSecondDirection()
        {
            return secondDirection;
        }

        public bool GetGrabStatus()
        {
            return grab;
        }

        public void SetDamageVector(Vector2 direction)
        {
            state = State.Damaged;
            stunFrames = 1;
            damageFrames = 1;

            damageDirection = direction;
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 1;
        }

        public void ReturnToNormal()
        {
            if (damageFrames > WallmasterConstants.DAMAGEFRAMECOUNT || stunFrames > WallmasterConstants.STUNFRAMECOUNT)
            {
                state = State.Normal;
                stunFrames = 0;
                damageFrames = 0;
                damageDirection = new Vector2(1, 1);
            }
        }

        public bool IsDamaged()
        {
            return state == State.Damaged;
        }

        public int GetDamageFrame()
        {
            return damageFrames;
        }

        private void SetDirection()
        {
            if(yLoc <= WallmasterConstants.TOPWALL)
            {
                initialDirection = Direction.Down;
            }
            if(yLoc >= WallmasterConstants.BOTTOMWALL)
            {
                initialDirection = Direction.Up;
            }
            if(xLoc <= WallmasterConstants.LEFTWALL)
            {
                initialDirection = Direction.Right;
            }
            if(xLoc >= WallmasterConstants.RIGHTWALL)
            {
                initialDirection = Direction.Left;
            }
        }
    }
}

