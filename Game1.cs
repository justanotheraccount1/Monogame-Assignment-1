using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame_Assignment_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window, bgRect, tRexRect, jetRect, fireRect, boomRect;
        Texture2D bgTexture, tRexTexture, jetTexture, fireTexture, boomTexture;
        SpriteFont titleFont;
        Random generator;
        float titleSpin, titleFade, fireFade;
        int jetX;
        Vector2 jetSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            generator = new Random();
            titleSpin = 1f;
            jetX = 400;
            jetSpeed = new Vector2(1, 0);
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            bgRect = window;
            jetRect = new Rectangle(jetX, 40, 50, 20);
            fireRect = new Rectangle((generator.Next(780)), 470, 20, 30);


            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("Images/skyline");
            tRexTexture = Content.Load<Texture2D>("Images/TRexRun");
            boomTexture = Content.Load<Texture2D>("Images/boom");
            jetTexture = Content.Load<Texture2D>("Images/fighterJet");
            fireTexture = Content.Load<Texture2D>("Images/bgFire");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
