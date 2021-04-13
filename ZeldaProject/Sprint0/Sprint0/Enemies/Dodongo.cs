using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class Dodongo
    {
        private DodongoStateMachine stateMachine;
        private List<Texture2D> dodongoSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private int DAMAGE = 2;
        private Tuple<int, int> init;

        public Dodongo(int x, int y, List<Texture2D> spriteSheet)
        {
            stateMachine = new DodongoStateMachine(x, y);
            dodongoSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int>(x, y);
        }
    }
}
