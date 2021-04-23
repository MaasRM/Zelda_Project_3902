using System;
namespace Sprint0
{
    public class LinkAttackCommand: ICommand
    {
        private Sprint5 game;
        public LinkAttackCommand(Sprint5 sprint)
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
            if (!alreadyExists && game.GetPlayer().getLinkStateMachine().healthAndDamage.Health() == game.GetPlayer().getLinkStateMachine().healthAndDamage.GetMaxHealth())
            {
                game.AddProjectile(new SwordProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game.GetPlayer().getLinkColor(), game));
            }
        }
    }
}
