using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameTemplate.Core
{
    public class TextureHandler
    {
        public static Texture2D platformTexture;
        public static Texture2D ladderTexture;
        public static Texture2D buttonTexture;
        public static Texture2D airTexture;
        public static Texture2D backgroundTexture;
        public static Texture2D PlayerTexture;
        public static Texture2D topLadderTexture;
        public static Texture2D errorTile;
        public static Texture2D climing;
        public static Texture2D monster;
        public static Texture2D ice;
        public static Texture2D sword;
        public static Texture2D heart;
        public static Texture2D holdingSword;
        public static Texture2D movingIce;
        public static Texture2D iceBreaking;
        public static Texture2D playbutton;
        public static Texture2D logo;
        public static Texture2D ExitButton;



        public static void LoadTextures(ContentManager content)
        {
            platformTexture = content.Load<Texture2D>("platformTile");
            ladderTexture = content.Load<Texture2D>("ladder");
            topLadderTexture = content.Load<Texture2D>("topLadder");
            errorTile = content.Load<Texture2D>("errorTile");
            climing = content.Load<Texture2D>("climingPlayer");

            buttonTexture = content.Load<Texture2D>("buttonTile");
            airTexture = content.Load<Texture2D>("airTile");
            backgroundTexture = content.Load<Texture2D>("background");
            PlayerTexture = content.Load<Texture2D>("PLayer");
            monster = content.Load<Texture2D>("monsterSprite");
            ice = content.Load<Texture2D>("iceproj");
            sword = content.Load<Texture2D>("fireSword");
            heart = content.Load<Texture2D>("fireHeart");
            holdingSword = content.Load<Texture2D>("HoldingSword");
            movingIce = content.Load<Texture2D>("movingIce");
            iceBreaking = content.Load<Texture2D>("iceBreaking");
            playbutton = content.Load<Texture2D>("button");
            logo = content.Load<Texture2D>("logo");
            ExitButton = content.Load<Texture2D>("ExitButton");



        }
    }
}
