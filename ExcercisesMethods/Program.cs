using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ExcercisesMethods
{
    class Program
    {
        static public List<string> yesWords = new List<string>();
        static public List<string> noWords = new List<string>();
        public static string seperator { get; set; }
        public static bool seeErrorMsg { get; set; }

        static void Main(string[] args)
        {
            ReadXml();
            Creating_Methods_1.Start(true);
        }
        static void ReadXml()
        {
            string runTimePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            runTimePath = runTimePath + "../../../";
            string playersXmlText = File.ReadAllText(runTimePath + $"\\settings.xml");

            XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(playersXmlText));

            if (xmlTextReader.ReadToDescendant("settings"))
            {
                XmlReader xmlReader = xmlTextReader.ReadSubtree();
                while(xmlReader.Read())
                {
                    switch(xmlReader.Name)
                    {
                        case "setting":
                            //Console.WriteLine("setting");
                            XmlReadSetting(xmlTextReader.ReadSubtree());
                            break; ;
                        case "yesword":
                            //Console.WriteLine("yesword");
                            yesWords = XmlReadWord(xmlReader.ReadSubtree());
                            break;
                        case "noword":
                            //Console.WriteLine("noword");
                            noWords = XmlReadWord(xmlReader.ReadSubtree());
                            break;
                    }
                }
            }
        }
        static void XmlReadSetting(XmlReader reader)
        {
            //Console.WriteLine("XmlReadSetting");
            while (reader.Read())
            {
                //Console.WriteLine(reader.Name);
                switch (reader.Name)
                {
                    case "separator":
                        reader.Read();
                        seperator = reader.ReadContentAsString();
                        //Console.WriteLine("separator: " + seperator);
                        break;
                    case "seeError":
                        reader.Read();
                        seeErrorMsg = reader.ReadContentAsBoolean();
                        //Console.WriteLine("seeError: " + seeErrorMsg);
                        break;
                }
            }
        }
        static List<string> XmlReadWord(XmlReader reader)
        {
            List<string> wordList = new List<string>();
            //Console.WriteLine("XmlReadWord");

            while(reader.Read())
            {
                if(reader.Name == "word")
                {
                    //Console.WriteLine("loop");
                    reader.Read();
                    wordList.Add(reader.ReadContentAsString());
                }
            }

            return wordList;
        }
        //Returns the content of a file in the root directory of your project.
        static string DataReader(string fileName)
        {
            string runTimePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            runTimePath = runTimePath + "../../../";

            string result = File.ReadAllText(runTimePath + $"\\{fileName}");
            return result;
        }
        static public void PrintRedMsg(string message)
        {
            if (seeErrorMsg == false)
                return;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static public void PrintGreenMsg(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static public void Restart()
        {
            Console.WriteLine("Enter 'r' to restart or 'q' to quit: ");
            string input = Console.ReadLine().ToUpper();
            switch(input)
            {
                case "R":
                    Console.Clear();
                    Main(null);
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Restart();
                    break;
            }

        }
    }
}
