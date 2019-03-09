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
    public class OpeningScene : Scene
    {
        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D headLine;
        private Vector2 headLinePos;

        private Texture2D startGame;
        private Vector2 startGamePos;

        private Texture2D instructions;
        private Vector2 instructionsPos;
        private Game1 curGame;

        public OpeningScene(Game game)
            : base(game)
        {
            this.game = game;

            this.headLine = game.Content.Load<Texture2D>("break_the_wall");
            this.startGame = game.Content.Load<Texture2D>("startGame");
            this.instructions = game.Content.Load<Texture2D>("instructions");

            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));

            this.headLinePos = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - headLine.Width / 2, 50);
            this.startGamePos = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - startGame.Width / 2, 400);
            this.instructionsPos = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - instructions.Width / 2, 450);


            this.curGame = (Game1)game;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            this.spriteBatch.Draw(headLine, headLinePos, Color.White);
            this.spriteBatch.Draw(startGame, startGamePos, Color.White);
            this.spriteBatch.Draw(instructions, instructionsPos, Color.White);
        }
    }
}
