using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Sprint0
{
    public class AquamentusStateMachine
    {

        private enum State
        {
            Normal,
            Damaged,
        }

        private Direction direction;
        private State state;
        private int xLoc;
        private int yLoc;
        private int frame;
        private int lastFire;
        private int health;
        private int damageFrames;
        
        private bool firing;

        public AquamentusStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            damageFrames = 0;
            lastFire = AquamentusConstants.FIRECOOLDOWN * -1;
            firing = false;
            health = AquamentusConstants.MAXHEALTH;
            direction = Direction.Left;
            state = State.Normal;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, AquamentusConstants.WIDTH * GameConstants.SCALE, AquamentusConstants.HEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if(firing)
            {
                if(frame % 2 == 0) return new Rectangle(1, 11, AquamentusConstants.WIDTH, AquamentusConstants.HEIGHT);
                else return new Rectangle(26, 11, AquamentusConstants.WIDTH, AquamentusConstants.HEIGHT);
            }
            else
            {
                if (frame % 2 == 0) return new Rectangle(51, 11, AquamentusConstants.WIDTH, AquamentusConstants.HEIGHT);
                else return new Rectangle(76, 11, AquamentusConstants.WIDTH, AquamentusConstants.HEIGHT);
            }
        }

        public void Move()
        {
            frame++;

            if (xLoc < AquamentusConstants.LEFTMAX) direction = Direction.Right;
            if (frame % AquamentusConstants.CHANGEDIRECTIONFRAME == 0) direction = ChangeDirection();
            if (direction == Direction.Left) xLoc -= AquamentusConstants.moveDist * GameConstants.SCALE;
            else xLoc += AquamentusConstants.moveDist * GameConstants.SCALE;

            if(firing) StopFiring();

            if(state == State.Damaged) damageFrames++;

            ReturnToNormal();
        }

        public int GetFrame()
        {
            return frame;
        }

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(2);

            return (Direction)num;
        }

        public bool TryToFire()
        {
            if(frame - lastFire >= AquamentusConstants.FIRECOOLDOWN)
            {
                int num = RandomNumberGenerator.GetInt32(AquamentusConstants.FIRECHANCE);

                if(num % (AquamentusConstants.FIRECHANCE - 1) == 0)
                {
                    firing = true;
                    lastFire = frame;
                }
            }

            return firing;
        }

        private void StopFiring()
        {
            if(frame - lastFire == AquamentusConstants.FIREFRAMECOUNT && firing)
            {
                firing = false;
            }
        }

        public bool IsFiring()
        {
            return firing;
        }

        public bool HasHealth()
        {
            return health > 0;
        }

        public void TakeDamage(int damage)
        {
            if (state != State.Damaged)
            {
                health -= damage;
                state = State.Damaged;
                damageFrames = 1;
            }
        }

        public void ReturnToNormal()
        {
            if (damageFrames > AquamentusConstants.DAMAGEFRAMECOUNT)
            {
                state = State.Normal;
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
    }
}