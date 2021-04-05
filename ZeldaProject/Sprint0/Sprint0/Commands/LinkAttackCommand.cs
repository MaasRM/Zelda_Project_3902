using System;
namespace Sprint0
{
    public class LinkAttackCommand: ICommand
    {
        private Sprint4 game;
        public LinkAttackCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Link_soundEffects[8].Play();
            this.game.GetPlayer().getLinkStateMachine().setAttack();

            if (game.GetPlayer().getLinkStateMachine().ReadyToFire())
            {
                game.AddProjectile(new SwordProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game));
            }
        }
    }
}
