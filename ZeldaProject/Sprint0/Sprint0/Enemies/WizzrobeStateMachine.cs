using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class WizzrobeStateMachine
    {
        public enum WizzrobeColor
        {
            Red,
            Blue
        }

        private enum State
        {
            Normal,
            Damaged,
            Stun
        }

        private State state;
        private Vector2 damageDirection;
        private int xLoc;
        private int yLoc;
        private int frame;
        private int postFireFrame;
        private int health;
        private int damageFrames;
        private int stunFrames;
        private Sprint5 game;

        public Direction direction { get; set; }
        public WizzrobeColor color { get; set; }

        public WizzrobeStateMachine(int x, int y, WizzrobeColor c, Sprint5 sprint)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            postFireFrame = WizzrobeConstants.FRAMESBEFORETELEPORT + WizzrobeConstants.TELEPORTFRAMES;
            color = c;
            if (color == WizzrobeColor.Red) health = WizzrobeConstants.REDMAXHEALTH;
            else health = WizzrobeConstants.BLUEMAXHEALTH;
            state = State.Normal;
            game = sprint;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, WizzrobeConstants.WIDTHANDHEIGHT * GameConstants.SCALE, WizzrobeConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if (direction == Direction.Down || direction == Direction.Up)
            {
                return new Rectangle(222 + 17 * (int)direction, 11 + 17 * (int)color, WizzrobeConstants.WIDTHANDHEIGHT, WizzrobeConstants.WIDTHANDHEIGHT);
            }
            else
            {
                if (frame % 2 == 0)
                {
                    return new Rectangle(256, 11 + 17 * (int)color, WizzrobeConstants.WIDTHANDHEIGHT, WizzrobeConstants.WIDTHANDHEIGHT);
                }
                else
                {
                    return new Rectangle(273, 11 + 17 * (int)color, WizzrobeConstants.WIDTHANDHEIGHT, WizzrobeConstants.WIDTHANDHEIGHT);
                }
            }
        }

        public void Move()
        {
            frame++;
            postFireFrame++;
            if (state == State.Normal) {
                if (frame % 10 == 0) direction = ChangeDirection();

                if (color == WizzrobeColor.Blue) {
                    if (postFireFrame >= WizzrobeConstants.FRAMESBEFORETELEPORT + WizzrobeConstants.TELEPORTFRAMES) {
                        if (direction == Direction.Up) yLoc -= GoriyaConstants.moveDist * GameConstants.SCALE;
                        else if (direction == Direction.Down) yLoc += GoriyaConstants.moveDist * GameConstants.SCALE;
                        else if (direction == Direction.Left) xLoc -= GoriyaConstants.moveDist * GameConstants.SCALE;
                        else xLoc += GoriyaConstants.moveDist * GameConstants.SCALE;
                    }
                }
                if (postFireFrame > WizzrobeConstants.FRAMESBEFORETELEPORT && postFireFrame < WizzrobeConstants.FRAMESBEFORETELEPORT + WizzrobeConstants.TELEPORTFRAMES) Teleport();
            }
            else if (state == State.Damaged) {
                xLoc += (int)damageDirection.X * GameConstants.SCALE;
                yLoc += (int)damageDirection.Y * GameConstants.SCALE;
                damageFrames++;
            }
            else if (state == State.Stun) stunFrames++;

            ReturnToNormal();
        }

        public int GetFrame()
        {
            return frame;
        }

        public Direction GetDirection()
        {
            return direction;
        }

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(WizzrobeConstants.CHANGEDIRECTION);

            return (Direction)num;
        }

        public bool FireChance()
        {
            bool fired = false;

            if(postFireFrame >= WizzrobeConstants.FRAMESBEFORETELEPORT + WizzrobeConstants.TELEPORTFRAMES && state == State.Normal)
            {
                int num = RandomNumberGenerator.GetInt32(WizzrobeConstants.FIRECHANCE);

                if (num % (WizzrobeConstants.FIRECHANCE - 1) == 0)
                {
                    damageFrames = 0;
                    postFireFrame = 0;
                    fired = true;
                }
            }

            return fired;
        }

        public bool HasHealth()
        {

            return health > 0;
        }

        public void TakeDamage(int damage, Vector2 damageVector)
        {
            if (state != State.Damaged && !Teleporting())
            {
                health -= damage;
                state = State.Damaged;
                stunFrames = 1;
                damageFrames = 1;
                damageDirection = damageVector;
            }
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 1;
        }

        public int GetDamage()
        {
            if (color == WizzrobeColor.Red)
            {
                return GoriyaConstants.REDDAMAGE;
            }
            else
            {
                return GoriyaConstants.BLUEDAMAGE;
            }

        }

        public void ReturnToNormal()
        {
            if (damageFrames > GoriyaConstants.DAMAGEFRAMECOUNT || stunFrames > GoriyaConstants.STUNFRAMECOUNT)
            {
                state = State.Normal;
                stunFrames = 0;
                damageFrames = 0;
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

        private void Teleport()
        {
            xLoc = RandomNumberGenerator.GetInt32(game.GraphicsDevice.Viewport.Width - WallConstants.RIGHTWALL - WallConstants.LEFTWALL) + WallConstants.LEFTWALL;
            yLoc = RandomNumberGenerator.GetInt32(game.GraphicsDevice.Viewport.Height - WallConstants.BOTTOMWALL - WallConstants.TOPWALL - GameConstants.HUDSIZE * GameConstants.SCALE) + WallConstants.LEFTWALL + GameConstants.HUDSIZE * GameConstants.SCALE;

            ChangeDirection();
        }

        public bool Teleporting()
        {
            return postFireFrame < WizzrobeConstants.FRAMESBEFORETELEPORT || postFireFrame >= WizzrobeConstants.FRAMESBEFORETELEPORT + WizzrobeConstants.TELEPORTFRAMES;
        }
    }
}