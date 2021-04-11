using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	public class PauseController : IController
	{
		private Dictionary<Keys, ICommand> pauseCommands;

		public PauseController()
		{
			pauseCommands = new Dictionary<Keys, ICommand>();
		}

		public void SetCommands(Sprint4 game)
		{
			pauseCommands.Add(Keys.W, new InventorySelectUpCommand(game));
			pauseCommands.Add(Keys.Up, new InventorySelectUpCommand(game));
			pauseCommands.Add(Keys.A, new InventorySelectLeftCommand(game));
			pauseCommands.Add(Keys.Left, new InventorySelectLeftCommand(game));
			pauseCommands.Add(Keys.D, new InventorySelectRightCommand(game));
			pauseCommands.Add(Keys.Right, new InventorySelectRightCommand(game));
			pauseCommands.Add(Keys.S, new InventorySelectDownCommand(game));
			pauseCommands.Add(Keys.Down, new InventorySelectDownCommand(game));
			pauseCommands.Add(Keys.X, new InventoryUnPauseCommand(game));
			pauseCommands.Add(Keys.M, new InventoryUnPauseCommand(game));

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