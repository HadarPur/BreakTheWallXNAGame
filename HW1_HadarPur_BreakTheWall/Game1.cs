using System;
using System.Collections.Generic;
using System.Linq;
using HW1_HadarPur_BreakTheWall.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HW1_HadarPur_BreakTheWall
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private OpeningScene scene1;
        private InstructionsScene scene2;
        private GamePlayScene scene3;
        private GameOverScene scene4;
        private KeyboardState kboard;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 768;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            Services.AddService(typeof(SpriteBatch), spriteBatch);
            this.scene1 = new OpeningScene(this);
            this.scene2 = new InstructionsScene(this, scene1);
            this.scene4 = new GameOverScene(this);
            this.scene3 = new GamePlayScene(this, scene4);
            this.scene1.Show();

            Components.Add(scene1);
            Components.Add(scene2);
            Components.Add(scene3);
            Components.Add(scene4);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState prev = kboard;
            kboard = Keyboard.GetState();
            if (scene1.Enabled)
            {
                if (kboard.IsKeyDown(Keys.Space) && prev.IsKeyUp(Keys.Space))
                {
                    this.scene1.Hide();
                    this.scene2.Show();
                }
                else if (kboard.IsKeyDown(Keys.Enter) && prev.IsKeyUp(Keys.Enter))
                {
                    this.scene1.Hide();
                    this.scene3.Show();
                }
            }
            else if (scene2.Enabled)
            {
                if (kboard.IsKeyDown(Keys.Escape) && prev.IsKeyUp(Keys.Escape))
                {
                    this.scene2.Hide();
                    this.scene1.Show();
                }
            }
            else if (scene3.Enabled)
            {
                if (kboard.IsKeyDown(Keys.Escape) && prev.IsKeyUp(Keys.Escape))
                {
                    this.scene3.Hide();
                    this.scene3 = new GamePlayScene(this, scene4);
                    Components.Add(scene3);
                    this.scene1.Show();
                }
            }
            else if (scene4.Enabled)
            {
                if (kboard.IsKeyDown(Keys.Escape) && prev.IsKeyUp(Keys.Escape))
                {
                    this.scene4.Hide();
                    this.scene3 = new GamePlayScene(this, scene4);
                    Components.Add(scene3);
                    this.scene1.Show();
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
