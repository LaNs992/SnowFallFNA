using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace GameEngine
{
    static internal class Global
    {
        public static Game1 Game;
        public static Random Random = new Random();
        public static string LevelName = "";

        public static void Initialize(Game1 inputGame)
        {
            Game = inputGame;
        }
    }
}
