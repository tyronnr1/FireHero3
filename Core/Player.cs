using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


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
        public static int points = 0;
        public static int life = 3;
        public static bool swordActive = false;
        public static double swordTime = 0;
        public static bool godMode=false;
        public static bool endMode = false;
        double timer = 0;


        public Player(Vector2 pos)
        {
            this.pos = pos;

            tex = TextureHandler.PlayerTexture;
            direction = new Vector2(0, 0);
            speed = 6.9f;
            moving = false;
            destination = Vector2.Zero;

        }

        public void Update(GameTime gt, int tileSize)
        {
            KeyMouseReader.Update();
            if (!godMode)
            {
                if (!moving)
                {
                    if (Scenes.GameScene.GetTextureAtPosition(new Vector2(pos.X, pos.Y + tileSize)) == TextureHandler.airTexture)
                    {
                        ChangeDirection(new Vector2(0, 1), tileSize);
                    }
                    else if (KeyMouseReader.KeyPressed(Keys.Up))
                    {
                        if (Scenes.GameScene.GetTextureAtPosition(this.pos) == TextureHandler.ladderTexture || Scenes.GameScene.GetTextureAtPosition(this.pos) == TextureHandler.topLadderTexture)
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

                        if (Scenes.GameScene.GetTextureAtPosition(this.pos) == TextureHandler.ladderTexture || Scenes.GameScene.GetTextureAtPosition(new Vector2(pos.X, pos.Y + tileSize)) == TextureHandler.topLadderTexture || Scenes.GameScene.GetTextureAtPosition(new Vector2(pos.X, pos.Y + tileSize)) == TextureHandler.ladderTexture)
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
                    pos += direction * speed;// * (float)gt.ElapsedGameTime.Milliseconds;

                    if (Vector2.Distance(pos, destination) < 1)
                    {
                        pos = destination;
                        moving = false;
                    }
                }
            }
            else
            {

                if (endMode)
                {
                    timer += gt.ElapsedGameTime.TotalSeconds;

                }
                pos += direction * speed;// * (float)gt.ElapsedGameTime.Milliseconds;

                if (Vector2.Distance(pos, destination) < 1)
                {
                    pos = destination;
                    moving = false;
                }
            }
            

        }

        public void Draw(SpriteBatch sb, int tileSize, bool swordActive)
        {
            Rectangle rec = new Rectangle((int)this.pos.X, (int)this.pos.Y, tileSize, tileSize);
            Vector2 origin = Vector2.Zero;
            Texture2D temptex = TextureHandler.PlayerTexture;
            SpriteEffects flip = SpriteEffects.None;
            if (!godMode)
            {
                if (direction.X < 0) // If moving left
                {
                    flip = SpriteEffects.FlipHorizontally;
                    temptex = TextureHandler.PlayerTexture;
                }
                if (swordActive && direction.X < 0)
                {
                    flip = SpriteEffects.FlipHorizontally;
                    temptex = TextureHandler.holdingSword;
                }
                else if (swordActive && direction.X > 0)
                {
                    temptex = TextureHandler.holdingSword;
                }


                if (direction.Y < 0 || direction.Y > 0)
                {
                    temptex = TextureHandler.climing;
                }

            }
            else
            {
                if (endMode)
                {

                    if (timer > 3)
                    {
                        temptex = TextureHandler.PlayerShot;
                        rec = new Rectangle((int)this.pos.X, (int)this.pos.Y, tileSize * 2, tileSize);

                    }
                    else 
                    { 
                        temptex = TextureHandler.holdingSword;
                        rec = new Rectangle((int)this.pos.X, (int)this.pos.Y, tileSize , tileSize);

                    }

                }
                else temptex = TextureHandler.holdingSword;
                
                flip = SpriteEffects.FlipHorizontally;
            }



            sb.Draw(temptex, rec, null, Color.White, 0f, origin, flip, 0f);

        }

        public void ChangeDirection(Vector2 dir, int tileSize)
        {
            direction = dir;
            Vector2 newDestination = pos + direction * tileSize;

            if (!(Scenes.GameScene.GetTileAtPosition(newDestination)))//Walkable
            {
                destination = newDestination;
                moving = true;
            }
        }

        public void Reset()
        {
            life = 3;
            moving = false;
            swordActive = false;
            swordTime = 0;
            tex = TextureHandler.PlayerTexture;
            direction = new Vector2(0, 0);
            speed = 6.9f;
            destination = Vector2.Zero;
            godMode = false;

        }
    }
}
