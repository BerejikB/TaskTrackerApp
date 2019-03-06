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
            Menu();
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
                    Console.Clear();
                    Console.WriteLine("I'm sorry, I can't let you do that Dave.");
                    Console.ReadKey();
                    Menu();
                    break;
                case 2:
                    Console.Clear();
                    MakeTaskList();
                     break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("I'm sorry, I can't let you do that Dave.");
                    Console.ReadKey();
                    Menu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("I'm sorry, I can't let you do that Dave.");
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("I'm sorry, I can't let you do that Dave.");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }



        static void MakeTaskList()


        {
            List<List<object>> TaskList = new List<List<object>>();
            List<object> subList = new List<object>();

            Console.WriteLine("Enter a task to add, when finished leave blank and press 'enter'");

            string userinput;
            bool userinputstatus = false;
            do
            {
                Console.WriteLine("Enter a task");
                userinput = Console.ReadLine();
                

                if (!string.IsNullOrEmpty(userinput))
                {
                    subList.Add(userinput);
                    subList.Add(userinputstatus);
                    TaskList.Add(subList);
                    subList = new List<object>();
                }

            } while (!string.IsNullOrEmpty(userinput));


            Console.Clear();
            Console.WriteLine("List of tasks:");
            foreach (List<object> task in TaskList)
            {
                Console.WriteLine(task[0]);
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











