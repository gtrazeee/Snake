using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Settings
    {
        public int Witdh { get; set; }
        public int Height { get; set; }
        public static string directions;
        public Boolean pm { get; set; }
        public Settings() 
        {
            Witdh = 16;
            Height = 16;
            directions = "right";
            pm = true;

        }
    }
}
