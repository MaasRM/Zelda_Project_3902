using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class LinkSpriteFactory
{
    public enum Direction
    {
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight
    }

    public enum Color
    {
        Green,
        Red,
        White
    }

    public enum Animation
    {
        Idle,
        Walk,
        Attack
    }

    public LinkSpriteFactory()
    {

    }

    public Rectangle getRectangle(Direction direction, Color color, Animation animation, Boolean useItem, Boolean isDamaged)
    {
        //call methods to check state
    }

}
