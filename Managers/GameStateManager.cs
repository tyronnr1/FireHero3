using GameTemplate.Core;
using GameTemplate.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTemplate.Managers
{
    internal partial class GameStateManager : Component
    {

        private MenuScene ms= new MenuScene();
        private GameScene gs= new GameScene();
        public Point mousePos;
        public Rectangle mouseRectangle;
        Rectangle PlayButtonRectangle;
        int PlayButtonWidth;
        int PlayButtonHeight;

        internal override void LoadContent(ContentManager Content, SpriteBatch spriteBatch)
        {
            ms.LoadContent(Content, spriteBatch);
            gs.LoadContent(Content, spriteBatch);
        }

        internal override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.Menu:

                    ms.Update(gameTime);

                    break;
                case Data.Scenes.Game:
                    gs.Update(gameTime);
                    break;
                case Data.Scenes.Setting:
                    break;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.Menu:
                    ms.Draw(spriteBatch);
                    break;
                case Data.Scenes.Game:
                    gs.Draw(spriteBatch);
                    break;
                case Data.Scenes.Setting:
                    break;
            }
        }
    }
}
