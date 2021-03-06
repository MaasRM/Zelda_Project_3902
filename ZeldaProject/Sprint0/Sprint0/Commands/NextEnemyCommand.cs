﻿using System;
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
            nonPlayers.Add(new Stalfos(520, 222, 16, 16, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Keese(520, 222, 16, 16, KeeseStateMachine.KeeseColor.Blue, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Gel(520, 222, 8, 16, GelStateMachine.GelColor.Teal, game.GetEnemySpriteSheet()));
            nonPlayers.Add(new Goriya(520, 222, 16, 16, GoriyaStateMachine.GoriyaColor.Red, game.GetEnemySpriteSheet()));
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