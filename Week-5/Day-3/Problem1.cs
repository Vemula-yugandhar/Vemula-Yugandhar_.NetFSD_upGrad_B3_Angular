namespace Collections
{
    internal class Program
    {

        //Add Task
        static void AddTask(List<string> list)
        {
            Console.Write("Enter Task: ");
            string task = Console.ReadLine();
            list.Add(task);
            Console.WriteLine("Task Added Successfully!");
        }

        //View Task
        static void ViewTask(List<string> list)
        {
            if(list.Count == 0) {
                Console.WriteLine("List is Empty, Please add tasks.");
            }
            else
            {
                Console.WriteLine("-----All Tasks:-----");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + list[i]);
                }
            }
            
        }

        //Remove Task
        static void RemoveTask(List<string> list)
        {
            Console.Write("Enter task to remove: ");
            int index = int.Parse(Console.ReadLine());
            list.RemoveAt(index);
            Console.WriteLine($"Removed: {index}");


            /*string remove = Console.ReadLine();
            if (string.IsNullOrEmpty(remove))
            {
                Console.WriteLine("Invalid task please re-enter the task.");

            }
            else
            {
                list.Remove(remove); 
                Console.WriteLine($"Removed: {remove}");
            }*/
        }

        //Exit Task
        static void Exit()
        {
            Console.WriteLine("Program Excited Succesfully");
        }
        static void Main(string[] args)
        {

            //Create list to add tasks
            List<string> list = new List<string>();


            int choice;

            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("---------TO-DO LIST--------");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Task");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4.. Exit");
                Console.WriteLine("==================================================");

                Console.Write("Choose an Task:  ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: 
                        AddTask(list);
                        break;

                    case 2:
                        ViewTask(list);
                        break;

                    case 3:
                        RemoveTask(list);
                        break;

                    case 4:
                        Exit();
                        break;

                    default:
                        Console.WriteLine("Invalid Task Number");
                        break;
                }
            } while (choice != 4);

        }
    }
}
