using Microsoft.Xna.Framework;
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
        White
    }

    public enum Animation
    {
        Idle,
        Walk,
        Attack,
        UsingItem,
        IsDamaged
    }

    public class LinkStateMachine
    {
        private LinkSpriteFactory spriteFactory;
        private Direction direction;
        private LinkColor color;
        private Animation animation;
        private int xLoc;
        private int yLoc;
        private const int linkMoveSpeed = 5; //May need to change value
        private Boolean isBusy;
        private int frame;
        private List<IProjectile> linkProjectileList = new List<IProjectile>();

        public LinkStateMachine()
        {
            spriteFactory = new LinkSpriteFactory();
            direction = Direction.MoveRight;
            color = LinkColor.Green;
            animation = Animation.Idle;
            xLoc = 100; //Original Position, probably needs to change
            yLoc = 100;
            isBusy = false;
            frame = 0;
        }

        public Rectangle getDestination()
        {
            return new Rectangle(this.xLoc, this.yLoc, this.spriteFactory.getWidth(), this.spriteFactory.getHeight());
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
                } else if(this.animation == Animation.IsDamaged)
                {
                    frame++;
                    if (frame >= 3) //How many frames for damage??? 
                    {
                        frame = 0;
                        isBusy = false;
                    }
                } else if (this.animation == Animation.UsingItem)
                {
                    frame++;
                    if (frame >= 1) //Only one frame for using item??
                    {
                        frame = 0;
                        isBusy = false;
                    }
                }
            }
            foreach (IProjectile projectile in linkProjectileList)
            {
                projectile.Update();
            }
        }

        public void faceUp()
        {
            if (!isBusy)
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
            if (!isBusy)
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
            if (!isBusy)
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
            if (!isBusy)
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
            if (!isBusy)
            {
                this.animation = Animation.Attack;
                isBusy = true;
                frame = 0;
            }
        }

        public void setDamaged()
        {
            if (!isBusy) //Can Link still be damaged while busy???
            {
                this.animation = Animation.IsDamaged;
                isBusy = true;
                frame = 0;
            }
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

        public void changeXLocation(int change) //Not used but may need later??
        {
            xLoc += change;
        }

        public void changeYLocation(int change) //Not used but may need later??
        {
            yLoc += change;
        }

        public void addProjectile(IProjectile projectile)
        {
            linkProjectileList.Add(projectile);
        }

        public void RemoveProjectile(IProjectile projectile)
        {
            linkProjectileList.Remove(projectile);
        }

        public List<IProjectile> getProjectiles()
        {
            return linkProjectileList;
        }
    }
}
