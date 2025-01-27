﻿using System;
using System.Collections.Generic;

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

        public static void WriteEnum(Type i_EnumType)
        {
            Array arr = Enum.GetValues(i_EnumType);
            foreach(object option in arr)
            {
                Write(string.Format("{1}--{0}", option, (int)option));
            }
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void WriteStringArray(string[] i_StringArray)
        {
            for(int i = -0; i < i_StringArray.Length; i++) 
            {
                Write(string.Format("{1}--{0}", i_StringArray[i], i));
            }
        }

        public static void Wait()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public static void PressToContinue()
        {
            Write("Press Any Key To Continue");
            Console.ReadKey();
        }

        public static void WriteList(List<string> i_List)
        {
            foreach(string s in i_List)
            {
                Write(s);
            }
        }
    }
}
