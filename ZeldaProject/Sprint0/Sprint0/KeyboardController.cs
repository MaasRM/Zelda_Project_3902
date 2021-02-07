//Code by: Nathan Schultz

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	public class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> controllerMappings;

		public KeyboardController(Sprint2 game)
		{
			controllerMappings = new Dictionary<Keys, ICommand>();
			//Needs to add item swap for link
			controllerMappings.Add(Keys.W, new LinkFaceUpCommand(game));
			controllerMappings.Add(Keys.Up, new LinkFaceUpCommand(game));
			controllerMappings.Add(Keys.A, new LinkFaceLeftCommand(game));
			controllerMappings.Add(Keys.Left, new LinkFaceLeftCommand(game));
			controllerMappings.Add(Keys.D, new LinkFaceRightCommand(game));
			controllerMappings.Add(Keys.Right, new LinkFaceRightCommand(game));
			controllerMappings.Add(Keys.S, new LinkFaceDownCommand(game));
			controllerMappings.Add(Keys.Down, new LinkFaceDownCommand(game));
			controllerMappings.Add(Keys.N, new LinkAttackCommand(game));
			controllerMappings.Add(Keys.Z, new LinkAttackCommand(game));
			controllerMappings.Add(Keys.E, new DamageLinkCommand(game));
			controllerMappings.Add(Keys.Q, new QuitCommand(game));
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
