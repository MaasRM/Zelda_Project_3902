//Code by: Nathan Schultz, edited by Riley Maas for Sprint3

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;

namespace Sprint0
{
	public class MouseController : IController
	{
		private NextRoomCommand nextRoom;
		private PreviousRoomCommand previousRoom;

		public MouseController(Sprint3 game)
		{
			nextRoom = new NextRoomCommand(game);
			previousRoom = new PreviousRoomCommand(game);
		}

		public void SetCommands(Sprint3 game)
        {

        }

		public void Update()
		{
			MouseState state = Mouse.GetState();
			
			if (state.LeftButton == ButtonState.Pressed)
            {
				previousRoom.Execute();
            } else if (state.RightButton == ButtonState.Pressed)
			{
				nextRoom.Execute();
            }
		}
	}
}