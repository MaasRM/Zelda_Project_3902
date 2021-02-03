//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	public class MouseController : IController
	{
		private QuitCommand quit;
		private StationaryStillStateCommand standStill;
		private StationaryAnimatedStateCommand walkInPlace;
		private MovingStillStateCommand hover;
		private MovingAnimatedStateCommand walkNormal;
		private int windowWidth;
		private int windowHeight;
		

		public MouseController(Sprint0 game)
		{
			quit = new QuitCommand(game);
			standStill = new StationaryStillStateCommand(game);
			walkInPlace = new StationaryAnimatedStateCommand(game);
			hover = new MovingStillStateCommand(game);
			walkNormal = new MovingAnimatedStateCommand(game);

			windowWidth = game.GraphicsDevice.Viewport.Width;
			windowHeight = game.GraphicsDevice.Viewport.Height;
		}

		public void Update()
		{
			MouseState state = Mouse.GetState();

			if (state.LeftButton == ButtonState.Pressed)
			{
				if (state.X < windowWidth/2 && state.X >= 0)
                {
					if(state.Y < windowHeight/2 && state.Y >= 0)
					{
						standStill.Execute();
					}
                    else
                    {
						hover.Execute();
                    }
				}
				else
                {
					if (state.Y < windowHeight / 2 && state.Y >= 0)
					{
						walkInPlace.Execute();
					}
					else
					{
						walkNormal.Execute();
					}
				}
			}
			if(state.RightButton == ButtonState.Pressed)
            {
				quit.Execute();
            }
		}
	}
}