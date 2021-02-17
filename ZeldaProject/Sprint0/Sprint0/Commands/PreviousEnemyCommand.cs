using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class PreviousEnemyCommand : ICommand
    {
        private Sprint2 game;
        private List<INPC> nonPlayers;
        public PreviousEnemyCommand(Sprint2 sprint)
        {
            game = sprint;
            nonPlayers = new List<INPC>();
            nonPlayers.Add(new Stalfos(520, 222, 16, 16, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Keese(520, 222, 16, 16, KeeseStateMachine.KeeseColor.Blue, game.GetEnemySpriteSheet()));
        }

        public void Execute()
        {
            int index = game.GetNPCIndex();
            index--;
            if (index < 0)
            {
                index = nonPlayers.Count - 1;
            }

            game.UpdateNPC(nonPlayers[index]);
            game.SetNPCIndex(index);
        }
    }
}