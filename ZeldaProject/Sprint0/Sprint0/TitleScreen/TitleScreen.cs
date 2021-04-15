using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class TitleScreen
    {
        Texture2D titleSheet;
        private List<Rectangle> paleTri;
        private List<Rectangle> goldTri;
        private List<Rectangle> orngTri;
        private List<Rectangle> brwnTri;
        private List<Rectangle> fadeOut;
        private List<Rectangle> storyItems;
        private Rectangle destination; // the whole screen


        public TitleScreen(Texture2D titleSpriteSheet)
        {
            titleSheet = titleSpriteSheet;
            InitializeLists();
        }

        private void InitializeLists()
        {
            paleTri.Add(new Rectangle(TitleScreenConstants.COLUMN4, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            paleTri.Add(new Rectangle(TitleScreenConstants.COLUMN3, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            paleTri.Add(new Rectangle(TitleScreenConstants.COLUMN2, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            paleTri.Add(new Rectangle(TitleScreenConstants.COLUMN1, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));

            goldTri.Add(new Rectangle(TitleScreenConstants.COLUMN8, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            goldTri.Add(new Rectangle(TitleScreenConstants.COLUMN7, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            goldTri.Add(new Rectangle(TitleScreenConstants.COLUMN6, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            goldTri.Add(new Rectangle(TitleScreenConstants.COLUMN5, TitleScreenConstants.ROW1, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));

            orngTri.Add(new Rectangle(TitleScreenConstants.COLUMN4, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            orngTri.Add(new Rectangle(TitleScreenConstants.COLUMN3, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            orngTri.Add(new Rectangle(TitleScreenConstants.COLUMN2, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            orngTri.Add(new Rectangle(TitleScreenConstants.COLUMN1, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));

            brwnTri.Add(new Rectangle(TitleScreenConstants.COLUMN8, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            brwnTri.Add(new Rectangle(TitleScreenConstants.COLUMN7, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            brwnTri.Add(new Rectangle(TitleScreenConstants.COLUMN6, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            brwnTri.Add(new Rectangle(TitleScreenConstants.COLUMN5, TitleScreenConstants.ROW2, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));

            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN4, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN3, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN2, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN1, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN8, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN7, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN6, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN5, TitleScreenConstants.ROW3, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN4, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN3, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN2, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN1, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN8, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN7, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN6, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN5, TitleScreenConstants.ROW4, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN4, TitleScreenConstants.ROW5, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN3, TitleScreenConstants.ROW5, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN2, TitleScreenConstants.ROW5, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            fadeOut.Add(new Rectangle(TitleScreenConstants.COLUMN1, TitleScreenConstants.ROW5, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));

            //determine which items will be in the final game before creating
        }

        public void Draw()
        {

        }

        public void Update()
        {

        }
    }
}
