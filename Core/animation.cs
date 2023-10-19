using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace GameTemplate.Core
{
    public class Animation
    {
        public Texture2D spriteSheet;
        private int frameWidth;
        private int frameHeight;
        public  int totalFrames;
        public int currentFrame;
        private float frameDuration;
        private float timer;
        private SpriteBatch spriteBatch;



        public Animation(SpriteBatch spriteBatch,Texture2D spriteSheet, int frameWidth, int frameHeight, int totalFrames, float frameDuration)
        {
            this.spriteSheet = spriteSheet;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.totalFrames = totalFrames;
            this.frameDuration = frameDuration;
            this.currentFrame = 0;
            this.timer = 0f;
            this.spriteBatch = spriteBatch;
            
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= frameDuration)
            {
                timer = 0f;
                currentFrame = (currentFrame + 1) % totalFrames;
            }
        }

        public void Draw( Vector2 position, Color color, SpriteEffects effect)
        {
            int row = currentFrame / (spriteSheet.Width / frameWidth);
            int column = currentFrame % (spriteSheet.Width / frameWidth);

            Rectangle sourceRectangle = new Rectangle(column * frameWidth, row * frameHeight, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color,0f, Vector2.Zero,effect,0f);
        }


        public (Texture2D tex,Rectangle rec) GiveCurrentSprite()
        {
            int row = currentFrame / (spriteSheet.Width / frameWidth);
            int column = currentFrame % (spriteSheet.Width / frameWidth);

            Rectangle sourceRectangle = new Rectangle(column * frameWidth, row * frameHeight, frameWidth, frameHeight);

            return (spriteSheet, sourceRectangle);
        }
    }
}
