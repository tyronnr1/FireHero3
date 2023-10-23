using GameTemplate.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameTemplate.Scenes
{

    internal class GameScene : Component
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static Tile[,] tileArray;
        public static int tileSize;
        public int screenWidth;
        public int screenHeight;
        Player player;
        Animation monster;

        Animation sword;
        Animation swordIcon;
        Vector2 swordpos;
        public IceMissile[] iceMissileArray;

        Buttons button;
        Buttons[] buttonArray;

        internal override void LoadContent(ContentManager Content, SpriteBatch _spriteBatch)
        {
            spriteBatch = _spriteBatch;
            graphics = Data.graphics;
            tileSize = Data.ScreenH / 16; //Game1.tileSize

            TextureHandler.LoadTextures(Content);

            player = new Player(new Vector2(tileSize * 0 + 605, tileSize * 13 + 70));
            monster = new Animation(spriteBatch, TextureHandler.monster, 640 / 5, 640 / 5, 24, 0.1f);
            sword = new Animation(spriteBatch, TextureHandler.sword, 640 / 5, 384 / 3, 12, 0.1f);
            swordIcon = new Animation(spriteBatch, TextureHandler.sword, 640 / 5, 384 / 3, 12, 0.1f);

            int temp = (Data.ScreenH / tileSize) - 5;

            iceMissileArray = new IceMissile[temp];
            for (int i = 0; i < temp; i++)
            {
                iceMissileArray[i] = new IceMissile(spriteBatch, Content, tileSize, graphics, i + 4);
            }

            CreateLevel("labyrint.txt");
        }

        internal override void Update(GameTime gameTime)
        {

            if (Player.life==0)
            {
                player.Reset();

                player = new Player(new Vector2(tileSize * 0 + 605, tileSize * 13 + 70));
                monster = new Animation(spriteBatch, TextureHandler.monster, 640 / 5, 640 / 5, 24, 0.1f);
                sword = new Animation(spriteBatch, TextureHandler.sword, 640 / 5, 384 / 3, 12, 0.1f);
                swordIcon = new Animation(spriteBatch, TextureHandler.sword, 640 / 5, 384 / 3, 12, 0.1f);

                int temp = (Data.ScreenH / tileSize) - 5;

                iceMissileArray = new IceMissile[temp];
                for (int i = 0; i < temp; i++)
                {
                    iceMissileArray[i] = new IceMissile(spriteBatch, Data.content, tileSize, graphics, i + 4);
                }


                Data.CurrentState = Data.Scenes.Replay;
            }



            player.Update(gameTime, tileSize);
            monster.Update(gameTime);
            sword.Update(gameTime);
            swordIcon.Update(gameTime);



            for (int i = 0; i < iceMissileArray.Length; i++)
            {
                iceMissileArray[i].Update(gameTime, spriteBatch, player.pos, Player.swordActive);

                iceMissileArray[i].Spawn(new Random());

                if (Vector2.Distance(player.pos, iceMissileArray[i].position) < tileSize && Player.swordActive)
                {
                    iceMissileArray[i].IsActive = false;
                }

            }



            if (Vector2.Distance(player.pos, swordpos) < tileSize && !Player.swordActive)
            {
                Player.swordTime = 0;
                Player.swordActive = true;
            }

            if (Player.swordActive)
            {

                Player.swordTime += gameTime.ElapsedGameTime.TotalSeconds;

                if (Player.swordTime >= 20)
                {
                    player.tex = TextureHandler.PlayerTexture;

                    Player.swordActive = false;
                }
            }

            Draw(spriteBatch);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(TextureHandler.backgroundTexture, new Rectangle(0, 0, Data.ScreenW, Data.ScreenH), Color.White);

            foreach (Tile t in tileArray)
            {
                t.Draw(spriteBatch, tileSize);
            }
            player.Draw(spriteBatch, tileSize, Player.swordActive);
            monster.Draw(new Vector2((Data.ScreenW / 2) - (TextureHandler.monster.Width / 5), 30), Color.White, SpriteEffects.None,2);

            if (!Player.swordActive)
            {
                sword.Draw(swordpos, Color.White, SpriteEffects.None,1);
                //sword.Draw(swordpos, Color.Lerp(Color.Transparent, Color.Black, 0.5f), SpriteEffects.None);

            }



            for (int i = 0; i < iceMissileArray.Length; i++)
            {
                iceMissileArray[i].Draw(spriteBatch);

            }

            for (int i = 0; i < Player.life; i++)
            {
                spriteBatch.Draw(TextureHandler.heart, new Rectangle((tileSize + 10) + ((tileSize + 10) * i), tileSize, tileSize + tileSize / 2, tileSize + tileSize / 2), Color.White);

            }
            if (Player.swordActive)
            {
                swordIcon.Draw(new Vector2((tileSize + 10) * 2, (tileSize + 10) * 2), Color.White, SpriteEffects.None,1);
            }



            spriteBatch.End();
        }
        public List<string> ReadFromFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            List<string> result = new List<string>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                result.Add(line);
            }
            streamReader.Close();
            return result;
        }

        public void CreateLevel(string fileName)
        {
            List<string> list = ReadFromFile("mapLayout.txt");

            tileArray = new Tile[list[0].Length, list.Count];
            for (int y = 0; y < list.Count; y++)
            {

                for (int x = 0; x < list[0].Length; x++)
                {
                    Texture2D tex = TextureHandler.errorTile;
                    bool boolean = false;


                    switch (list[y][x])
                    {
                        case '□'://Air
                            tex = TextureHandler.airTexture;
                            boolean = false;
                            break;

                        case '■'://Platform
                            tex = TextureHandler.platformTexture;
                            boolean = true;
                            break;

                        case 'H'://ladder

                            if (x + 1 <= list.Count)
                            {
                                if (list[y][x + 1] == '■')
                                {
                                    tex = TextureHandler.topLadderTexture;
                                }
                                else tex = TextureHandler.ladderTexture;
                            }

                            if (x - 1 >= 0)
                            {
                                if (list[y][x - 1] == '■')
                                {
                                    tex = TextureHandler.topLadderTexture;
                                }
                                else tex = TextureHandler.ladderTexture;
                            }


                            boolean = false;
                            break;
                        case '/':
                            tex = TextureHandler.airTexture;

                            swordpos = new Vector2(x * tileSize + 580, y * tileSize + 40);
                            break;
                        case '¤'://Button
                            tex = TextureHandler.buttonTexture;

                            boolean = false;
                            break;
                    }


                    tileArray[x, y] = new Tile(new Vector2(x * tileSize + 605, y * tileSize + 70), tex, boolean);
                }

            }
        }

        public static bool GetTileAtPosition(Vector2 pos)
        {

            if (
               (((int)pos.X - 605) / tileSize) < 0 ||
               (((int)pos.Y - 70) / tileSize) < 0 ||
               (((int)pos.X - 605) / tileSize) > 14 ||
               (((int)pos.Y - 70) / tileSize) > 14
            )
            {
                return true;
            }


            return tileArray[((int)pos.X - 605) / tileSize, ((int)pos.Y - 70) / tileSize].notWalkable;
        }
        public static Texture2D GetTextureAtPosition(Vector2 pos)
        {
            return tileArray[((int)pos.X - 605) / tileSize, ((int)pos.Y - 70) / tileSize].tex;
        }
    }
}