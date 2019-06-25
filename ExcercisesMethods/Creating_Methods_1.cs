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
                MoreOptions();
            }

            Console.WriteLine("Enter a string of names seperated by comma: ");
            List<string> separatedNames = GetNames(Console.ReadLine());
            foreach (string s in separatedNames)
            {
                Program.PrintGreenMsg($"***{s.ToUpper()}***");
            }
            Program.Restart();
        }
        static void MoreOptions()
        {
            string input = string.Empty;

            Console.WriteLine("Which separator do you want to use (default is comma) ? : ");
            input = Console.ReadLine();
            if(input.Length != 1)
            {
                Program.PrintRedMsg("Input should only be one character! ");
                MoreOptions();
            }
            else
            {
                Program.seperator = input;
            }
            Console.WriteLine("Do you want to see error messages (default is yes) ? : ");
            input = Console.ReadLine().ToLower();
            if(Program.yesWords.Contains(input) == true)
            {
                Program.seeErrorMsg = true;
            }
            if (Program.noWords.Contains(input) == true)
            {
                Program.seeErrorMsg = false;
            }
            if (Program.yesWords.Contains(input) == false && Program.noWords.Contains(input) == false)
            {
                Program.PrintRedMsg($"Didn't recognize: '{input}'");
                MoreOptions();
            }
        }
        static void ValidateInputString(string input)
        {
            if(input == string.Empty)
            {
                Program.PrintRedMsg($"Empty input! ");
                Start(false);
            }
        }
        static bool ValidateName(string name)
        {
            bool value = true;

            if(name.Length < 2 || name.Length > 9)
            {
                Program.PrintRedMsg($"A person can only have 2 to 9 letters! ");
                value = false;
            }
            foreach (char c in name)
            {
                if(char.IsLetter(c) == false)
                {
                    Program.PrintRedMsg($"Couldn't convert {c} to a letter! ");
                    value = false;
                }
            }
            return value;
        }
        static List<string> GetNames(string input)
        {
            ValidateInputString(input);
            string[] stringArray = input.Split(Program.seperator);
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
                    Program.PrintRedMsg($"The format on {stringArray[i]} is wrong wont be adding it! ");
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
