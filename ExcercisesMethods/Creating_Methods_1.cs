using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExcercisesMethods
{
    class Creating_Methods_1
    {
        static public void Start(bool reset)
        {
            if(reset == true)
            {
                Console.Clear();
                Console.WriteLine("Module 1 loaded: Creating Methods: ");
            }

            Console.WriteLine("Enter a string of names seperated by comma: ");
            List<string> separatedNames = GetNames(Console.ReadLine());
            foreach (string s in separatedNames)
            {
                Program.PrintColoredMessage($"***{s.ToUpper()}***", ConsoleColor.Green);
            }
            Program.Restart();
        }
        static void ValidateInputString(string input)
        {
            if(input == string.Empty)
            {
                Program.PrintColoredMessage($"Empty input! ", ConsoleColor.Red);
                Start(false);
            }
        }
        static bool ValidateName(string name)
        {
            bool value = true;

            if(name.Length < 2 || name.Length > 9)
            {
                Program.PrintColoredMessage($"A person can only have 2 to 9 letters! ", ConsoleColor.Red);
                value = false;
            }
            foreach (char c in name)
            {
                if(char.IsLetter(c) == false)
                {
                    Program.PrintColoredMessage($"Couldn't convert {c} to a letter! ", ConsoleColor.Red);
                    value = false;
                }
            }
            return value;
        }
        static List<string> GetNames(string input)
        {
            ValidateInputString(input);
            string[] stringArray = input.Split(",");
            List<string> stringList = new List<string>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                string stringFormatted = FormatString(stringArray[i]);

                if(ValidateName(stringFormatted) == true)
                {
                    stringList.Add(stringArray[i]);
                }
                else
                {
                    Program.PrintColoredMessage($"The format on {stringArray[i]} is wrong wont be adding it! ", ConsoleColor.Red);
                }
            }
            return stringList;
        }
        static string FormatString(string input)
        {
            return input.Trim().ToUpper();
        }
    }
}
