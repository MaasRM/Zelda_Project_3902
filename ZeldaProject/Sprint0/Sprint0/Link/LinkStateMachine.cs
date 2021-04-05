using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public enum Direction
    {
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight
    }

    public enum LinkColor
    {
        Green,
        Red,
        White,
        Damaged
    }

    public enum Animation
    {
        Idle,
        Walk,
        Attack,
        UsingItem
    }

    public class LinkStateMachine
    {
        private LinkSpriteFactory spriteFactory;
        private Direction direction;
        private LinkColor color;
        private Animation animation;
        private int xLoc;
        private int yLoc;
        private const int linkMoveSpeed = 16; //May need to change value
        private bool isBusy;
        private int frame;
        private int swordProjFrame;
        private int sizeFactor;
        private HealthAndDamageHandler healthAndDamage;
        public Vector2 damageVector { get; set; }
        private const int xInit = 120;
        private const int yInit = 128;
        private const int scale = 4;
        private const int STARTHEALTH = 18;
        private const int SWORDPROJECTILEBUFFER = 20;
        private List<SoundEffect> soundEffects;
        private SoundEffectInstance lowHealth;

        public LinkStateMachine(List<SoundEffect> Link_soundEffects)
        {
            spriteFactory = new LinkSpriteFactory();
            direction = Direction.MoveUp;
            color = LinkColor.Green;
            animation = Animation.Idle;
            xLoc = xInit * scale; //Original Position, probably needs to change
            yLoc = yInit * scale;
            isBusy = false;
            healthAndDamage = new HealthAndDamageHandler(STARTHEALTH, 1);
            sizeFactor = 4;
            frame = 0;
            swordProjFrame = 0;
            damageVector = new Vector2(0, 0);
            soundEffects = Link_soundEffects;
            lowHealth = soundEffects[4].CreateInstance();
            lowHealth.IsLooped = true;
        }

        public Rectangle getDestination()
        {
            Rectangle ret;
            if (direction == Direction.MoveUp && animation == Animation.Attack)
            {
                ret = new Rectangle(this.xLoc, this.yLoc - (sizeFactor * 15), this.spriteFactory.getWidth() * sizeFactor, this.spriteFactory.getHeight() * sizeFactor);
            }
            else if (direction == Direction.MoveLeft && animation == Animation.Attack && frame == 1)
            {
                ret = new Rectangle(this.xLoc - (sizeFactor * 11), this.yLoc, this.spriteFactory.getWidth() * sizeFactor, this.spriteFactory.getHeight() * sizeFactor);
            }
            else if (direction == Direction.MoveLeft && animation == Animation.Attack && frame == 2)
            {
                ret = new Rectangle(this.xLoc - (sizeFactor * 7), this.yLoc, this.spriteFactory.getWidth() * sizeFactor, this.spriteFactory.getHeight() * sizeFactor);
            }
            else if (direction == Direction.MoveLeft && animation == Animation.Attack && frame == 3)
            {
                ret = new Rectangle(this.xLoc - (sizeFactor * 3), this.yLoc, this.spriteFactory.getWidth() * sizeFactor, this.spriteFactory.getHeight() * sizeFactor);
            }
            else
            {
                ret = new Rectangle(this.xLoc, this.yLoc, this.spriteFactory.getWidth() * sizeFactor, this.spriteFactory.getHeight() * sizeFactor);
            }

            return ret;
        }

        public Rectangle getSource()
        {
            return this.spriteFactory.getSourceRectangle(direction, color, animation, frame);
        }

        public void Update()
        {
            if(isBusy)
            {
                if(this.animation == Animation.Attack)
                {
                    frame++;
                    if(frame >= 4)
                    {
                        frame = 0;
                        isBusy = false;
                    }
                } else if(this.animation == Animation.UsingItem)
                {
                    frame++;
                    if (frame >= 4)
                    {
                        frame = 0;
                        isBusy = false;
                    }
                }
            }

            if(color == LinkColor.Damaged)
            {
                xLoc += (int)damageVector.X * scale;
                yLoc += (int)damageVector.Y * scale;
            }

            swordProjFrame++;
        }

        public void faceUp()
        {
            if (!isBusy && (color != LinkColor.Damaged || (damageVector.X == 0 && damageVector.Y == 0)))
            {
                if (this.direction == Direction.MoveUp)
                {
                    this.animation = Animation.Walk;
                    yLoc -= linkMoveSpeed;
                    if (frame == 0) frame = 1;
                    else frame = 0;
                }
                else
                {
                    this.direction = Direction.MoveUp;
                    this.animation = Animation.Idle;
                    frame = 0;
                }
            }
        }

        public void faceDown()
        {
            if (!isBusy && (color != LinkColor.Damaged || (damageVector.X == 0 && damageVector.Y == 0)))
            {
                if (this.direction == Direction.MoveDown)
                {
                    this.animation = Animation.Walk;
                    yLoc += linkMoveSpeed;
                    if (frame == 0) frame = 1;
                    else frame = 0;
                }
                else
                {
                    this.direction = Direction.MoveDown;
                    this.animation = Animation.Idle;
                    frame = 0;
                }
            }
        }

        public void faceLeft()
        {
            if (!isBusy && (color != LinkColor.Damaged || (damageVector.X == 0 && damageVector.Y == 0)))
            {
                if (this.direction == Direction.MoveLeft)
                {
                    this.animation = Animation.Walk;
                    xLoc -= linkMoveSpeed;
                    if (frame == 0) frame = 1;
                    else frame = 0;
                }
                else
                {
                    this.direction = Direction.MoveLeft;
                    this.animation = Animation.Idle;
                    frame = 0;
                }
            }
        }

        public void faceRight()
        {
            if (!isBusy && (color != LinkColor.Damaged || (damageVector.X == 0 && damageVector.Y == 0)))
            {
                if (this.direction == Direction.MoveRight)
                {
                    this.animation = Animation.Walk;
                    xLoc += linkMoveSpeed;
                    if (frame == 0) frame = 1;
                    else frame = 0;
                }
                else
                {
                    this.direction = Direction.MoveRight;
                    this.animation = Animation.Idle;
                    frame = 0;
                }
            }
        }

        public void setIdle()
        {
            if (!isBusy)
            {
                this.animation = Animation.Idle;
                isBusy = false;
                frame = 0;
            }
        }

        public void setAttack()
        {
            if (!isBusy && color != LinkColor.Damaged)
            {
                this.animation = Animation.Attack;
                isBusy = true;
                frame = 0;
                soundEffects[8].Play();
            }
        }

        public void setDamaged()
        {
            this.color = LinkColor.Damaged;
        }

        public void setOriginalColor()
        {
            this.color = LinkColor.Green;
        }

        public void setUseItem()
        {
            if (!isBusy)
            {
                this.animation = Animation.UsingItem;
                isBusy = true;
                frame = 0;
            }
        }

        public Boolean getIsBusy()
        {
            return this.isBusy;
        }

        public Direction getDirection()
        {
            return this.direction;
        }

        public LinkColor getColor()
        {
            return this.color;
        }

        public Animation getAnimation()
        {
            return this.animation;
        }

        public int getXLoc()
        {
            return this.xLoc;
        }

        public int getYLoc()
        {
            return this.yLoc;
        }

        public void changeXLocation(int change) //Not used but may need later??
        {
            xLoc += change;
        }

        public void changeYLocation(int change) //Not used but may need later??
        {
            yLoc += change;
        }

        public void MakeBusy()
        {
            isBusy = true;
        }

        public void SetPositions(Rectangle newPos)
        {
            yLoc = newPos.Y;
            xLoc = newPos.X;
            damageVector = new Vector2(0, 0);
        }

        public void Heal(int newHealth)
        {
            healthAndDamage.Heal(newHealth);
        }

        public void TakeDamage(int damage, Vector2 direction)
        {
            if(color != LinkColor.Damaged)
            {
                healthAndDamage.GetDamaged(damage);
                damageVector = direction;
                setDamaged();
            }
        }

        public bool HasHealth()
        {
            if(healthAndDamage.Health() < 2 && healthAndDamage.IsAlive())
            {
                lowHealth.Play();
            }
            else
            {
                lowHealth.Stop();
            }

            return healthAndDamage.IsAlive();
        }

        public int GetCurrentHealth()
        {
            return healthAndDamage.Health();
        }

        public void SetMaxHealth(int health)
        {
            healthAndDamage.SetHealth(health);
        }

        public int GetMaxHealth()
        {
            return healthAndDamage.GetMaxHealth();
        }

        public int GetDamage()
        {
            return healthAndDamage.DealDamage();
        }

        public bool ReadyToFire()
        {
            bool returnValue = false;
            if(healthAndDamage.AtMaxHealth() && animation == Animation.Attack && swordProjFrame >= SWORDPROJECTILEBUFFER)
            {
                returnValue = true;
                swordProjFrame = 0;
            }

            return returnValue;
        }
    }
}
