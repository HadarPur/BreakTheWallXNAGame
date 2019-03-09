using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HW1_HadarPur_BreakTheWall.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HW1_HadarPur_BreakTheWall.Scenes
{
    public class InstructionsScene : Scene
    {
        private SpriteBatch spriteBatch;
        private Game game;
        private SpriteFont myFont;
        private String[] instructions;
        private int x = 10;
        private int y = 100;
        private const int NUM_INSTRUCTIONS = 4;
        private OpeningScene scene;

        private HeartSprite heart;

        public InstructionsScene(Game game, OpeningScene scene)
            : base(game)
        {
            this.game = game;
            this.scene = scene;
            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            this.myFont = game.Content.Load<SpriteFont>("Master");
            this.heart = new HeartSprite(game);

            this.instructions = new String[NUM_INSTRUCTIONS];
            this.instructions[0] = "Game Rules:";
            this.instructions[1] = "  1) Move bar with arrows so that the ball wont cross the bar.";
            this.instructions[2] = "  2) Try to hit the asteroids with the ball.";
            this.instructions[3] = "Press ESC to go back to the menu";

            SceneComponents.Add(heart);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            int i;
            base.Draw(gameTime);
            for (i = 0; i < instructions.Length - 1; i++)
            {
                this.spriteBatch.DrawString(myFont, instructions[i], new Vector2(x, this.y), Color.White);
                y += 40;
            }
            y += 40;
            this.spriteBatch.DrawString(myFont, instructions[i], new Vector2(x, this.y), Color.White);
            y = 0;
        }
    }
}
