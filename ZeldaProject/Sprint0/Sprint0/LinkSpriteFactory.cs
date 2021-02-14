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
        }

        public Rectangle getSourceRectangle(Direction direction, LinkColor color, Animation animation, int frame)
        {
            //Use params to get proper rectangle from sprite sheet and update height and width
            ILinkRectangle linkRectangle;
            Rectangle retRectangle;
            if (direction == Direction.MoveUp)
            {
                if (animation == Animation.Idle)
                {
                    linkRectangle = new RectangleLinkMoveUpIdle();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                } 
                else if (animation == Animation.Walk)
                {
                    linkRectangle = new RectangleLinkMoveUpWalk();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                } 
                else if (animation == Animation.Attack)
                {
                    linkRectangle = new RectangleLinkMoveUpAttack();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                } 
                else if (animation == Animation.UsingItem)
                {
                    linkRectangle = new RectangleLinkMoveUpItem();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                } 
                else //Animation.IsDamaged
                {

                }
            } else if (direction == Direction.MoveDown)
            {
                if (animation == Animation.Idle)
                {
                    linkRectangle = new RectangleLinkMoveDownIdle();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                }
                else if (animation == Animation.Walk)
                {
                    linkRectangle = new RectangleLinkMoveDownWalk();
                    retRectangle = linkRectangle.getRectangle(color, frame);
                }
                else if (animation == Animation.Attack)
                {

                }
                else if (animation == Animation.UsingItem)
                {

                }
                else //Animation.IsDamaged
                {

                }
            } else if (direction == Direction.MoveLeft)
            {
                if (animation == Animation.Idle)
                {
                    retRectangle =
                }
                else if (animation == Animation.Walk)
                {

                }
                else if (animation == Animation.Attack)
                {

                }
                else if (animation == Animation.UsingItem)
                {

                }
                else //Animation.IsDamaged
                {

                }
            } else //Direction.MoveRight
            {
                if (animation == Animation.Idle)
                {
                    retRectangle =
                }
                else if (animation == Animation.Walk)
                {

                }
                else if (animation == Animation.Attack)
                {

                }
                else if (animation == Animation.UsingItem)
                {

                }
                else //Animation.IsDamaged
                {

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
