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
            Rectangle retRectangle;
            if (direction == Direction.MoveUp)
            {
                if (color == LinkColor.Green)
                {
                    if (animation == Animation.Idle)
                    {

                    } else if (animation == Animation.Walk)
                    {

                    } else if (animation == Animation.Attack)
                    {

                    } else if (animation == Animation.UsingItem)
                    {

                    } else //Animation.IsDamaged
                    {

                    }
                } else if (color == LinkColor.Red)
                {
                    if (animation == Animation.Idle)
                    {

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
                } else //LinkColor.White
                {
                    if (animation == Animation.Idle)
                    {

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
            } else if (direction == Direction.MoveDown)
            {
                if (color == LinkColor.Green)
                {
                    if (animation == Animation.Idle)
                    {

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
                else if (color == LinkColor.Red)
                {
                    if (animation == Animation.Idle)
                    {

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
                else //LinkColor.White
                {
                    if (animation == Animation.Idle)
                    {

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
            } else if (direction == Direction.MoveLeft)
            {
                if (color == LinkColor.Green)
                {
                    if (animation == Animation.Idle)
                    {

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
                else if (color == LinkColor.Red)
                {
                    if (animation == Animation.Idle)
                    {

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
                else //LinkColor.White
                {
                    if (animation == Animation.Idle)
                    {

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
            } else //Direction.MoveRight
            {
                if (color == LinkColor.Green)
                {
                    if (animation == Animation.Idle)
                    {

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
                else if (color == LinkColor.Red)
                {
                    if (animation == Animation.Idle)
                    {

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
                else //LinkColor.White
                {
                    if (animation == Animation.Idle)
                    {

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
