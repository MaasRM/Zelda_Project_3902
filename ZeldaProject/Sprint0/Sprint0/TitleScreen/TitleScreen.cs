using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class TitleScreen
    {
        private Texture2D titleSheet;
        private int frames;
        private int sheet;
        private int fade;
        private int dest1Y;
        private int dest2Y;
        private int dest3Y;
        private int dest1Count = 7;
        private int dest2Count = 0;
        private int dest3Count = 1;
        private Boolean blackScreen;
        private List<Rectangle> paleTri;
        private List<Rectangle> goldTri;
        private List<Rectangle> orngTri;
        private List<Rectangle> brwnTri;
        private List<Rectangle> fadeOut;
        private List<Rectangle> storyItems;
        private Rectangle destination; // the whole screen


        public TitleScreen(Texture2D titleSpriteSheet, int width, int height)
        {
            titleSheet = titleSpriteSheet;
            frames = 0;
            sheet = 0;
            fade = 0;
            dest1Count = 7;
            dest2Count = 0;
            dest3Count = 1;
            blackScreen = true;
            dest1Y = 0;
            dest2Y = TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE;
            dest3Y = 2 * TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE;

            destination = new Rectangle(0, 30, TitleScreenConstants.TITLEWIDTH * GameConstants.SCALE, TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE);

            paleTri = new List<Rectangle>();
            goldTri = new List<Rectangle>();
            orngTri = new List<Rectangle>();
            brwnTri = new List<Rectangle>();
            fadeOut = new List<Rectangle>();
            storyItems = new List<Rectangle>();

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

            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN1, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN2, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN3, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN4, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN5, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN6, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN7, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
            storyItems.Add(new Rectangle(TitleScreenConstants.COLUMN8, TitleScreenConstants.STORYROW, TitleScreenConstants.TITLEWIDTH, TitleScreenConstants.TITLEHEIGHT));
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (fade >= 88)
            {
                if (sheet < 19)
                {
                    _spriteBatch.Draw(titleSheet, destination, fadeOut[sheet], Color.White);
                }
                else
                {
                    dest1Y -= 1;
                    dest2Y -= 1;
                    dest3Y -= 1;

                    Rectangle dest1 = new Rectangle(0, dest1Y, TitleScreenConstants.TITLEWIDTH * GameConstants.SCALE, TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE);
                    Rectangle dest2 = new Rectangle(0, dest2Y, TitleScreenConstants.TITLEWIDTH * GameConstants.SCALE, TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE);
                    Rectangle dest3 = new Rectangle(0, dest3Y, TitleScreenConstants.TITLEWIDTH * GameConstants.SCALE, TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE);

                    if (dest1Y < -(TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE))
                    {
                        dest1Y = 2 * TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE;
                        
                        if(blackScreen && dest1Count == 7)
                        {
                            dest1Count = -1;
                            blackScreen = false;
                        }
                        dest1Count += 3;
                        if (dest1Count >= 8)
                        {
                            dest1Count = 7;
                        }
                    }

                    if (dest2Y < -(TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE))
                    {
                        dest2Y = 2 * TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE;
                        dest2Count += 3;
                        if (dest2Count >= 8)
                        {
                            dest2Count = 7;
                        }
                    }

                    if (dest3Y < -(TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE))
                    {
                        dest3Y = 2 * TitleScreenConstants.TITLEHEIGHT * GameConstants.SCALE;
                        dest3Count += 3;
                        if (dest3Count >= 8)
                        {
                            dest3Count = 7;
                        }
                    }
                    
                    if(dest1Count == 7 && dest2Count == 7 && dest3Count == 7)
                    {
                        resetFrames();
                    }
                    else if (dest1Count < 8 || dest2Count < 8 || dest3Count < 8)
                    {
                        _spriteBatch.Draw(titleSheet, dest1, storyItems[dest1Count], Color.White);
                        _spriteBatch.Draw(titleSheet, dest2, storyItems[dest2Count], Color.White);
                        _spriteBatch.Draw(titleSheet, dest3, storyItems[dest3Count], Color.White);
                    }     
                }
            }
            else if (fade % 12 == 0 || fade % 12 == 1 || fade % 12 == 2)
            {
                _spriteBatch.Draw(titleSheet, destination, paleTri[sheet], Color.White);
            }
            else if (fade % 12 == 3 || fade % 12 == 4 || fade % 12 == 5)
            {
                _spriteBatch.Draw(titleSheet, destination, goldTri[sheet], Color.White);
            }
            else if (fade % 12 == 6 || fade % 12 == 7 || fade % 12 == 8)
            {
                _spriteBatch.Draw(titleSheet, destination, orngTri[sheet], Color.White);
            }
            else if (fade % 12 == 9 || fade % 12 == 10 || fade % 12 == 11)
            {
                _spriteBatch.Draw(titleSheet, destination, brwnTri[sheet], Color.White);
            }
        }

        public void Update()
        {
            frames++;

            if (frames % 2 == 0 && sheet < 19) sheet++;

            if (fade > 88 && sheet < 19)
            {
                fade++;
            }
            else if (sheet > 3 && fade < 88)
            {
                sheet = 0;
                fade++;
            }
        }

        public void resetFrames()
        {
            frames = 0;
            sheet = 0;
            fade = 0;
            dest1Y = 0;
            dest2Y = 0;
            dest1Count = 7;
            dest2Count = 0;
            dest3Count = 1;
            blackScreen = true;
        }
    }
}
