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
            nonPlayers.Add(new Stalfos(520, 222, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Keese(520, 222, KeeseStateMachine.KeeseColor.Blue, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Gel(520, 222, GelStateMachine.GelColor.Teal, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Goriya(520, 222, GoriyaStateMachine.GoriyaColor.Red, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Trap(400, 240, game.GetEnemySpriteSheet(), (Link)game.GetPlayer()));
            nonPlayers.Add(new Wallmaster(400, 400, WallmasterStateMachine.Direction.Down, game.GetEnemySpriteSheet(), (Link)game.GetPlayer()));
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