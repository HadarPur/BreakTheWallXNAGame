#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

using AppKit;
using Foundation;
using HW1_HadarPur_BreakTheWall.Sprites;
#endregion

namespace HW1_HadarPur_BreakTheWall.MacOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            NSApplication.Init();

            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
}
