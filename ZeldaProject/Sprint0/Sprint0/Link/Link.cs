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

        //only used when picking up an item
        private Rectangle itemSource;
        private Rectangle itemDestination;
        private Texture2D itemSheet;

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

            linkInventory.healthBar.setCurrentHealth(stateMachine.GetCurrentHealth());
            linkInventory.healthBar.setMaxHealth(stateMachine.GetMaxHealth());

            if (stateMachine.getColor() == LinkColor.Damaged && damageFrameCount <= 8)
            {
                if (damageFrameCount % 4 == 0) linkSpriteSheet = linkSheetList[1];
                else if (damageFrameCount % 4 == 1) linkSpriteSheet = linkSheetList[2];
                else if (damageFrameCount % 4 == 2) linkSpriteSheet = linkSheetList[3];
                else linkSpriteSheet = linkSheetList[0];
                if (damageFrameCount == 8)
                {
                    stateMachine.setColor(LinkColor.Green);
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
            if (stateMachine.getDirection() == Direction.Left)
            {
                spriteBatch.Draw(linkSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(linkSpriteSheet, destination, source, Color.White);
            }
            if(getLinkStateMachine().getAnimation() == Animation.PickUpItem) spriteBatch.Draw(itemSheet, itemDestination, itemSource, Color.White);
        }

        public LinkColor getLinkColor()
        {
            return currentColor;
        }

        public void changeColor(LinkColor newColor)
        {
            stateMachine.setColor(newColor);
            if (newColor == LinkColor.Green)
            {
                linkSpriteSheet = linkSheetList[0];
            }
            else if (newColor == LinkColor.Black)
            {
                linkSpriteSheet = linkSheetList[1];
            }
            else if (newColor == LinkColor.Red)
            {
                linkSpriteSheet = linkSheetList[2];
            }
            else if (newColor == LinkColor.Blue)
            {
                linkSpriteSheet = linkSheetList[3];
            }
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

        public void GiveLinkItemPickup(Rectangle iSource, Rectangle iDest, Texture2D iSheet)
        {
            itemSource = iSource;
            int xoff = 0;
            if (iSource.Width < 15) xoff = LinkConstants.LINKSIZENORMAL * GameConstants.SCALE / 4;
            itemDestination = new Rectangle(getLinkStateMachine().getXLoc() + xoff, getLinkStateMachine().getYLoc() - (LinkConstants.LINKSIZENORMAL * GameConstants.SCALE), iDest.Width, iDest.Height);
            itemSheet = iSheet;
        }
    }
}
