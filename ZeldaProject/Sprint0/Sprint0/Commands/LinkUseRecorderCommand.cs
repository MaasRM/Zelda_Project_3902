using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseRecorderCommand : ICommand
    {
        private Sprint5 game;
        public LinkUseRecorderCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            SoundEffectInstance temp = game.Link_soundEffects[5].CreateInstance();
            temp.Volume = 0.10f;
            temp.IsLooped = false;
            temp.Play();

            game.GetRoomManager().ChangeRoom(GameConstants.OUTSIDEROOM);
            game.ResetTriForceText();
            game.GetPlayer().getLinkStateMachine().setAnimation(Animation.UsingItem);
        }
    }
}
