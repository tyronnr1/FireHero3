using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Diagnostics;


namespace GameTemplate.Core
{
    public class IceMissile
    {
        public GraphicsDeviceManager graphics;

        public Texture2D iceSprite;
        public Vector2 position;
        public Vector2 direction;
        public int tileSize;
        public float speed;
        public int ScreenWidth;
        public int ScreenHeight;
        public Vector2 currentTilePosition;
        public Animation ice;
        public SpriteEffects effect = SpriteEffects.None;
        bool breaking;

        public bool IsActive { get; set; }
        Game Game { get; set; }

        public IceMissile(SpriteBatch spriteBatch,ContentManager content, int tileSize, GraphicsDeviceManager graphics, int tileLevel)
        {
            position.Y=(tileSize*tileLevel)-20;
            this.ice = new Animation(spriteBatch,TextureHandler.movingIce,403/5,161/2,8,0.1f);

            this.tileSize = tileSize;
            this.speed = 1000f;
            iceSprite = ice.GiveCurrentSprite().tex; // Load your ice sprite texture
            IsActive = false;
        }

        public void Spawn(Random random)
        {
            
            int side = random.Next(2); // 0 for left, 1 for right
            int Rspeed = random.Next(4); 

            int randomspawn = random.Next(300); 

            if (randomspawn==0&&IsActive==false)
            {
                ice.spriteSheet = TextureHandler.movingIce;
                IsActive = true;
                
                if (side == 0) // Spawn on the left side
                {
                    position = new Vector2(0, position.Y);
                    direction = new Vector2(1, 0); // Move right

                    effect = SpriteEffects.None;
                }
                else // Spawn on the right side
                {
                    position = new Vector2(Data.ScreenW - tileSize, position.Y);
                    direction = new Vector2(-1, 0); // Move left

                    effect = SpriteEffects.FlipHorizontally; // Flip vertically to look left
                }
                if (Rspeed > 0)
                {
                    speed = 700f;
                }
            }
            
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch, Vector2 playerpos,bool swordActive)
        {
            if (IsActive)
            {
                ice.Update(gameTime);

                currentTilePosition = new Vector2((int)((position.X - 605) / tileSize), (int)((position.Y-70)/tileSize));

                // Move the ice missile tile-based

                float distanceToMove = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                position += direction * distanceToMove;

                if (Vector2.Distance(playerpos, position) < tileSize && !swordActive)
                {
                    if (!breaking)
                    {
                        Player.life -= 1;

                    }
                    speed = 0;
                    if(ice.spriteSheet!= TextureHandler.iceBreaking)
                    {
                        ChangeSpriteSheet(spriteBatch, TextureHandler.iceBreaking, 379 / 5, 183 / 3, 15, 0.1f);
                        breaking = true;
                    }
                }

                if (breaking)
                {
                    
                    if(ice.currentFrame == ice.totalFrames-1)
                    {
                        IsActive = false;
                    }
                }

                // Check if the ice missile has moved off the screen, if so, deactivate it
                if (position.X < 0 - tileSize || position.X > Data.ScreenW ||
                    position.Y < 0 - tileSize || position.Y > Data.ScreenH)
                {
                    IsActive = false;
                }
                
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                
                ice.Draw(new Vector2(position.X, position.Y - 40), Color.White,effect,2);
            }
        }
        public void ChangeSpriteSheet(SpriteBatch spriteBatch, Texture2D tex, int frameWidth, int frameHeight, int totalFrames, float frameDuration)
        {

             this.ice = new Animation(spriteBatch, tex, frameWidth, frameHeight, totalFrames, frameDuration);
            
        }
    }
}


