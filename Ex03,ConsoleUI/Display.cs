using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    public class Display
    {
        public static void Write(string i_Msg)
        {
            Console.WriteLine(i_Msg);
        }

        public static string Read()
        {
            return Console.ReadLine();
        }

    }
}
