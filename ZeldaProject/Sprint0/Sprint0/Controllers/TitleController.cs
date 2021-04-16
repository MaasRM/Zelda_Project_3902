using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	public class TitleController : IController
	{
		private Dictionary<Keys, ICommand> titleCommands;

		public TitleController()
		{
			titleCommands = new Dictionary<Keys, ICommand>();
		}

		public void SetCommands(Sprint5 game)
		{
			titleCommands.Add(Keys.Enter, new StartGameCommand(game));
			titleCommands.Add(Keys.T, new TopOfTitleScreenCommand(game));

			//Commands for quit and reset			
			titleCommands.Add(Keys.R, new ResetGameCommand(game));
			titleCommands.Add(Keys.Q, new QuitCommand(game));
			titleCommands.Add(Keys.Escape, new QuitCommand(game));
		}

		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
			foreach (Keys key in pressedKeys)
			{
				if (titleCommands.ContainsKey(key))
				{
					titleCommands[key].Execute();
				}
			}
		}
	}
}