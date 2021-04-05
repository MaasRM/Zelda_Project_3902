﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

    public class LinkSpriteFactory
    {
        int linkHeight;
        int linkWidth;
        public LinkSpriteFactory()
        {
            //initial height and width
            linkHeight = 15;
            linkWidth = 15;
        }

        public Rectangle getSourceRectangle(Direction direction, LinkColor color, Animation animation, int frame)
        {
            //Use params to get proper rectangle from sprite sheet and update height and width
            ILinkRectangle linkRectangle;
            Rectangle retRectangle;
            if (direction == Direction.Up)
            {
                if (animation == Animation.Idle)
                {
                    linkRectangle = new RectangleLinkMoveUpIdle();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                } 
                else if (animation == Animation.Walk)
                {
                    linkRectangle = new RectangleLinkMoveUpWalk();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                } 
                else if (animation == Animation.Attack)
                {
                    linkRectangle = new RectangleLinkMoveUpAttack();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 30;
                    linkWidth = 16;
                } 
                else //Animation.UsingItem
                {
                    linkRectangle = new RectangleLinkMoveUpItem();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
            } 
            else if (direction == Direction.Down)
            {
                if (animation == Animation.Idle)
                {
                    linkRectangle = new RectangleLinkMoveDownIdle();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
                else if (animation == Animation.Walk)
                {
                    linkRectangle = new RectangleLinkMoveDownWalk();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
                else if (animation == Animation.Attack)
                {
                    linkRectangle = new RectangleLinkMoveDownAttack();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 30;
                    linkWidth = 16;
                }
                else //Animation.UsingItem
                {
                    linkRectangle = new RectangleLinkMoveDownItem();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
            } 
            else if (direction == Direction.Left)
            {
                if (animation == Animation.Idle)
                {
                    linkRectangle = new RectangleLinkMoveRightIdle();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
                else if (animation == Animation.Walk)
                {
                    linkRectangle = new RectangleLinkMoveRightWalk();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
                else if (animation == Animation.Attack)
                {
                    linkRectangle = new RectangleLinkMoveRightAttack();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    if (frame == 0)
                    {
                        linkHeight = 16;
                        linkWidth = 16;
                    }
                    else if (frame == 1)
                    {
                        linkHeight = 16;
                        linkWidth = 26;
                    }
                    else if (frame == 2)
                    {
                        linkHeight = 16;
                        linkWidth = 22;
                    }
                    else //frame == 3
                    {
                        linkHeight = 16;
                        linkWidth = 18;
                    }
                }
                else //Animation.UsingItem
                {
                    linkRectangle = new RectangleLinkMoveRightItem();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
            } 
            else //Direction.MoveRight
            {
                if (animation == Animation.Idle)
                {
                    linkRectangle = new RectangleLinkMoveRightIdle();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
                else if (animation == Animation.Walk)
                {
                    linkRectangle = new RectangleLinkMoveRightWalk();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
                else if (animation == Animation.Attack)
                {
                    linkRectangle = new RectangleLinkMoveRightAttack();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    if (frame == 0)
                    {
                        linkHeight = 16;
                        linkWidth = 16;
                    }
                    else if (frame == 1)
                    {
                        linkHeight = 16;
                        linkWidth = 27;
                    }
                    else if (frame == 2)
                    {
                        linkHeight = 16;
                        linkWidth = 23;
                    }
                    else //frame == 3
                    {
                        linkHeight = 16;
                        linkWidth = 19;
                    }
                }
                else //Animation.UsingItem
                {
                    linkRectangle = new RectangleLinkMoveRightItem();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                    linkHeight = 16;
                    linkWidth = 16;
                }
            }
            return retRectangle;
        }

        public int getHeight()
        {
            return linkHeight;
        }

        public int getWidth()
        {
            return linkWidth;
        }

    }

}
