using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HW1_HadarPur_BreakTheWall.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HW1_HadarPur_BreakTheWall.Scenes
{
    public class GamePlayScene : Scene
    {
        private SpriteBatch spriteBatch;
        private Game game;
        private BarSprite barSprite;
        private BallSprite ballSprite;
        private ExplosionSprite explosionSprite;
        private KeyboardState kboard;
        public Texture2D heartlife;
        private bool waitForPlayer = true;
        private SpriteFont myFont;
        private int lifes = 3;
        private int hitBricks = 0;
        private String[] brickNames = { "pinksprite", "greensprite", "lightbluesprite", "bluesprite" };
        private BrickSprite[,] bricks = new BrickSprite[10, 10];
        private int maxBricks;
        private GameOverScene scene;
        Random random = new Random();

        public GamePlayScene(Game game, GameOverScene scene): base(game)
        {
            this.game = game;
            this.maxBricks = bricks.GetLength(0) * bricks.GetLength(1);
            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            this.myFont = (SpriteFont)game.Services.GetService(typeof(SpriteFont));
            this.myFont = game.Content.Load<SpriteFont>("Master");
            this.heartlife = game.Content.Load<Texture2D>("heart_life");
            this.barSprite = new BarSprite(game);
            this.ballSprite = new BallSprite(game, this);
            this.explosionSprite = new ExplosionSprite(game, new Vector2(10, 10), false);
            this.scene = scene;

            SceneComponents.Add(barSprite);
            SceneComponents.Add(ballSprite);
            SceneComponents.Add(explosionSprite);

            int x = 0, y = 40;

            for (int i = 0; i < bricks.GetLength(0); i++)
            {
                for (int j = 0; j < bricks.GetLength(1); j++)
                {
                    int randomNumber = random.Next(0, 4);
                    bricks[i, j] = new BrickSprite(this.game, this.ballSprite, this.explosionSprite, new Vector2(x, y), this, brickNames[randomNumber]);
                    x += 80;
                    SceneComponents.Add(bricks[i, j]);
                }
                x = 0;
                y += 27;
            }
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState prev = kboard;

            if (waitForPlayer)
            {
                kboard = Keyboard.GetState();
                if (kboard.IsKeyDown(Keys.Enter) && prev.IsKeyUp(Keys.Enter))
                {
                    this.barSprite.setBarPos(game.GraphicsDevice.Viewport.Width / 2 - this.barSprite.getBarWidth() / 2, (int)barSprite.getBarPos().Y);
                    this.ballSprite.setWaitForPlayer(false);
                    this.waitForPlayer = false;
                }
            }
            else
            {
                kboard = Keyboard.GetState();
                if (kboard.IsKeyDown(Keys.Right) && (int)barSprite.getBarPos().X < (GraphicsDevice.Viewport.Width - barSprite.getBarWidth()))
                    this.barSprite.setBarPos((int)barSprite.getBarPos().X + 4, (int)barSprite.getBarPos().Y);
                else if (kboard.IsKeyDown(Keys.Left) && (int)barSprite.getBarPos().X > 0)
                    this.barSprite.setBarPos((int)barSprite.getBarPos().X - 4, (int)barSprite.getBarPos().Y);
            }

            if (barSprite.getRec().Intersects(ballSprite.getRect()) && ballSprite.ballSpeed.Y > 0)
            {
                this.ballSprite.reverseSpeedY();
            }

            if (hitBricks == maxBricks)
            {
                this.scene.setWinLose(true);
                this.Hide();
                this.scene.Show();
            }

            if (lifes == 0)
            {
                this.scene.setWinLose(false);
                this.Hide();
                this.scene.Show();
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.DrawString(myFont, "Lifes remaines: ", new Vector2(5, 5), Color.White);
            int x = 150;
            for (int i=0; i<lifes; i++)
            {
                spriteBatch.Draw(heartlife, new Vector2(x, 5), Color.White);
                x += 35;
            }
            if (waitForPlayer)
            {
                spriteBatch.DrawString(myFont, "Press Enter to start the game", new Vector2(game.GraphicsDevice.Viewport.Width / 8, game.GraphicsDevice.Viewport.Height / 2), Color.White);
                spriteBatch.DrawString(myFont, "Press ESC to return to the menu", new Vector2(game.GraphicsDevice.Viewport.Width / 8, game.GraphicsDevice.Viewport.Height / 2 + 35), Color.White);
            }
            base.Draw(gameTime);
        }

        public ExplosionSprite getExplosionSprite()
        {
            return this.explosionSprite;
        }

        public void setWaitForPlayer(bool toWait)
        {
            this.waitForPlayer = toWait;
        }

        public void setLife(int life)
        {
            this.lifes = life;
        }

        public int getLifes()
        {
            return this.lifes;
        }

        public int getMaxBricks()
        {
            return this.maxBricks;
        }

        public void setHitBricks()
        {
            this.hitBricks = this.hitBricks + 1;
        }

        public int getHitBricks()
        {
            return this.hitBricks;
        }
    }
}
