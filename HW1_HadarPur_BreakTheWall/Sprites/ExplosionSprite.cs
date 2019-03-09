using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW1_HadarPur_BreakTheWall.Sprites
{
    public class ExplosionSprite : DrawableGameComponent
    {
        private Game game;
        private SpriteBatch spriteBatch;
        private Texture2D explosionSprite;
        private Vector2 explosionPos;
        private Rectangle rec;

        private float elapsed;
        private float update = 0.03f;

        private int currentFrame;
        private int row = 0;
        private int width;
        private int height;

        private bool draw;

        private const int ROW_LENGTH = 4;
        private const int COL_LENGTH = 4;

        public ExplosionSprite(Game game, Vector2 pos, bool draw)
            : base(game)
        {
            this.game = game;
            this.draw = draw;
            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            this.explosionSprite = game.Content.Load<Texture2D>("explosion");
            this.explosionPos = pos;
            this.draw = draw;
            this.width = this.explosionSprite.Width / ROW_LENGTH;
            this.height = this.explosionSprite.Height / COL_LENGTH;
            this.rec = new Rectangle(0, 0, this.width, this.height);
        }

        public override void Update(GameTime gameTime)
        {
            this.elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.currentFrame == ROW_LENGTH - 1 && row == COL_LENGTH - 1)
            {
                row = 0;
                currentFrame = 0;
                draw = false;
            }
            if (this.draw)
            {
                if (this.elapsed > this.update)
                {
                    if (this.currentFrame >= ROW_LENGTH - 1)
                    {
                        this.currentFrame = 0;
                        this.row++;
                        this.row %= COL_LENGTH;
                    }
                    else
                        this.currentFrame++;
                    this.elapsed = 0;
                }
                this.rec = new Rectangle(this.currentFrame * this.width, this.row * this.height, this.width, this.height);
            }
            else
            {
                this.elapsed = 0;
                this.rec = new Rectangle(0, 0, 0, 0);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(explosionSprite, explosionPos, rec, Color.White);
            base.Draw(gameTime);
        }

        public void setDraw(bool toDraw)
        {
            this.draw = toDraw;
        }

        public void setPos(Vector2 pos)
        {
            this.explosionPos = pos;
        }
    }
}
