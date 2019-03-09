using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HW1_HadarPur_BreakTheWall.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW1_HadarPur_BreakTheWall.Sprites
{
    public class BallSprite : DrawableGameComponent
    {
        private Game game;
        private GamePlayScene scene;
        private SpriteBatch spriteBatch;
        public Texture2D ballSprite;
        private Vector2 ballPosition;
        private Rectangle rect;
        public Vector2 ballSpeed;
        private bool waitingForPlayer = true;
        const int MIN_SPEED = 200;
        const int MAX_SPEED = 400;

        public BallSprite(Game game, GamePlayScene scene): base(game)
        {
            this.game = game;
            this.scene = scene;
            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            this.ballSprite = game.Content.Load<Texture2D>("ball2");
            this.ballPosition = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - ballSprite.Width / 2, game.GraphicsDevice.Viewport.Height - this.ballSprite.Height - 37);

            Random rnd = new Random();
            int xDirection = rnd.Next(0, 2);
            if (xDirection == 0)
                xDirection = 1;
            else
                xDirection = -1;
            this.ballSpeed = new Vector2(xDirection * rnd.Next(MIN_SPEED, MAX_SPEED), -rnd.Next(MIN_SPEED, MAX_SPEED));
        }

        public override void Update(GameTime gameTime)
        {
            if (!this.waitingForPlayer)
            {
                this.ballPosition += this.ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                int maxX = game.GraphicsDevice.Viewport.Width - ballSprite.Width;
                int maxY = game.GraphicsDevice.Viewport.Height - ballSprite.Height;

                if (this.ballPosition.X > maxX || this.ballPosition.X < 0)
                    ballSpeed.X *= -1;
                if (ballPosition.Y < 0)
                    ballSpeed.Y *= -1;
                else if (ballPosition.Y > maxY)
                {
                    Random rnd = new Random();
                    int xDirection = rnd.Next(0, 2);
                    if (xDirection == 0)
                        xDirection = 1;
                    else
                        xDirection = -1;
                    this.ballPosition.X = game.GraphicsDevice.Viewport.Width / 2 - this.ballSprite.Width / 2;
                    this.ballPosition.Y = game.GraphicsDevice.Viewport.Height - this.ballSprite.Height - 34;
                    this.ballSpeed.X = xDirection * rnd.Next(MIN_SPEED, MAX_SPEED);
                    this.ballSpeed.Y = -rnd.Next(MIN_SPEED, MAX_SPEED);
                    waitingForPlayer = true;
                    scene.setWaitForPlayer(true);
                    scene.setLife(scene.getLifes() - 1);
                }
                this.rect = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballSprite.Width, ballSprite.Height);
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            this.spriteBatch.Draw(ballSprite, ballPosition, Color.White);
        }

        public Vector2 getBallPos()
        {
            return this.ballPosition;
        }

        public void setBallPos(int x, int y)
        {
            this.ballPosition.X = x;
            this.ballPosition.Y = y;
        }

        public Rectangle getRect()
        {
            return this.rect;
        }

        public void reverseSpeedY()
        {
            this.ballSpeed.Y *= -1;
        }

        public void reverseSpeedX()
        {
            this.ballSpeed.X *= -1;
        }

        public void setWaitForPlayer(bool toWait)
        {
            this.waitingForPlayer = toWait;
        }
    }
}
