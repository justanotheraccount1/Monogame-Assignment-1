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
        float titleSpin, titleFade, fireFade, numFire, fadeAmount;

        Vector2 jetSpeed;
        List<Rectangle> fireRects;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            generator = new Random();
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            bgRect = window;
            jetRect = new Rectangle(400, 40, 100, 40);
            tRexRect = new Rectangle(200, 220, 300, 210);
            titleSpin = 1f;
            titleFade = 1f;
            fadeAmount = 0.02f;
            jetSpeed = new Vector2(2, 0);
            numFire = generator.Next(10);

            fireRects = new List<Rectangle>();
            for (int i = 0; i < numFire; i++)
            {
                fireRects.Add(new Rectangle((generator.Next(760)), 370, 40, 60));
            }



            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("Images/skyline");
            tRexTexture = Content.Load<Texture2D>("Images/TRexRun");
            boomTexture = Content.Load<Texture2D>("Images/boom");
            jetTexture = Content.Load<Texture2D>("Images/fighterJetImage");
            fireTexture = Content.Load<Texture2D>("Images/bgFire");
            titleFont = Content.Load<SpriteFont>("Fonts/mainFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (jetRect.Left <= 0)
            {
                jetSpeed.X *= -1;
            }
            if (jetRect.Right >= 800)
            {
                jetSpeed.X *= -1;
            }
            jetRect.X += Convert.ToInt32(jetSpeed.X);

            if (titleFade <= 0)
            {
                fadeAmount *= (-1);
            }
            if (titleFade >= 1)
            {
                fadeAmount *= (-1);
            }
            titleFade += fadeAmount;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(bgTexture, bgRect, Color.White);
            _spriteBatch.Draw(fireTexture, new Rectangle(600, 150, 40, 60), Color.White);
            if (jetSpeed.X > 0)
            {
                _spriteBatch.Draw(jetTexture, jetRect, Color.White);
                _spriteBatch.Draw(tRexTexture, tRexRect, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1f);
            }
            if (jetSpeed.X < 0)
            {
                _spriteBatch.Draw(jetTexture, jetRect, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1f);
                _spriteBatch.Draw(tRexTexture, tRexRect, Color.White);
            }
            for (int i = 0; i < numFire; i++)
            {
                _spriteBatch.Draw(fireTexture, fireRects[i], Color.White);
            }
            _spriteBatch.DrawString(titleFont, "The City is under Attack!", new Vector2(152, 452), Color.Black * titleFade);
            _spriteBatch.DrawString(titleFont, "The City is under Attack!", new Vector2(150, 450), Color.Yellow * titleFade);
            





            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
