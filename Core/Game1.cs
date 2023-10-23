using GameTemplate.Managers;
using GameTemplate.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTemplate.Core
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private GameStateManager gsm;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Data.ScreenW;
            graphics.PreferredBackBufferHeight = Data.ScreenH;
            graphics.ApplyChanges();
            gsm = new GameStateManager();
        
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gsm.LoadContent(Content, spriteBatch);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)||Data.Exit)
                Exit();

            gsm.Update(gameTime);
             


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {


            gsm.Draw(spriteBatch);


            base.Draw(gameTime);
        }
    }
}