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
            nonPlayers.Add(new Gel(520, 222, 8, 16, GelStateMachine.GelColor.Teal, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Goriya(520, 222, 16, 16, GoriyaStateMachine.GoriyaColor.Red, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Aquamentus(520, 222, game.getBossSpriteSheet(), (Link)game.GetPlayer()));
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