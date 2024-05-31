using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Start
{
    class Seals 
    {
        static public void GetSeals()
        {
            Console.Clear();
            if (File.Exists("seals.txt") == true) {
                StreamReader Sreader = new StreamReader("seals.txt");
                Console.WriteLine("\n\t\t\t < Existing Seals >\n");
                Console.WriteLine(" Product      Invoice-ID       Count          Cost             Date");
                Console.WriteLine("______________________________________________________________________");



                string line = Sreader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = Sreader.ReadLine();

                }
                Console.WriteLine("_______________________________________________________________________");

                Sreader.Close();
            }
            else
            {
                Console.WriteLine("\n\t There are no seals yet!\n");
            }

            Console.Write("\n Go back? [yes] : ");
            string yno = Console.ReadLine();
            if (yno.ToLower() == "yes")
            {
                Admin.AdminList();
            }
            else
            {
                Console.WriteLine("\n\n\t\t\t\t\tHave a great day!");
                Console.ReadKey();
            }

        }
    }
}
