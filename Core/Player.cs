using GameTemplate.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameTemplate.Core
{
    public class Player
    {
        public Texture2D tex;
        public Vector2 pos;
        public Vector2 direction;
        public float speed;

        public bool moving;
        public Vector2 destination;
        public int points = 9999;

        public Player(Vector2 pos)
        {
            this.pos = pos;
            tex = TextureHandler.PlayerTexture;
            direction = new Vector2(0, 0);
            speed = 300;
            moving = false;
            destination = Vector2.Zero;

        }

        public void Update(GameTime gt,int tileSize)
        {
            KeyMouseReader.Update();
            if (!moving)
            {
                if(Scenes.GameScene.GetTextureAtPosition(new Vector2(pos.X, pos.Y+tileSize))== TextureHandler.airTexture) 
                {
                     ChangeDirection(new Vector2(0, 1), tileSize);
                }  
                else if (KeyMouseReader.KeyPressed(Keys.Up))
                {
                    if (Scenes.GameScene.GetTextureAtPosition(this.pos)==TextureHandler.ladderTexture|| Scenes.GameScene.GetTextureAtPosition(this.pos) == TextureHandler.topLadderTexture)
                    {
                        ChangeDirection(new Vector2(0, -1), tileSize);
                    }
                }
                else if (KeyMouseReader.KeyPressed(Keys.Left))
                {
                    ChangeDirection(new Vector2(-1, 0), tileSize);
                }
                else if (KeyMouseReader.KeyPressed(Keys.Down))
                {

                    if (Scenes.GameScene.GetTextureAtPosition(this.pos) == TextureHandler.ladderTexture|| Scenes.GameScene.GetTextureAtPosition(new Vector2(pos.X, pos.Y + tileSize)) == TextureHandler.topLadderTexture || Scenes.GameScene.GetTextureAtPosition(new Vector2(pos.X, pos.Y + tileSize)) == TextureHandler.ladderTexture)
                    {
                        ChangeDirection(new Vector2(0, 1), tileSize);
                    }
                }
                else if (KeyMouseReader.KeyPressed(Keys.Right))
                {
                    ChangeDirection(new Vector2(1, 0), tileSize);
                }
            }
            else
            {
                pos += direction * speed * (float)gt.ElapsedGameTime.TotalSeconds;

                if (Vector2.Distance(pos, destination) < 1)
                {
                    pos = destination;
                    moving = false;
                }
            }
        }

        public void Draw(SpriteBatch sb, int tileSize,bool swordActive)
        {
            Rectangle rec = new Rectangle((int)this.pos.X, (int)this.pos.Y, tileSize, tileSize);
            Vector2 origin = Vector2.Zero;
            Texture2D temptex = TextureHandler.PlayerTexture;
            SpriteEffects flip = SpriteEffects.None;
            if (direction.X < 0) // If moving left
            {
                flip = SpriteEffects.FlipHorizontally; 
                temptex = TextureHandler.PlayerTexture;
            }
            if (swordActive&& direction.X < 0)
            {
                flip = SpriteEffects.FlipHorizontally; 
                temptex = TextureHandler.holdingSword;
            }else if(swordActive && direction.X > 0)
            {
                temptex = TextureHandler.holdingSword;
            }
            

            if (direction.Y < 0|| direction.Y > 0)
            {
                temptex = TextureHandler.climing;
            }

            sb.Draw(temptex, rec,null,Color.White,0f,origin,flip,0f);

        }

        public void ChangeDirection(Vector2 dir,int tileSize)
        {
            direction = dir;
            Vector2 newDestination = pos + direction * tileSize;

            if (!(Scenes.GameScene.GetTileAtPosition(newDestination)))//Walkable
            {
                destination = newDestination;
                moving = true;
            }
        }
    }
}
