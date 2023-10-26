using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameTemplate.Core
{
    internal class Buttons
    {
        public Vector2 pos;
        public bool active;
        public int tileSize;

        public static bool allClicked = false;

        public static int amount = 0;
        public static int amountClicked = 0;
        public Texture2D tex;


        public Buttons(Vector2 pos, int tileSize)
        {
            this.pos = pos;
            this.tileSize = tileSize;
            amount++;
            active = true;
            tex = TextureHandler.buttonTexture;
        }

        public void Update(Vector2 playerpos)
        {
            if (active)
            {
                tex = TextureHandler.buttonTexture;

                bool collision = CheckIfPlayerTouching(playerpos);
                if (collision)
                {
                    active = false;
                    amountClicked++;
                    tex = TextureHandler.ClickedButton;
                    if (amountClicked == amount)
                    {
                        allClicked = true;
                    }


                }
            }

        }

        private bool CheckIfPlayerTouching(Vector2 playerpos)
        {
            if (Vector2.Distance(playerpos, pos) < tileSize / 3)
            {
                Player.points += 53;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            active = true;
            amountClicked = 0;
            amount = 0;
        }
    }
}
