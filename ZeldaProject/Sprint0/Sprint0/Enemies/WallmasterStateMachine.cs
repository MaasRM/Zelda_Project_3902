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

        private const int WIDTHANDHEIGHT = 16;
        private const int WALLFRAMECOUNT = 30;
        private const int MOVEFRAMECOUNT = 40;
        private const int PIXELSCALER = 4;
        private const int WALLMOVEDIST = 1;
        private const int FLOORMOVEDIST = 3;

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
            damageDirection = new Vector2(0, 0);
            SetDirection();
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, WIDTHANDHEIGHT * PIXELSCALER, WIDTHANDHEIGHT * PIXELSCALER);
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
                return new Rectangle(410, 11, WIDTHANDHEIGHT, WIDTHANDHEIGHT);
            }
            else
            {
                return new Rectangle(392, 11, WIDTHANDHEIGHT, WIDTHANDHEIGHT);
            }
        }

        public void Move()
        {
            if (state == State.Normal) {
                NormalMove();
            }
            else if(state == State.Damaged) {
                xLoc += (int)damageDirection.X * PIXELSCALER;
                yLoc += (int)damageDirection.Y * PIXELSCALER;
                damageFrames++;
            }
            else if(state == State.Stun) {
                stunFrames++;
            }

            ReturnToNormal();
        }

        public bool IsWaiting()
        {
            return activity == Activity.Waiting;
        }

        private void NormalMove()
        {
            frame++;
            if (activity == Activity.OutWall) {
                if (initialDirection == Direction.Down) yLoc += WALLMOVEDIST * PIXELSCALER;
                else if (initialDirection == Direction.Up) yLoc -= WALLMOVEDIST * PIXELSCALER;
                else if (initialDirection == Direction.Left) xLoc -= WALLMOVEDIST * PIXELSCALER;
                else xLoc += WALLMOVEDIST * PIXELSCALER;
                ChangeActivity();
            }
            else if (activity == Activity.Moving) {
                if (secondDirection == Direction.Down) yLoc += FLOORMOVEDIST * PIXELSCALER;
                else if (secondDirection == Direction.Up) yLoc -= FLOORMOVEDIST * PIXELSCALER;
                else if (secondDirection == Direction.Left) xLoc -= FLOORMOVEDIST * PIXELSCALER;
                else xLoc += FLOORMOVEDIST * PIXELSCALER;
                ChangeActivity();
            }
            else if (activity == Activity.BackIn) {
                if (initialDirection == Direction.Down) yLoc -= WALLMOVEDIST * PIXELSCALER;
                else if (initialDirection == Direction.Up) yLoc += WALLMOVEDIST * PIXELSCALER;
                else if (initialDirection == Direction.Left) xLoc += WALLMOVEDIST * PIXELSCALER;
                else xLoc -= WALLMOVEDIST * PIXELSCALER;
                ChangeActivity();
            }
        }

        private void ChangeActivity()
        {
            if (activity == Activity.OutWall && frame > WALLFRAMECOUNT)
            {
                frame = -1;
                activity = Activity.Moving;
            }
            if (activity == Activity.Moving && frame > MOVEFRAMECOUNT)
            {
                frame = -1;
                activity = Activity.BackIn;
            }
            if (activity == Activity.BackIn && frame > WALLFRAMECOUNT)
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

        public Activity GetActivity()
        {
            return activity;
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
            if (damageFrames > 8 || stunFrames > 30)
            {
                state = State.Normal;
                stunFrames = 0;
                damageFrames = 0;
                damageDirection = new Vector2(0, 0);
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
            if(yLoc <= 256)
            {
                initialDirection = Direction.Down;
            }
            if(yLoc >= 896)
            {
                initialDirection = Direction.Up;
            }
            if(xLoc <= 0)
            {
                initialDirection = Direction.Right;
            }
            if(xLoc >= 960)
            {
                initialDirection = Direction.Left;
            }
        }
    }
}

