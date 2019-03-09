using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW1_HadarPur_BreakTheWall.Sprites
{
    public class BarSprite : DrawableGameComponent
    {
        Game game;
        SpriteBatch spriteBatch;
        public Texture2D barSprite;
        Vector2 barPos;
        Rectangle rec;

        public BarSprite(Game game): base(game)
        {
            this.game = game;
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            barSprite = game.Content.Load<Texture2D>("bar");
            barPos = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - barSprite.Width / 2, game.GraphicsDevice.Viewport.Height - barSprite.Height - 10);
        }

        public override void Update(GameTime gameTime)
        {
            rec = new Rectangle((int)barPos.X, (int)barPos.Y, barSprite.Width, barSprite.Height);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Draw(barSprite, barPos, Color.White);
        }

        public Vector2 getBarPos()
        {
            return barPos;
        }

        public void setBarPos(int x, int y)
        {
            barPos.X = x;
            barPos.Y = y;
        }

        public int getBarWidth()
        {
            return barSprite.Width;
        }

        public int getBarHeight()
        {
            return barSprite.Height;
        }

        public Rectangle getRec()
        {
            return this.rec;
        }
    }
}
