//Code by: Nathan Schultz, edited by Riley Maas for Sprint3

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	public class MouseController : IController
	{
		private NextRoomCommand nextRoom;
		private PreviousRoomCommand previousRoom;
		private Boolean rightIsPressed;
		private Boolean leftIsPressed;

		public MouseController(Sprint5 game)
		{
			nextRoom = new NextRoomCommand(game);
			previousRoom = new PreviousRoomCommand(game);
		}

		public void SetCommands(Sprint5 game)
        {

        }

		public void Update()
		{
			MouseState state = Mouse.GetState();

			if (state.LeftButton == ButtonState.Pressed)
			{
				leftIsPressed = true;
			}
			else if (state.RightButton == ButtonState.Pressed)
			{
				rightIsPressed = true;
			}

			if (state.LeftButton == ButtonState.Released && leftIsPressed == true)
            {
				previousRoom.Execute();
				leftIsPressed = false;
			} else if (state.RightButton == ButtonState.Released && rightIsPressed == true)
			{
				nextRoom.Execute();
				rightIsPressed = false;
            }
		}
	}
}