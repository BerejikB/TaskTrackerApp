using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TaskTrackerApp
{
    public class Program
    {
        //Program theThing = new Program;
        // MakeTaskList() = dothething;
        List<List<object>> TaskList = new List<List<object>>();

        static void Main(string[] args)
        {
            Program Taskboi = new Program();
            Taskboi.FileLoad();

        }
        
        public void FileLoad()
        {
            string[] task = File.ReadAllLines("SavedLists.txt");
            List<object> subList = new List<object>();
            foreach (string line in task)
            {

                    subList = new List<object>(line.Split(','));
                    subList[1] = bool.Parse(subList[1].ToString());
                    TaskList.Add(subList);
   
            }
             Menu();
        }

        void Menu()
        {
            Console.Clear();
            Console.WriteLine("Hello, Dave.");
            Console.WriteLine("1) Show tasks");
            Console.WriteLine("2) Add tasks to list");
            Console.WriteLine("3) Begin task");
            Console.WriteLine("5) Save to file");
            Console.WriteLine("6) Save and Exit");



            int menuboi = int.Parse(Console.ReadLine());

            switch (menuboi)
            {
                case 1:
                    Console.Clear();
                    ShowTasks();

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

                case 5:
                    Console.Clear();
                    SaveToFile();
                    Menu();
                    break;

                case 6:
                    File.WriteAllLines("SavedLists.txt", Unpacker());
                    Environment.Exit(1);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("I'm sorry, I can't let you do that Dave.");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }

        public string[] Unpacker()
        {
            
            string taskname;
            string taskstatus;
            List<string> unpackedlist = new List<string>();

            foreach (List<object> item in TaskList)
            
            {
                taskname = item[0].ToString();
                taskstatus = item[1].ToString();
                unpackedlist.Add($"{taskname}, {taskstatus}");
            }


            return  unpackedlist.ToArray();
        }

        public void ShowTasks()
        {

            Console.Clear();
            Console.WriteLine("List of tasks:");
            foreach (List<object> task in TaskList)
            {
                Console.WriteLine(task[0]);
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            Menu();
        }

        public void  MakeTaskList()

        {
            
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
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            Menu();

        }

        public void SaveToFile()
        {
           

            File.WriteAllLines("SavedLists.txt", Unpacker());
            Console.WriteLine("List Saved!");
            Menu();
           
        }
        

       
    }

       
  
}
    











