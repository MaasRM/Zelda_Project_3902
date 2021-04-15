using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.GameStates
{
    public class GameStateManager
    {
        private ContentManager _content;

        // Instance of the game state manager     
        private static GameStateManager _instance;

        // Stack for the screens     
        private Stack<GameState> _screens = new Stack<GameState>();

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameStateManager();
                }
                return _instance;
            }
        }

        // Sets the content manager
        public void SetContent(ContentManager content)
        {
            _content = content;
        }

        // Adds a new screen to the stack 
        public void AddScreen(GameState screen)
        {

            // Add the screen to the stack
            _screens.Push(screen);
            // Initialize the screen
            _screens.Peek().Initialize();
            // Call the LoadContent on the screen
            if (_content != null)
            {
                _screens.Peek().LoadContent(_content);
            }
        }

        // Removes the top screen from the stack
        public void RemoveScreen()
        {
            if (_screens.Count > 0)
            {
                var screen = _screens.Peek();
                _screens.Pop();
            }
        }

        // Clears all the screen from the list
        public void ClearScreens()
        {
            while (_screens.Count > 0)
            {
                _screens.Pop();
            }
        }
        
        // Removes all screens from the stack and adds a new one 
        public void ChangeScreen(GameState screen)
        {
            ClearScreens();
            AddScreen(screen);
        }

        // Updates the top screen. 
        public void Update(GameTime gameTime)
        {
            if (_screens.Count > 0)
            {
                _screens.Peek().Update(gameTime);
            }
        }

        // Renders the top screen.
        public void Draw(GameTime gameTime)
        {
            if (_screens.Count > 0)
            {
                _screens.Peek().Draw(gameTime);
            }
        }

        // Unloads the content from the screen
        public void UnloadContent()
        {
            foreach (GameState state in _screens)
            {
                state.UnloadContent();
            }
        }
    }
}
