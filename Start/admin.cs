using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Start
{
    class Admin : Product 
    {
        static private string AdminName { get; } = "mas";
        static private string AdminPassword { get; } = "123";


        static public void CheckAdmin()
        {
        wrong:
            Console.WriteLine("\n\t\t\t < Verifying Adim >");

            Console.Write("\n Enter Username : ");
            string name = Console.ReadLine();
            Console.Write("\n Enter Password : ");
            string pass = Console.ReadLine();
            if (name != AdminName || pass != AdminPassword)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\tWrong Username or Password!");
                goto wrong;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\n\t\t\t\t\t Welcom Admin {name}");
                AdminList();
            }

            Console.Clear();

        }
        static public void AdminList() {

            Console.Clear();
            again:
            Console.WriteLine("\n Choose what you want :\n");

            Console.Write("\n 1. Add Product \n 2. Delete Product \n 3. Search for Product \n 4. Disply Products\n 5. Show Seals \n 6. Go back\n\n Enter number :  ");

            string What = Console.ReadLine();
            Product Pro = new Product();
            switch (What)
            {

                case "1":
                    Console.Clear();
                    Pro.AddProduct();

                    break;
                case "2":
                    Console.Clear();

                    Pro.DeleteProduct();

                    break;
                case "3":
                    Console.Clear();

                    Pro.SearchProduct();

                    break;
                case "4":

                    Console.Clear();

                    Pro.DisplayProducts();

                    break;
                case "5":
                    Seals.GetSeals();
                    break;
                case "6":

                    Program.Start();

                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Wrong Input!");
                    goto again;


            }
            
        }

    }
}
