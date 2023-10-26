using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace GameTemplate.Core
{
    public static class Data
    {
        public static int ScreenW { get; set; } = 2560;
        public static int ScreenH { get; set; } = 1440;
        public static bool Exit { get; set; } = false;
        public static bool Replay { get; set; } = false;

        public static SpriteBatch spriteBatch { get; set; }
        public static GraphicsDeviceManager graphics { get; set; }
        public static ContentManager content { get; set; }

        public static GameTime gameTime { get; set; }
        public enum Scenes { Menu, Game, Replay, Win }
        public static Scenes CurrentState { get; set; } = Scenes.Menu;
    }
}
