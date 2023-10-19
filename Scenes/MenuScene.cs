using GameTemplate.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;

namespace GameTemplate.Scenes
{
    internal class MenuScene : Component
    {
        Boolean mouseOnPlay = false;
        Boolean mouseOnExit = false;
        Rectangle PlayButtonRectangle;
        int PlayButtonWidth;
        int PlayButtonHeight;
        Color PlayButtonColor;

        Rectangle ExitButtonRectangle;
        int ExitButtonWidth;
        int ExitButtonHeight;
        Color ExitButtonColor;


        public Point mousePos;

        public Rectangle mouseRectangle;

        public bool exitGame=false;

        internal override void LoadContent(ContentManager Content, SpriteBatch spriteBatch)
        {
            TextureHandler.LoadTextures(Content);

            PlayButtonWidth = TextureHandler.playbutton.Width / 3;
            PlayButtonHeight = TextureHandler.playbutton.Height / 3;
            PlayButtonRectangle = new Rectangle(Data.ScreenW / 2 - (PlayButtonWidth) / 2, Data.ScreenH / 2 - (PlayButtonHeight) / 2, PlayButtonWidth, PlayButtonHeight);

            ExitButtonWidth = TextureHandler.playbutton.Width / 3;
            ExitButtonHeight = TextureHandler.playbutton.Height / 3;
            ExitButtonRectangle = new Rectangle(Data.ScreenW / 2 - (ExitButtonWidth) / 2, (Data.ScreenH / 2 - (ExitButtonHeight) / 2)-50, ExitButtonWidth, ExitButtonHeight);
        }

        internal override void Update(GameTime gameTime)
        {
            mousePos = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            mouseRectangle = new Rectangle(mousePos.X, mousePos.Y, 1, 1);

            //Play button-------------------------------------------------- -





            if (mouseRectangle.Intersects(PlayButtonRectangle))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Data.CurrentState = Data.Scenes.Game;
                }
            }

            if (mouseOnPlay == false)
            {
                if (mouseRectangle.Intersects(PlayButtonRectangle))
                {
                    mouseOnPlay = true;
                    PlayButtonColor = Color.White;
                    PlayButtonRectangle.Height += 10;
                    PlayButtonRectangle.Width += 10;
                    PlayButtonRectangle.X -= 5;
                    PlayButtonRectangle.Y -= 5;


                }
                else
                {
                    PlayButtonColor = Color.Gray;
                    PlayButtonRectangle = new Rectangle(Data.ScreenW / 2 - (PlayButtonWidth) / 2, Data.ScreenH / 2 - (PlayButtonHeight) / 2, PlayButtonWidth, PlayButtonHeight);


                }
            }
            else if (!mouseRectangle.Intersects(PlayButtonRectangle))
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

                    //Data.CurrentState = Data.Scenes.Game;
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
                    ExitButtonRectangle = new Rectangle(Data.ScreenW / 2 - (ExitButtonWidth) / 2, (Data.ScreenH / 2 - (ExitButtonHeight) / 2) + ExitButtonHeight+50, ExitButtonWidth, ExitButtonHeight);


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

            spriteBatch.Draw(TextureHandler.backgroundTexture, new Rectangle(0, 0, Data.ScreenW, Data.ScreenH), Color.White);

            spriteBatch.Draw(TextureHandler.playbutton, PlayButtonRectangle, PlayButtonColor);
            spriteBatch.Draw(TextureHandler.ExitButton, ExitButtonRectangle, ExitButtonColor);

            spriteBatch.Draw(TextureHandler.logo, new Rectangle((Data.ScreenW / 2) - (int)(TextureHandler.logo.Width * 1.3) / 2, 100, (int)(TextureHandler.logo.Width * 1.3), (int)(TextureHandler.logo.Height * 1.3)), Color.White);


            spriteBatch.End();
        }
    }
}
