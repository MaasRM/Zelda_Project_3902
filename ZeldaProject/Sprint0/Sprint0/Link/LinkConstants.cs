using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public static class LinkConstants
    {
        public static int LINKMOVESPEED = 16;
        public static int XINIT = 120;
        public static int YINIT = 192;
        public static int STARTHEALTH = 10;
        public static int LINKSIZENORMAL = 16;
        public static int LINKSIZEATTACKY = 30;
        public static int LINKSIZEATTACKXFRAME1 = 27;
        public static int LINKSIZEATTACKXFRAME2 = 23;
        public static int LINKSIZEATTACKXFRAME3 = 19;
        public static int MAXRUPEECOUNT = 99;
        public static int MAXIMUMHEALTH = 40;

        public const int OLDMANX = 60;
        public const int OLDMANY = 170;
        public const int TRIFORCE1X = 60;
        public const int TRIFORCE1Y = 155;
        public const int TRIFORCE2X = 45;
        public const int TRIFORCE2Y = 175;
        public const int TRIFORCE3X = 75;
        public const int TRIFORCE3Y = 175;
        public static int LETTERSIZE = 7;
        public static int LETTERCOUNT = 19;
        public const int UNDERSCOREX = 65;
        public const int UNDERSCOREY = 158;
        public static readonly int[] letterDest
            = { 45, 65, 52, 65, 59, 65, 66, 65, 73, 65, 80, 65, 45, 75, 52, 75, 59, 75, 66, 75, 73, 75,
            80, 75, 38, 85, 45, 85, 52, 85, 59, 85, 66, 85, 73, 85, 80, 85, 87, 85 };

        public static readonly int[] numberSource = { 1, 142, 1, 150, 9, 142, 9, 150 }; //0 1 2 3
        public static readonly int[] letterSource // more shards to go!!!
            = { 0, 0, 73, 158, 89, 142, 97, 142, 105, 150, 57, 142, 113, 142, 65, 150, 41, 142, 105, 150, 49, 150, 113, 142, 113, 150, 97, 142, 73, 158, 65, 142, 97, 142, 34, 166, 34, 166, 34, 166 }; 
    }
}
