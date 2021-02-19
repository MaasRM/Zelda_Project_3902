//Code by: Nathan Schultz

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;

namespace Sprint0
{
	public class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> linkActions;
		private Dictionary<Keys, ICommand> otherCommands;
		private ICommand linkIdleCommand;

		public KeyboardController()
		{
			linkActions = new Dictionary<Keys, ICommand>();
			otherCommands = new Dictionary<Keys, ICommand>();
		}

		public void SetCommands(Sprint2 game)
        {
			linkActions.Add(Keys.W, new LinkFaceUpCommand(game));
			linkActions.Add(Keys.Up, new LinkFaceUpCommand(game));
			linkActions.Add(Keys.A, new LinkFaceLeftCommand(game));
			linkActions.Add(Keys.Left, new LinkFaceLeftCommand(game));
			linkActions.Add(Keys.D, new LinkFaceRightCommand(game));
			linkActions.Add(Keys.Right, new LinkFaceRightCommand(game));
			linkActions.Add(Keys.S, new LinkFaceDownCommand(game));
			linkActions.Add(Keys.Down, new LinkFaceDownCommand(game));
			linkActions.Add(Keys.N, new LinkAttackCommand(game));
			linkActions.Add(Keys.Z, new LinkAttackCommand(game));
			linkActions.Add(Keys.E, new DamageLinkCommand(game));
			linkActions.Add(Keys.D1, new LinkUseBrownArrowCommand(game));
			linkActions.Add(Keys.NumPad1, new LinkUseBrownArrowCommand(game));
			linkActions.Add(Keys.D2, new LinkUseBlueArrowCommand(game));
			linkActions.Add(Keys.NumPad2, new LinkUseBlueArrowCommand(game));
			linkActions.Add(Keys.D3, new LinkUseBrownBoomerangCommand(game));
			linkActions.Add(Keys.NumPad3, new LinkUseBrownBoomerangCommand(game));
			linkActions.Add(Keys.D4, new LinkUseBlueBoomerangCommand(game));
			linkActions.Add(Keys.NumPad4, new LinkUseBlueBoomerangCommand(game));
			linkActions.Add(Keys.D5, new LinkUseBombCommand(game));
			linkActions.Add(Keys.NumPad5, new LinkUseBombCommand(game));
			linkActions.Add(Keys.D6, new LinkUseCandleCommand(game));
			linkActions.Add(Keys.NumPad6, new LinkUseCandleCommand(game));

			linkIdleCommand = new LinkIdleCommand(game);

			//Commands for block swapping
			otherCommands.Add(Keys.T, new PreviousBlockCommand(game));
			otherCommands.Add(Keys.Y, new NextBlockCommand(game));

			//Commands for link item swaps
			otherCommands.Add(Keys.U, new PreviousItemCommand(game));
			otherCommands.Add(Keys.I, new NextItemCommand(game));
			otherCommands.Add(Keys.O, new PreviousEnemyCommand(game));
			otherCommands.Add(Keys.P, new NextEnemyCommand(game));
			otherCommands.Add(Keys.R, new ResetGameCommand(game));
			otherCommands.Add(Keys.Q, new QuitCommand(game));
		}

		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
			Boolean idleLink = true;

			foreach (Keys key in pressedKeys)
			{
                if (linkActions.ContainsKey(key))
				{
					idleLink = false;
					linkActions[key].Execute();
				}
				if (otherCommands.ContainsKey(key))
				{
					otherCommands[key].Execute();
				}
			}
			if(idleLink)
            {
				linkIdleCommand.Execute();
            }
		}
	}
}
