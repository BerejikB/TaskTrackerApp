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
            Console.WriteLine("3) Complete Task");
            Console.WriteLine("4) Save to file");
            Console.WriteLine("5) Save and Exit");
            Console.WriteLine("6) Save and Exit, again");


            try
            {
                int menuboi = int.Parse(Console.ReadLine());

                switch (menuboi)
                {
                    case 1:
                        Console.Clear();
                        ListTasks();

                        break;
                    case 2:
                        Console.Clear();
                        MakeTaskList();
                        break;
                    case 3:
                        Console.Clear();
                        CompleteTask();
                        break;
                    case 4:
                        Console.Clear();
                        SaveToFile();
                        Menu();
                        break;

                    case 5:
                        File.WriteAllLines("SavedLists.txt", Unpacker());
                        Environment.Exit(1);
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
                Console.ReadKey();
                
            }
            catch (Exception) {Console.WriteLine("I'm sorry, I can't let you do that Dave."); }
            Menu();
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


            return unpackedlist.ToArray();
        }

        public void MakeTaskList()

        {

            List<object> subList = new List<object>();

            Console.WriteLine("Enter a task to add, when finished leave blank and press 'enter'");

            string userinput;
            bool userinputstatus = false;
            do
            {
                Console.WriteLine("Enter a task, when finished leave blank and press 'enter'");
                Console.WriteLine();
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
            
            SaveToFile();
            

        }

        public void SaveToFile()
        {


            File.WriteAllLines("SavedLists.txt", Unpacker());
            Console.WriteLine("List Saved!");
            Menu();

        }

        public void WritePageTask()
        {

            Console.Clear();
            int pageSize = 24;
            Console.WriteLine("Select Page Number");
            int pageNum = int.Parse(Console.ReadLine()) - 1;
            Console.Clear();
            Console.WriteLine($"Page {pageNum + 1} Selected");
            Console.WriteLine("============================================================================================================================");
            int startIndex = pageNum * pageSize;

            for (
                int counter = startIndex;
                counter < startIndex + pageSize && counter < TaskList.Count;
                 ++counter)
            {
                if 
                    ( 
                    !(bool)TaskList[counter][1]
                    ) { Console.WriteLine($"{counter+1}). {TaskList[counter][0]} "); }
                    else { WriteGrayLine($"{counter + 1}). {(string)TaskList[counter][0]} "); }
                
            }

           
            

        }

        public void CompleteTask()
        {
            WritePageTask();
            Console.WriteLine();
            Console.WriteLine("Select a task by number to complete");

            int userInput;
            try
            { 
                userInput = int.Parse(Console.ReadLine()) - 1;
                TaskList[userInput][1] = true;
                Console.WriteLine();
                Console.WriteLine($"Task {userInput + 1} is now marked as complete");
                Console.WriteLine();
                Console.WriteLine($"Press any key to return to main menu");
                Console.ReadKey();
            }
                catch (Exception) { Console.WriteLine("Invalid input, returning to menu");
                Console.ReadKey();
                Menu(); 
            }

            SaveToFile();
        }

        public void ListTasks()
        {
            WritePageTask();
            Console.WriteLine();

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Menu();

        }

        public void WriteGrayLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }
    }

}




    

       


       
  

    











