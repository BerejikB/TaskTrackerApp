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
        FileEngine FileEngineCall = new FileEngine();

        static void Main(string[] args)
        {
            InitFiles();
            Program menuinit = new Program();
            menuinit.Menu();

        }

        static void InitFiles()
        {
            using (StreamWriter w = File.AppendText("TasksInProgress.txt")) ;
            using (StreamWriter w = File.AppendText("CompletedTasks.txt")) ;

            Program menuinit = new Program();
            menuinit.Menu();
        }
       

         public void Menu()
        {

            Console.WriteLine("Welcome!");
            Console.WriteLine("Choose an option");
            Console.WriteLine("1) Display tasks");
            Console.WriteLine("2) Start task");
            Console.WriteLine("3) Add task to list");
            Console.WriteLine("4) Complete item");
            Console.WriteLine("5) Save list and exit ");
            try
            {
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                { DisplayFile(); }

                if (userInput == 2)
                { StartTask(); }
                               
                if (userInput == 3)
                { AddTask(); }

                if (userInput == 4)
                { CompleteItem(); }

                if (userInput == 5)
                { SaveExit(); }

                else { Console.WriteLine("Invalid option"); }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
               /// fix this Menu() men = new Menu();
            }
        }

        public string DisplayFile()
        {

            string inprogdisp = FileEngineCall.FileReader();
           
            return inprogdisp;
            
        }



        public string SelectTask()
        {
            

            //Select first item on list
            string task;
            task = "Placeholder";
            return task;
        }


        void StartTask()
        {
            Console.WriteLine(SelectTask());
            //ask if you are ready for the item
            char userInput;
            Console.WriteLine("Are you ready to work on this task? Y/N");
            userInput = char.Parse(Console.ReadLine());

            try { 
            if (userInput == 'y') 
                {
                //set task in progress
                SetInProg();
                }
            if (userInput == 'Y')
                {
                //set task in progress
                SetInProg();
                 }
            if (userInput == 'n')
            {
                //go to next task
                //select next item in list
            }
            if (userInput == 'N')
            {
                //go to next task
                //select next item in list
            }
            else 
            { Console.WriteLine("Invalid Input, press Y or N");  }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
                StartTask();
            }


        }
         void SetInProg()
        {

        }
        

         void AddTask()
        {

            List<string> taskInProg = new List<string>();
            Console.WriteLine("Name your task:");
            taskInProg.Add(Console.ReadLine());

            //List<string> taskInProgDate = new List<string>();
            // Console.WriteLine("Set a date for your task:");
            // taskInProgDate.Add(Console.ReadLine());


            SaveList();

        }

         void CompleteItem()
        {
            Console.WriteLine("WIP");
            Console.ReadKey();
            SaveList();
        }
         void SaveExit()
        {
                Console.WriteLine("WIP");
                Console.ReadKey();
            SaveList();
        }

         void SaveList()
        {
            Menu();
        }
        
    }







       public class FileEngine
        {
            FileEngine FileEngineCall = new FileEngine();

    //        public string FileWriter()
    //        {
    //
    //            string inProgFile = "TasksInProgress.txt";
    //            using (StreamWriter writer = new StreamWriter(inProgFile))
    //            {
    //                writer.WriteLine("This tutorial explains how to use StreamReader Class in C# Programming"); //input from addtask
    //               writer.WriteLine("Good Luck!");
    //           }
    //        }



  
    public Tuple<string, string> FileReader(string inProgFile , string completedfile)
        {

            inProgFile = "TasksInProgress.txt";
            using (StreamReader reader = new StreamReader(inProgFile))
            {
                Console.WriteLine("Tasks to do:");
                Console.WriteLine(reader.ReadToEnd());
            }
            
            
            completedfile = "Completed.txt";
            using (StreamReader reader = new StreamReader(completedfile))
            {
                Console.WriteLine("Completed Tasks");
                Console.WriteLine(reader.ReadToEnd());
            }
        return new Tuple<string, string>(inProgFile, completedfile);
        }




    }
}

}
