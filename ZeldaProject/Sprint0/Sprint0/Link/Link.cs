using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Sprint0
{
    public class Link : IPlayer
    {
        private LinkStateMachine stateMachine;
        private LinkInventory linkInventory;
        private Texture2D linkSpriteSheet;
        private List<Texture2D> linkSheetList;
        private List<SoundEffect> soundEffects;
        private Rectangle source;
        private Rectangle destination;
        private LinkColor currentColor;
        private int damageFrameCount;

        public Link(Texture2D spriteSheet, List<Texture2D> linkSheetList, List<SoundEffect> Link_soundEffects,  Texture2D inventory)
        {
            stateMachine = new LinkStateMachine(Link_soundEffects);
            this.linkSheetList = linkSheetList;
            linkSpriteSheet = spriteSheet;
            currentColor = LinkColor.Green;
            damageFrameCount = 0;
            soundEffects = Link_soundEffects;
            linkInventory = new LinkInventory(inventory);
        }

        public void Update()
        {
            stateMachine.Update();
            source = stateMachine.getSource();
            destination = stateMachine.getDestination();

            linkInventory.GetLinkHealthBar().setCurrentHealth(stateMachine.GetCurrentHealth());
            linkInventory.GetLinkHealthBar().setMaxHealth(stateMachine.GetMaxHealth());

            if (stateMachine.getColor() == LinkColor.Damaged && damageFrameCount <= 8)
            {
                if (damageFrameCount % 4 == 0) linkSpriteSheet = linkSheetList[1];
                else if (damageFrameCount % 4 == 1) linkSpriteSheet = linkSheetList[2];
                else if (damageFrameCount % 4 == 2) linkSpriteSheet = linkSheetList[3];
                else linkSpriteSheet = linkSheetList[0];
                if (damageFrameCount == 8)
                {
                    stateMachine.setOriginalColor();
                    stateMachine.damageVector = new Vector2(0, 0);
                }

                damageFrameCount++;
            }
            else
            {
                damageFrameCount = 0;
                linkSpriteSheet = linkSheetList[0];
            }
            currentColor = stateMachine.getColor();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (stateMachine.getDirection() == Direction.MoveLeft)
            {
                spriteBatch.Draw(linkSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(linkSpriteSheet, destination, source, Color.White);
            }
        }

        public void changeColor(LinkColor currentColor, LinkColor newColor)
        {
            Color[] data = new Color[linkSpriteSheet.Width * linkSpriteSheet.Height];
            linkSpriteSheet.GetData(data);
            Color colorTo;
            Color green = new Color(128, 208, 16, 255);
            Color red = new Color(216, 40, 0, 255);
            Color white = new Color(196, 212, 252, 255);

            if (newColor == LinkColor.Green)
            {
                colorTo = green;
            }
            else if (newColor == LinkColor.Red)
            {
                colorTo = red;
            }
            else //LinkColor.White
            {
                colorTo = white;
            }

            if (currentColor == LinkColor.Green)
            {
                for (int i = 0; i < data.Length; i++)
                    if (data[i] == green)
                        data[i] = colorTo;
            }
            else if (currentColor == LinkColor.Red)
            {
                for (int i = 0; i < data.Length; i++)
                    if (data[i] == red)
                        data[i] = colorTo;
            }
            else //LinkColor.White
            {
                for (int i = 0; i < data.Length; i++)
                    if (data[i] == white)
                        data[i] = colorTo;
            }

            linkSpriteSheet.SetData(data);
        }

        public LinkInventory GetLinkInventory()
        {
            return linkInventory;
        }

        public LinkStateMachine getLinkStateMachine()
        {
            return stateMachine;
        }

        public Texture2D GetSpriteSheet()
        {
            return linkSpriteSheet;
        }

        public Rectangle LinkPosition()
        {
            return destination;
        }

        public void SetPosition(Rectangle newPos)
        {
            stateMachine.SetPositions(newPos);
        }

        public void MakeImmobile()
        {
            stateMachine.MakeBusy();
        }

        public bool Attacking()
        {
            return stateMachine.getAnimation() == Animation.Attack;
        }

        public int GetMeleeDamage()
        {
            return stateMachine.GetDamage();
        }

        public void Heal(int health)
        {
            stateMachine.Heal(health);
        }

        public void SetDamageState(int damage, Vector2 direction)
        {
            if(stateMachine.getColor() != LinkColor.Damaged)
            {
                damageFrameCount = 0;
                soundEffects[10].Play();
                stateMachine.TakeDamage(damage, direction);
            }
        }

        public bool IsAlive()
        {
            if (!stateMachine.HasHealth())
            {
                soundEffects[9].Play();
            }
            return stateMachine.HasHealth();
        }

        public void Reset()
        {
            stateMachine = new LinkStateMachine(soundEffects);
        }
    }
}
