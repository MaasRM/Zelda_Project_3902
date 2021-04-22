using System;
namespace Sprint0
{
    public static class GohmaConstants
    {
        public const int WIDTH = 48;
        public const int HEIGHT = 16;
        public const int moveDist = 2;
        public const int FIRECHANCE = 30;
        public const int FIRECOOLDOWN = 10;
        public const int CHANGEDIRECTIONFRAME = 8;
        public const int EYETRANSITIONFRAMES = 2;
        public const int EYEOPENFRAMES = 10;
        public const int CLOSEFRAMEMAX = 20;
        public static Direction[] Directions = { Direction.Right, Direction.Down, Direction.Up, Direction.Right, Direction.Left, Direction.Down, Direction.Up, Direction.Left };
    }
}
