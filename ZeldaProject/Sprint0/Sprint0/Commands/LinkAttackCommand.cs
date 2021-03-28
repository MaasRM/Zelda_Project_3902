using System;
namespace Sprint0
{
    public class LinkAttackCommand: ICommand
    {
        private Sprint3 game;
        public LinkAttackCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Link_soundEffects[8].Play();
            this.game.GetPlayer().getLinkStateMachine().setAttack();

            if (game.GetPlayer().getLinkStateMachine().ReadyToFire())
            {
                game.AddProjectile(new SwordProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine()));
            }
        }
    }
}
