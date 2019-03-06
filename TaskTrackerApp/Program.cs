using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TaskTrackerApp
{
    class Program
    {

        static void Main(string[] args)
        {
            MakeTaskList();
        }


        static void Menu()
        {
            Console.WriteLine("Hello, Dave.");
            Console.WriteLine("1) Show tasks");
            Console.WriteLine("2) Add tasks to list");
            Console.WriteLine("3) Begin task");
            Console.WriteLine("4) Exit");


            int menuboi = int.Parse(Console.ReadLine());
            
            switch (menuboi)
            {
                case 1:
                   // Statement
                     break;
                case 2:
                    MakeTaskList();
                     break;
                case 3:
                    //Statement
                     break;
                case 4:
                    //Statement
                     break;
                default:
                    Console.WriteLine("I'm sorry, I can't let you do that Dave.");
                    break;
            }
        }

















        static void MakeTaskList()


        {
            List<string> TaskList = new List<string>();
            Console.WriteLine("Enter a task to add, when finished leave blank and press 'enter'");

            string userinput;
            do
            {
                Console.WriteLine("Enter a task");
                userinput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userinput))
                {
                    TaskList.Add(userinput);
                }

            } while (!string.IsNullOrEmpty(userinput));


            Console.Clear();
            Console.WriteLine("List of tasks:");
            foreach (var item in TaskList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            MakeFile();

        }


        public static void MakeFile()
        {
          
        }


        static void writetofile()
        {
            string path = @"c:\temp\MyTest.txt";

            string[] createText = { "Hello", "And", "java2s.com" };
            File.WriteAllLines(path, createText, Encoding.UTF8);


            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string s in readText)
            {
                Console.WriteLine(s);
                
            }
        }

       
  
        }
    }











