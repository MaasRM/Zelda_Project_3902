using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class TextSprite : ISprite
    {

        private Texture2D letterSheet; 
        private Rectangle destination;
        private Rectangle source;

        //x then y so grouped in twos
        //size is always 7x5
        private int[] letterSources = 
            { 57, 11, 41, 11, 113, 11, 113, 19, 89, 11, 96, 11, 113, 11, 113, 19, //eastmost
              65, 26, 97, 19, 57, 11, 89, 19, 89, 19, 72, 11, 89, 19, 113, 11, 121, 11, 82, 19, 41, 11, // penninsula
              89, 19};
        private int[] letterDest;

        public TextSprite(Texture2D dungeonSheet)
        {
            letterSheet = dungeonSheet;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //spriteBatch.Draw();

            spriteBatch.End();
        }
    }
}
