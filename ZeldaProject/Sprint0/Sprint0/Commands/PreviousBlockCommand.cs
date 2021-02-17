using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace Sprint0
{
    public class PreviousBlockCommand : ICommand
    {
        private Sprint2 game;
        private IBlock newBlock;

        public PreviousBlockCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.blockIndex--;

            if (game.blockIndex < 0)
            {
                game.blockIndex = game.blockIndex + 3;
            }
            if (game.blockIndex == 0)
            {
                newBlock = new Block(new Rectangle(200, 200, 15, 15), new Rectangle(984, 11, 15, 15), game.dungeonSheet);
            }
            else if (game.blockIndex == 1)
            {
                newBlock = new Block(new Rectangle(200, 200, 15, 15), new Rectangle(1001, 11, 15, 15), game.dungeonSheet);
            }
            else if (game.blockIndex == 2)
            {
                newBlock = new Block(new Rectangle(200, 200, 15, 15), new Rectangle(1018, 11, 15, 15), game.dungeonSheet);
            }


            game.UpdateGameBlock(newBlock);
        }
    }
}