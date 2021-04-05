using Microsoft.Xna.Framework;
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
            linkHeight = 16;
            linkWidth = 16;
        }

        public Rectangle getSourceRectangle(Direction direction, LinkColor color, Animation animation, int frame)
        {
            //Use params to get proper rectangle from sprite sheet and update height and width
            ILinkRectangle linkRectangle;
            Rectangle retRectangle;

            //generic
            linkRectangle = FindLinkRectangle(direction, animation);
            retRectangle = linkRectangle.getRectangle(color, frame);
            linkHeight = FindLinkHeight(direction, animation, frame);
            linkWidth = FindLinkWidth(direction, animation, frame);
            return retRectangle;
        }

        private ILinkRectangle FindLinkRectangle(Direction direction, Animation animation)
        {
            ILinkRectangle retRectangle;
            if (direction == Direction.Up)
            {
                if (animation == Animation.Idle)
                {
                    retRectangle = new RectangleLinkMoveUpIdle();
                }
                else if (animation == Animation.Walk)
                {
                    retRectangle = new RectangleLinkMoveUpWalk();
                }
                else if (animation == Animation.Attack)
                {
                    retRectangle = new RectangleLinkMoveUpAttack();
                }
                else //Animation.UsingItem
                {
                    retRectangle = new RectangleLinkMoveUpItem();
                }
            }
            else if (direction == Direction.Down)
            {
                if (animation == Animation.Idle)
                {
                    retRectangle = new RectangleLinkMoveDownIdle();
                }
                else if (animation == Animation.Walk)
                {
                    retRectangle = new RectangleLinkMoveDownWalk();
                }
                else if (animation == Animation.Attack)
                {
                    retRectangle = new RectangleLinkMoveDownAttack();
                }
                else //Animation.UsingItem
                {
                    retRectangle = new RectangleLinkMoveDownItem();
                }
            }
            else if (direction == Direction.Left)
            {
                if (animation == Animation.Idle)
                {
                    retRectangle = new RectangleLinkMoveRightIdle();
                }
                else if (animation == Animation.Walk)
                {
                    retRectangle = new RectangleLinkMoveRightWalk();
                }
                else if (animation == Animation.Attack)
                {
                    retRectangle = new RectangleLinkMoveRightAttack();
                }
                else //Animation.UsingItem
                {
                    retRectangle = new RectangleLinkMoveRightItem();
                }
            }
            else //Direction.MoveRight
            {
                if (animation == Animation.Idle)
                {
                    retRectangle = new RectangleLinkMoveRightIdle();
                }
                else if (animation == Animation.Walk)
                {
                    retRectangle = new RectangleLinkMoveRightWalk();
                }
                else if (animation == Animation.Attack)
                {
                    retRectangle = new RectangleLinkMoveRightAttack();
                }
                else //Animation.UsingItem
                {
                    retRectangle = new RectangleLinkMoveRightItem();
                }
            }
            return retRectangle;
        }

        private int FindLinkHeight(Direction direction, Animation animation, int frame)
        {
            int ret = LinkConstants.LINKSIZENORMAL;
            if(animation == Animation.Attack && (direction == Direction.Up || direction == Direction.Down))
            {
                switch(frame)
                {
                    case 1:
                        ret = LinkConstants.LINKSIZEATTACKYFRAME1;
                        break;
                    case 2:
                        ret = LinkConstants.LINKSIZEATTACKYFRAME2;
                        break;
                    case 3:
                        ret = LinkConstants.LINKSIZEATTACKYFRAME3;
                        break;
                    default:
                        break;
                }
            }
            return ret;
        }

        private int FindLinkWidth(Direction direction, Animation animation, int frame)
        {
            int ret = LinkConstants.LINKSIZENORMAL;
            if (animation == Animation.Attack && (direction == Direction.Left || direction == Direction.Right))
            {
                switch (frame)
                {
                    case 1:
                        ret = LinkConstants.LINKSIZEATTACKXFRAME1;
                        break;
                    case 2:
                        ret = LinkConstants.LINKSIZEATTACKXFRAME2;
                        break;
                    case 3:
                        ret = LinkConstants.LINKSIZEATTACKXFRAME3;
                        break;
                    default:
                        break;
                }
            }
            return ret;
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
