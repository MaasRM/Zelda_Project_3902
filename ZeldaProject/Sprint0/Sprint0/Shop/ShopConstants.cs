using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public static class ShopConstants
    {
        public const int OLDMANX = 45;
        public const int OLDMANY = 185;
        public const int LETTERSIZE = 7;
        public const int LETTERCOUNT = 29;
        public const int UNDERSCOREX = 65;
        public const int UNDERSCOREY = 158;
        public const int DOLLARSIGNX = 65;
        public const int DOLLARSIGNY = 166;
        public const int BOMBCOST = 10;
        public const int BLUEARROWCOST = 30;
        public const int BLUEBOOMERANGCOST = 50;
        public static readonly int[] numberSource = { 1, 142, 1, 150, 9, 142, 9, 150, 17, 142, 17, 150, 25, 142, 25, 150, 33, 142, 33, 150};
        public static readonly int[] letterDest
            = { 95, 120, 102, 120, 109, 120, 116, 120, 123, 120, 130, 120, 137, 120, 144, 120, 151, 120, 158, 120, 165, 120,
            67, 127, 74, 127, 81, 127, 88, 127, 95, 127, 102, 127, 109, 127, 116, 127, 123, 127, 130, 127, 137, 127, 144, 127,
            151, 127, 158, 127, 165, 127, 172, 127, 179, 127, 186, 127, 193, 127 };

        //PHRASE 1 -    Hi there!!!
        //          Welcome To the shop
        public static readonly int[] letterSource1
            = { 65, 150, 73, 142, 73, 158, 113, 150, 65, 150, 57, 142, 105, 150, 57, 142, 34, 166, 34, 166, 34, 166, //Hi there!!!
            1, 158, 57, 142, 81, 150, 49, 142, 97, 142, 89, 142, 57, 142, 73, 158, 113, 150, 97, 142, //Welcome To
            73, 158, 113, 150, 65, 150, 57, 142, 73, 158, 113, 142, 65, 150, 97, 142, 97, 150 }; // the shop
        //PHRASE 2 -    Nice buy!!!
        //          That will be useful
        public static readonly int[] letterSource2
            = { 89, 150, 73, 142, 49, 142, 57, 142, 73, 158, 41, 150, 121, 142, 9, 158, 34, 166, 34, 166, 34, 166, //Nice buy!!!
            113, 150, 65, 150, 41, 142, 113, 150, 73, 158, 1, 158, 73, 142, 81, 150, 81, 150, 73, 158, 41, 150, 57, 142, //That will be
            73, 158, 121, 142, 113, 142, 57, 142, 57, 150, 121, 142, 81, 150 }; // useful
        //PHRASE 3 -    Not enough,
        //          come back later ...
        public static readonly int[] letterSource3
            = { 89, 150, 97, 142, 113, 150, 73, 158, 57, 142, 89, 150, 97, 142, 121, 142, 65, 142, 65, 150, 34, 158, //Not enough, 
            49, 142, 97, 142, 89, 142, 57, 142, 73, 158, 41, 150, 41, 142, 49, 142, 81, 142, 73, 158, //come back 
            81, 150, 41, 142, 113, 150, 57, 142, 105, 150, 73, 158, 49, 158, 49, 158, 49, 158}; //later ...
    }
}
