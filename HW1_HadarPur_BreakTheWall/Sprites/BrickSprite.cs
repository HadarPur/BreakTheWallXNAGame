using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HW1_HadarPur_BreakTheWall.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HW1_HadarPur_BreakTheWall.Sprites
{
    public class BrickSprite : DrawableGameComponent
    {
        private Game game;
        private Game1 currentGame;
        private SpriteBatch spriteBatch;
        private Texture2D brickSprite;
        private Vector2 brickPos;
        private Rectangle brickRec;
        private BallSprite ballSprite;
        private bool reDraw = true;
        private ExplosionSprite explosionSprite;
        private GamePlayScene scene;

        public int GreenBrickSpriteWidth { get; set; }

        public BrickSprite(Game game, BallSprite ballSprite, ExplosionSprite explosionSprite, Vector2 brickPos, GamePlayScene scene, String brickColor)
            : base(game)
        {
            this.game = game;
            this.currentGame = (Game1)game;
            this.ballSprite = ballSprite;
            this.explosionSprite = explosionSprite;
            this.spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            this.brickSprite = game.Content.Load<Texture2D>(brickColor);
            this.brickPos = brickPos;
            this.scene = scene;
        }

        public override void Update(GameTime gameTime)
        {
            this.brickRec = new Rectangle((int)brickPos.X, (int)brickPos.Y, brickSprite.Width, brickSprite.Height);
            if (this.reDraw)
            {
                if (this.brickRec.Intersects(this.ballSprite.getRect()))
                {
                    Rectangle collisionRec = Rectangle.Intersect(this.brickRec, this.ballSprite.getRect());
                    reDraw = false;
                    if (this.ballSprite.getRect().Right.Equals(brickRec.Left) || this.ballSprite.getRect().Left.Equals(brickRec.Right))
                        this.ballSprite.reverseSpeedX();
                    else
                        this.ballSprite.reverseSpeedY();
                    this.scene.setHitBricks();
                    this.explosionSprite.setPos(new Vector2(collisionRec.X - 29, collisionRec.Y - 24));
                    this.explosionSprite.setDraw(true);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (reDraw)
            {
                base.Draw(gameTime);
                this.spriteBatch.Draw(brickSprite, brickPos, Color.White);
            }
        }

    }
}
