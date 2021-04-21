﻿using Microsoft.Xna.Framework;
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
            if(stateMachine.getAnimation() == Animation.Attack) source.Offset(linkInventory.getLinkSword().getXOffset(), 0);
            destination = stateMachine.getDestination();

            linkInventory.healthBar.setCurrentHealth(stateMachine.healthAndDamage.Health());
            linkInventory.healthBar.setMaxHealth(stateMachine.healthAndDamage.GetMaxHealth());

            if (stateMachine.getColor() == LinkColor.Damaged && damageFrameCount <= 8)
            {
                linkSpriteSheet = linkSheetList[(damageFrameCount + 1) % 4];
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
                linkSpriteSheet = linkSheetList[(int)currentColor];
            }
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
            currentColor = newColor;
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
            double multiplier = 1.0;

            if(stateMachine.getColor() == LinkColor.Red || stateMachine.getColor() == LinkColor.Black)
            {
                multiplier *= 2;
            }
            if(stateMachine.getColor() == LinkColor.Blue)
            {
                multiplier /= 2;
            }

            int finalDamage = (int)(stateMachine.healthAndDamage.DealDamage() * multiplier);

            if (finalDamage == 0) finalDamage = 1;

            return finalDamage;
        }

        public void Heal(int health)
        {
            stateMachine.healthAndDamage.Heal(health);
        }

        public void SetDamageState(int damage, Vector2 direction)
        {
            if(stateMachine.getColor() != LinkColor.Damaged)
            {
                double multiplier = 1.0;

                if (stateMachine.getColor() == LinkColor.Red || stateMachine.getColor() == LinkColor.Black)
                {
                    multiplier *= 2;
                }
                if (stateMachine.getColor() == LinkColor.Blue)
                {
                    multiplier /= 2;
                }

                int finalDamage = (int)(damage * multiplier);

                if (finalDamage == 0) finalDamage = 1;

                damageFrameCount = 0;
                if(!stateMachine.IsBusy())soundEffects[10].Play();
                stateMachine.TakeDamage(finalDamage, direction);
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
