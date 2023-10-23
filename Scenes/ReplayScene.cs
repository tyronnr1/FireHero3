using GameTemplate.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;

namespace GameTemplate.Scenes
{
    internal class ReplayScene : Component
    {
        Boolean mouseOnPlay = false;
        Boolean mouseOnExit = false;
        Rectangle ReplayButtonRectangle;
        int ReplayButtonWidth;
        int ReplayButtonHeight;
        Color ReplayButtonColor;

        Rectangle ExitButtonRectangle;
        int ExitButtonWidth;
        int ExitButtonHeight;
        Color ExitButtonColor;


        public Point mousePos;

        public Rectangle mouseRectangle;


        public bool exitGame = false;

        internal override void LoadContent(ContentManager Content, SpriteBatch spriteBatch)
        {
            TextureHandler.LoadTextures(Content);

            ReplayButtonWidth = TextureHandler.Replaybutton.Width / 3;
            ReplayButtonHeight = TextureHandler.Replaybutton.Height / 3;
            ReplayButtonRectangle = new Rectangle(Data.ScreenW / 2 - (ReplayButtonWidth) / 2, Data.ScreenH / 2 - (ReplayButtonHeight) / 2, ReplayButtonWidth, ReplayButtonHeight);

            ExitButtonWidth = TextureHandler.Replaybutton.Width / 3;
            ExitButtonHeight = TextureHandler.Replaybutton.Height / 3;
            ExitButtonRectangle = new Rectangle(Data.ScreenW / 2 - (ExitButtonWidth) / 2, (Data.ScreenH / 2 - (ExitButtonHeight) / 2) - 50, ExitButtonWidth, ExitButtonHeight);
        }

        internal override void Update(GameTime gameTime)
        {
            mousePos = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            mouseRectangle = new Rectangle(mousePos.X, mousePos.Y, 1, 1);

            //Replay button-------------------------------------------------- -





            if (mouseRectangle.Intersects(ReplayButtonRectangle))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    
                    Data.CurrentState = Data.Scenes.Game;
                }
            }

            if (mouseOnPlay == false)
            {
                if (mouseRectangle.Intersects(ReplayButtonRectangle))
                {
                    mouseOnPlay = true;
                    ReplayButtonColor = Color.White;
                    ReplayButtonRectangle.Height += 10;
                    ReplayButtonRectangle.Width += 10;
                    ReplayButtonRectangle.X -= 5;
                    ReplayButtonRectangle.Y -= 5;


                }
                else
                {
                    ReplayButtonColor = Color.Gray;
                    ReplayButtonRectangle = new Rectangle(Data.ScreenW / 2 - (ReplayButtonWidth) / 2, Data.ScreenH / 2 - (ReplayButtonHeight) / 2, ReplayButtonWidth, ReplayButtonHeight);


                }
            }
            else if (!mouseRectangle.Intersects(ReplayButtonRectangle))
            {
                mouseOnPlay = false;

            }
            //------------------------------------------------------------------


            //Exit button-------------------------------------------------- -

            if (mouseRectangle.Intersects(ExitButtonRectangle))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Data.Exit = true;

                }
            }

            if (mouseOnExit == false)
            {
                if (mouseRectangle.Intersects(ExitButtonRectangle))
                {
                    mouseOnExit = true;
                    ExitButtonColor = Color.White;
                    ExitButtonRectangle.Height += 10;
                    ExitButtonRectangle.Width += 10;
                    ExitButtonRectangle.X -= 5;
                    ExitButtonRectangle.Y -= 5;


                }
                else
                {
                    ExitButtonColor = Color.Gray;
                    ExitButtonRectangle = new Rectangle(Data.ScreenW / 2 - (ExitButtonWidth) / 2, (Data.ScreenH / 2 - (ExitButtonHeight) / 2) + ExitButtonHeight + 50, ExitButtonWidth, ExitButtonHeight);


                }
            }
            else if (!mouseRectangle.Intersects(ExitButtonRectangle))
            {
                mouseOnExit = false;

            }
            //------------------------------------------------------------------

        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(TextureHandler.LoseBackround, new Rectangle(0, 0, Data.ScreenW, Data.ScreenH), Color.White);

            spriteBatch.Draw(TextureHandler.Replaybutton, ReplayButtonRectangle, ReplayButtonColor);
            spriteBatch.Draw(TextureHandler.ExitButton, ExitButtonRectangle, ExitButtonColor);

            //spriteBatch.Draw(TextureHandler.logo, new Rectangle((Data.ScreenW / 2) - (int)(TextureHandler.logo.Width * 1.3) / 2, 100, (int)(TextureHandler.logo.Width * 1.3), (int)(TextureHandler.logo.Height * 1.3)), Color.White);


            spriteBatch.End();
        }
    }
}
