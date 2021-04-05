using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;

namespace Sprint0
{
	public class PauseController : IController
	{
		private Dictionary<Keys, ICommand> pauseCommands;

		public PauseController()
		{
			pauseCommands = new Dictionary<Keys, ICommand>();
		}

		public void SetCommands(Sprint3 game)
		{
			/*pauseCommands.Add(Keys.W, new LinkFaceUpCommand(game));
			pauseCommands.Add(Keys.Up, new LinkFaceUpCommand(game));
			pauseCommands.Add(Keys.A, new LinkFaceLeftCommand(game));
			pauseCommands.Add(Keys.Left, new LinkFaceLeftCommand(game));
			pauseCommands.Add(Keys.D, new LinkFaceRightCommand(game));
			pauseCommands.Add(Keys.Right, new LinkFaceRightCommand(game));
			pauseCommands.Add(Keys.S, new LinkFaceDownCommand(game));
			pauseCommands.Add(Keys.Down, new LinkFaceDownCommand(game)); */
			pauseCommands.Add(Keys.I, new InventoryCommand(game));

			//Commands for quit and reset			
			pauseCommands.Add(Keys.R, new ResetGameCommand(game));
			pauseCommands.Add(Keys.Q, new QuitCommand(game));
			pauseCommands.Add(Keys.Escape, new QuitCommand(game));
		}

		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				if (pauseCommands.ContainsKey(key))
				{
					pauseCommands[key].Execute();
				}
			}
		}
	}
}