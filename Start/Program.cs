using System;
using System.IO;

namespace Start
{
    class Program 
    {
        static public void Start()
        {
            Console.Clear();
            again:
            Console.WriteLine("\n Admin or Customer ?");
            Console.Write("\n 1. Admin\n 2. Customer\n 3. Exit\n\n Enter number : ");
            int What = 0;
            try
            {
                What = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\tWrong Input! Enter number between 1-3 ");
                goto again;

            }
            if(What == 1)
            {
                Console.Clear();
                Admin.CheckAdmin();
            }
            else if(What == 2)
            {
                Customer.buy();

            }
            else if (What == 3)
            {
                Console.WriteLine("\n\n\t\t\t\t\t Have a nice day!");
                Console.ReadKey();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\tWrong Input! Enter number between 1-3 ");
                goto again;
            }
        }

        static void Main(string[] args)
        {

            Program.Start();
        }
    }
}
