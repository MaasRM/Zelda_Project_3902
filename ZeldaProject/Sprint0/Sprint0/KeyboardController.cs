//Code by: Nathan Schultz

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	public class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> linkActions;
		private Dictionary<Keys, ICommand> otherCommands;
		private ICommand linkIdleCommand;

		public KeyboardController(Sprint2 game)
		{
			linkActions = new Dictionary<Keys, ICommand>();
			otherCommands = new Dictionary<Keys, ICommand>();
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

			linkIdleCommand = new LinkIdleCommand(game);

			//Commands for link item swaps
			otherCommands.Add(Keys.T, new PreviousItemCommand(game));
			otherCommands.Add(Keys.Y, new NextItemCommand(game));
			otherCommands.Add(Keys.U, new PreviousItemCommand(game));
			otherCommands.Add(Keys.I, new NextItemCommand(game));
			otherCommands.Add(Keys.O, new PreviousItemCommand(game));
			otherCommands.Add(Keys.P, new NextItemCommand(game));
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
					linkActions[key].Execute();
				}
			}
			if(idleLink)
            {
				linkIdleCommand.Execute();
            }
		}
	}
}
