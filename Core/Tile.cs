using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTemplate.Core
{
    public class Tile
    {
        public Vector2 pos;
        public Texture2D tex;
        public bool notWalkable;

        public Tile(Vector2 pos, Texture2D tex, bool notWalkable)
        {
            this.pos = pos;
            this.tex = tex;
            this.notWalkable = notWalkable;
        }

        public void Draw(SpriteBatch spriteBatch,int tileSize)
        {
            Rectangle rec = new Rectangle((int)pos.X, (int)pos.Y, tileSize, tileSize);
            spriteBatch.Draw(tex, rec, Color.White);
        }
    }
}
