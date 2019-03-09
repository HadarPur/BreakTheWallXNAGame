using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW1_HadarPur_BreakTheWall.Sprites
{
    public class HeartSprite : DrawableGameComponent
    {
        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D heart;
        private Vector2 heartPos;
        private Color Color = Color.White;
        private Vector2 Origin;
        private float Rotation = 0f;
        private float Scale = 2f;
        private SpriteEffects SpriteEffect;
        private Rectangle srcRect;

        private float elapsed = 0;
        private float update = 0.1f;
        private int currentFrame = 0;
        private int row = 0;

        private const int ROW_LENGTH = 5;
        private const int COL_LENGTH = 2;

        private int width;
        private int height;

        public HeartSprite(Game game)
            : base(game)
        {
            this.game = game;
            this.heart = game.Content.Load<Texture2D>("heart2");
            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));

            this.width = heart.Width / ROW_LENGTH;
            this.height = heart.Height / COL_LENGTH;

            this.srcRect = new Rectangle(0, 0, width, height);
            this.heartPos = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - heart.Width / 4, 300);
        }

        public override void Update(GameTime gameTime)
        {
            this.elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.elapsed > this.update)
            {
                if (this.currentFrame >= ROW_LENGTH - 1)
                {
                    this.currentFrame = 0;
                    this.row++;
                    this.row %= COL_LENGTH;
                }
                else
                    currentFrame++;
                elapsed = 0;
            }
            this.srcRect = new Rectangle(this.currentFrame * this.width, this.row * this.height, this.width, this.height);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(heart, heartPos, srcRect, Color.White, Rotation, Origin, Scale, SpriteEffect, 0f);
            base.Draw(gameTime);
        }
    }
}
