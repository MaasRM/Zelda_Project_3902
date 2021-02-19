using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class NextEnemyCommand : ICommand
    {
        private Sprint2 game;
        private List<INPC> nonPlayers;
        public NextEnemyCommand(Sprint2 sprint)
        {
            game = sprint;
            nonPlayers = new List<INPC>();
            nonPlayers.Add(new Stalfos(520, 222, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Keese(520, 222, KeeseStateMachine.KeeseColor.Blue, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Gel(520, 222, GelStateMachine.GelColor.Teal, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Goriya(520, 222, GoriyaStateMachine.GoriyaColor.Red, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Trap(400, 240, game.GetEnemySpriteSheet(), game.GetPlayer()));
            nonPlayers.Add(new Wallmaster(400, 400, WallmasterStateMachine.Direction.Down, game.GetEnemySpriteSheet(), game.GetPlayer()));
            nonPlayers.Add(new Aquamentus(520, 222, game.GetBossSpriteSheet(), game.GetPlayer()));
            nonPlayers.Add(new OldMan(520, 222, game.GetNPCSpriteSheet()));
        }

        public void Execute()
        {
            int index = game.GetNPCIndex();
            index++;
            if (index > nonPlayers.Count - 1)
            {
                index = 0;
            }

            game.UpdateNPC(nonPlayers[index]);
            game.SetNPCIndex(index);
        }
    }
}