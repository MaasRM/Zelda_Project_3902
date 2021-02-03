//Code by: Nathan Schultz

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	public class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> controllerMappings;

		public KeyboardController(Sprint0 game)
		{
			controllerMappings = new Dictionary<Keys, ICommand>();
			controllerMappings.Add(Keys.NumPad0, new QuitCommand(game));
			controllerMappings.Add(Keys.NumPad1, new StationaryStillStateCommand(game));
			controllerMappings.Add(Keys.NumPad2, new StationaryAnimatedStateCommand(game));
			controllerMappings.Add(Keys.NumPad3, new MovingStillStateCommand(game));
			controllerMappings.Add(Keys.NumPad4, new MovingAnimatedStateCommand(game));
			controllerMappings.Add(Keys.D0, new QuitCommand(game));
			controllerMappings.Add(Keys.D1, new StationaryStillStateCommand(game));
			controllerMappings.Add(Keys.D2, new StationaryAnimatedStateCommand(game));
			controllerMappings.Add(Keys.D3, new MovingStillStateCommand(game));
			controllerMappings.Add(Keys.D4, new MovingAnimatedStateCommand(game));
		}

		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
                if (controllerMappings.ContainsKey(key))
				{
					controllerMappings[key].Execute();
				}
			}
		}
	}
}
