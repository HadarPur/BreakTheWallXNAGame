using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HW1_HadarPur_BreakTheWall.Scenes
{
    public class GameOverScene : Scene
    {
        private SpriteBatch spriteBatch;
        private Game game;
        private SpriteFont gaming;
        private SpriteFont galaga;
        public Texture2D gameOverSprite;

        private bool win;

        public GameOverScene(Game game): base(game)
        {
            this.game = game;
            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            this.gaming = (SpriteFont)game.Services.GetService(typeof(SpriteFont));
            this.galaga = (SpriteFont)game.Services.GetService(typeof(SpriteFont));
            this.gameOverSprite = game.Content.Load<Texture2D>("game_over");
            this.gaming = game.Content.Load<SpriteFont>("Master");
            this.galaga = game.Content.Load<SpriteFont>("Master");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (win)
                spriteBatch.DrawString(gaming, "GAME OVER - You Won!", new Vector2(game.GraphicsDevice.Viewport.Width / 9, 50), Color.DarkOrange);
            else
                spriteBatch.Draw(gameOverSprite, new Vector2(game.GraphicsDevice.Viewport.Width / 2 - gameOverSprite.Width / 2, game.GraphicsDevice.Viewport.Height / 2 - gameOverSprite.Height / 2), Color.White);
            spriteBatch.DrawString(galaga, "Press ESC to go back to the menu", new Vector2(game.GraphicsDevice.Viewport.Width / 3, game.GraphicsDevice.Viewport.Height-100), Color.White);
            base.Draw(gameTime);
        }

        public void setWinLose(bool isWin)
        {
            this.win = isWin;
        }
    }
}
