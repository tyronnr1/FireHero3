using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace GameTemplate.Core
{
    internal abstract class Component
    {
        internal abstract void LoadContent(ContentManager Content, SpriteBatch spriteBatch);
        internal abstract void Update(GameTime gameTime);
        internal abstract void Draw(SpriteBatch spriteBatch);

    }
}
