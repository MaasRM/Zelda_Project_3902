using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public enum Direction
    {
        Down,
        Up,
        Left,
        Right,
        UpRight,
        DownRight,
        DownLeft,
        UpLeft
    }

    public enum LinkColor
    {
        Green,
        Red,
        Black,
        Blue,
        Damaged
    }

    public enum Animation
    {
        Idle,
        Walk,
        Attack,
        UsingItem,
        PickUpItem
    }

    public class LinkStateMachine
    {
        private LinkSpriteFactory spriteFactory;
        private Direction direction;
        private LinkColor color;
        private Animation animation;
        private int xLoc;
        private int yLoc;
        private bool isBusy;
        private int frame;
        private HealthAndDamageHandler healthAndDamage;
        private List<SoundEffect> soundEffects;
        private SoundEffectInstance lowHealth;
        public Vector2 damageVector { get; set; }

        public LinkStateMachine(List<SoundEffect> Link_soundEffects)
        {
            spriteFactory = new LinkSpriteFactory();
            direction = Direction.Up;
            color = LinkColor.Green;
            animation = Animation.Idle;
            xLoc = LinkConstants.XINIT * Sprint0.GameConstants.SCALE; //Original Position
            yLoc = LinkConstants.YINIT * Sprint0.GameConstants.SCALE;
            isBusy = false;
            healthAndDamage = new HealthAndDamageHandler(LinkConstants.STARTHEALTH, 1);
            frame = 0;
            damageVector = new Vector2(0, 0);
            soundEffects = Link_soundEffects;
            lowHealth = soundEffects[4].CreateInstance();
            lowHealth.IsLooped = true;
        }

        public Rectangle getDestination()
        {
            Rectangle ret;
            if (direction == Direction.Up && animation == Animation.Attack)
            {
                ret = new Rectangle(this.xLoc, this.yLoc - (GameConstants.SCALE * 15), this.spriteFactory.getWidth() * GameConstants.SCALE, this.spriteFactory.getHeight() * GameConstants.SCALE);
            }
            else if (direction == Direction.Left && animation == Animation.Attack && frame == 1)
            {
                ret = new Rectangle(this.xLoc - (GameConstants.SCALE * 11), this.yLoc, this.spriteFactory.getWidth() * GameConstants.SCALE, this.spriteFactory.getHeight() * GameConstants.SCALE);
            }
            else if (direction == Direction.Left && animation == Animation.Attack && frame == 2)
            {
                ret = new Rectangle(this.xLoc - (GameConstants.SCALE * 7), this.yLoc, this.spriteFactory.getWidth() * GameConstants.SCALE, this.spriteFactory.getHeight() * GameConstants.SCALE);
            }
            else if (direction == Direction.Left && animation == Animation.Attack && frame == 3)
            {
                ret = new Rectangle(this.xLoc - (GameConstants.SCALE * 3), this.yLoc, this.spriteFactory.getWidth() * GameConstants.SCALE, this.spriteFactory.getHeight() * GameConstants.SCALE);
            }
            else
            {
                ret = new Rectangle(this.xLoc, this.yLoc, this.spriteFactory.getWidth() * GameConstants.SCALE, this.spriteFactory.getHeight() * GameConstants.SCALE);
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
                } else if (this.animation == Animation.PickUpItem)
                {
                    frame++;
                    if (frame >= 16)
                    {
                        frame = 0;
                        isBusy = false;
                    }
                }
            }

            if(color == LinkColor.Damaged)
            {
                xLoc += (int)damageVector.X * Sprint0.GameConstants.SCALE;
                yLoc += (int)damageVector.Y * Sprint0.GameConstants.SCALE;
            }
        }

        public void Move(Direction dir)
        {
            if (!isBusy && (color != LinkColor.Damaged || (damageVector.X == 0 && damageVector.Y == 0))) {
                if (this.direction == dir) {
                    this.animation = Animation.Walk;
                    switch (dir) {
                        case Direction.Up:
                            yLoc -= LinkConstants.LINKMOVESPEED;
                            break;
                        case Direction.Down:
                            yLoc += LinkConstants.LINKMOVESPEED;
                            break;
                        case Direction.Left:
                            xLoc -= LinkConstants.LINKMOVESPEED;
                            break;
                        case Direction.Right:
                            xLoc += LinkConstants.LINKMOVESPEED;
                            break;
                        default:
                            break;
                    }
                    if (frame == 0) frame = 1;
                    else frame = 0;
                } else {
                    this.direction = dir;
                    this.animation = Animation.Idle;
                    frame = 0;
                }
            }
        }

        public void setAnimation(Animation animation)
        {
            if (!isBusy && ((animation == Animation.Idle || animation == Animation.UsingItem || animation == Animation.PickUpItem) || (color != LinkColor.Damaged && animation == Animation.Attack)))
            {
                this.animation = animation;
                if (animation == Animation.Attack || animation == Animation.UsingItem || animation == Animation.PickUpItem) isBusy = true;
                if (animation == Animation.Attack) soundEffects[8].Play();
                frame = 0;
            }
        }

        public void setColor(LinkColor color)
        {
            this.color = color;
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
                setColor(LinkColor.Damaged);
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
    }
}
