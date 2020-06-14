using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageManager gm = new GarageManager();
            StartMenu sm = new StartMenu(gm);
            while(true)
            {
                sm.Show();
            }
        }
    }
}
