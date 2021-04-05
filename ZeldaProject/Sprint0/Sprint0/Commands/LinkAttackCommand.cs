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
            this.game.GetPlayer().getLinkStateMachine().setAnimation(Animation.Attack);

            Boolean alreadyExists = false;
            foreach (IProjectile proj in game.GetProjectiles())
            {
                if (proj is SwordProjectile || proj is SwordBlastProjectile) alreadyExists = true;
            }
            if (!alreadyExists && game.GetPlayer().getLinkStateMachine().GetCurrentHealth() == LinkConstants.STARTHEALTH)
            {
                game.AddProjectile(new SwordProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game));
            }
        }
    }
}
