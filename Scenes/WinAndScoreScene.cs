using GameTemplate.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameTemplate.Scenes
{
    internal class WinAndScoreScene : Component
    {

        Boolean mouseOnPlay = false;
        Rectangle ReplayButtonRectangle;
        int ReplayButtonWidth;
        int ReplayButtonHeight;
        Color ReplayButtonColor = Color.White;

        Boolean mouseOnExit = false;
        Rectangle ExitButtonRectangle;
        int ExitButtonWidth;
        int ExitButtonHeight;
        Color ExitButtonColor = Color.White;


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
            ExitButtonRectangle = new Rectangle(Data.ScreenW / 2 - (ExitButtonWidth) / 2, (Data.ScreenH / 2 - (ExitButtonHeight) / 2) + ExitButtonHeight + 50, ExitButtonWidth, ExitButtonHeight);

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

            spriteBatch.Draw(TextureHandler.WinBackround, new Rectangle(0, 0, Data.ScreenW, Data.ScreenH), Color.White);

            spriteBatch.Draw(TextureHandler.Replaybutton, ReplayButtonRectangle, ReplayButtonColor);
            spriteBatch.Draw(TextureHandler.ExitButton, ExitButtonRectangle, ExitButtonColor);
            spriteBatch.DrawString(TextureHandler.Score, "Score:" + Player.points, new Vector2(Data.ScreenW / 2 - (TextureHandler.Score.MeasureString("Score:" + Player.points).X) / 2, Data.ScreenH / 2 - ReplayButtonHeight * 3), Color.OrangeRed);






            spriteBatch.End();
        }
    }
}
