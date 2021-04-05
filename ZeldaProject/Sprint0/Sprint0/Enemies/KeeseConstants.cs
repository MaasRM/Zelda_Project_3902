using System;
namespace Sprint0
{
    public static class KeeseConstants
    {
        public const int DIRECTIONCHANGEFRAME = 10;
        public const int WIDTHANDHEIGHT = 16;
        public const int MAXHEALTH = 1;
        public const int FRAMESCALE = 5;
        public const int WAITFRAMEDIVISOR = 4;
        public const int MOVEFRAMEDIVISOR = 9;
        public static int SLOWFRAMECOUNT = 30;
        public static double axialMoveDist = 3;
        public static double diagonalMoveDist = axialMoveDist * Math.Sqrt(2.0);
        public static KeeseStateMachine.Movement[] movements = new KeeseStateMachine.Movement[] { KeeseStateMachine.Movement.Slow, KeeseStateMachine.Movement.Fast, KeeseStateMachine.Movement.Slow, KeeseStateMachine.Movement.Wait };
    }
}
