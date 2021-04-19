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
            = { 95, 120, 102, 120, 109, 120, 116, 120, 123, 120, 130, 120, 137, 120, 144, 120, 151, 120, 158, 120, 165, 120,
            67, 127, 74, 127, 81, 127, 88, 127, 95, 127, 102, 127, 109, 127, 116, 127, 123, 127, 130, 127, 137, 127, 144, 127,
            151, 127, 158, 127, 165, 127, 172, 127, 179, 127, 186, 127, 193, 127 };

        public static readonly int[] numberSource = { 1, 142, 1, 150, 9, 142, 9, 150 }; //0 1 2 3
        public static readonly int[] letterSource // more shards to go!!!
            = { 0, 0, 89, 142, 97, 142, 105, 150, 57, 142, 73, 158, 113, 142, 65, 150, 41, 142, 105, 150, 49, 150, 113, 142, 113, 150, 97, 142, 73, 158, 65, 142, 97, 142, 34, 166, 34, 166, 34, 166 }; 
    }
}
