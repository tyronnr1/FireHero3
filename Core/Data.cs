using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTemplate.Core
{
    public static class Data
    {
        public static int ScreenW { get; set; } = 1600;
        public static int ScreenH { get; set; } = 900;
        public static bool Exit { get; set; } = false;

        public enum Scenes { Menu,Game,Setting}
        public static Scenes CurrentState { get; set; } = Scenes.Menu;
    }
}
