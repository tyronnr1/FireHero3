using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace GameTemplate.Core
{
    internal class Buttons
    {
        public Vector2 pos;
        public bool active;
        public static bool allClicked=false;
        public int tileSize;
        public static int amount=0;


        public Buttons(Vector2 tilePos,int tileSize)
        {
            this.pos = new Vector2(tilePos.X* tileSize, tilePos.Y* tileSize);
            active = true;
            this.tileSize = tileSize;
            amount++;
        }

        public void Update(Vector2 playerPos)
        {
            if (Vector2.Distance(pos, playerPos)<this.tileSize && active)
            {
                active = false;
                
            }
            AllClicked(active);
           

        }

        public static void AllClicked(bool active)
        {
            if(!active)
            {
                amount-=1;
            }
            if (amount == 0)
            {
                allClicked = true;
            }
        }
    }
}
