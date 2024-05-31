using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Start
{
    class Product : ProductOpperations
    {
        static protected string ProductName { get; set; }
        static protected string ProductId { get; set; }
        static protected string Productprice { get; set; }
        static protected string ProductCount { get; set; }

        
        ////////////////////////////////////
        public void AddProduct()
        {
        again:
            Console.WriteLine("\n\t\t\t < Adding Product >\n");

            StreamWriter pWriter = File.AppendText("pdata.txt");
            StreamWriter cWriter = File.AppendText("cdata.txt");
        nameAgain:
            Console.Write("\n Enter product's name : ");
            ProductName = Console.ReadLine();
            if (File.Exists("ndata.txt") == true)
            {
                StreamReader nReader = new StreamReader("ndata.txt");
                string nrepeat = nReader.ReadLine();
                while (nrepeat != null)
                {
                    if (ProductName == nrepeat)
                    {
                        Console.Clear();
                        Console.WriteLine($"\t\t\t\t\tName \"{nrepeat}\" already exists!");
                        nReader.Close();
                        goto nameAgain;
                    }

                    nrepeat = nReader.ReadLine();

                }

                nReader.Close();
            }

            StreamWriter nWriter = File.AppendText("ndata.txt");

        IDAgain:

            Console.Write(" Enter product's ID-Number : ");
            ProductId = Console.ReadLine();
            if (int.TryParse(ProductId, out int i) && i <= 0)
            {
                Console.WriteLine("\t\t\t\t\t No negative-number or 0 Allowed!");
                goto IDAgain;

            }
            else if (i > 0) { }
            else
            {
                Console.WriteLine("\t\t\t\t\t Invalid ID-number!");
                goto IDAgain;
            } 

            if (File.Exists("idata.txt") == true)
            {
                StreamReader iReader = new StreamReader("idata.txt");
                string irepeat = iReader.ReadLine();
                while (irepeat != null)
                {
                    if (ProductId == irepeat)
                    {
                        Console.WriteLine($"\t\t\t\t\t ID \"{irepeat}\" already Used!");
                        iReader.Close();
                        goto IDAgain;
                    }

                    irepeat = iReader.ReadLine();

                }

                iReader.Close();
            }



            StreamWriter iWriter = File.AppendText("idata.txt");
            PriceAgain:
            Console.Write(" Enter product's Price : ");
            Productprice = Console.ReadLine();
            if (int.TryParse(Productprice,out int p) && p <=0)
            {
                Console.WriteLine("\t\t\t\t\t No negative-number or 0 Allowed!");
                goto PriceAgain;

            }
            else if(p > 0){}
            else
            {
                Console.WriteLine("\t\t\t\t\t Invalid price!");
                goto PriceAgain;
            }

        CountAgain:
            Console.Write(" Enter product's Count : ");
            ProductCount = Console.ReadLine();
            if (int.TryParse(ProductCount, out int c) && c <= 0)
            {
                Console.WriteLine("\t\t\t\t\t No negative-number or 0 Allowed!");
                goto CountAgain;

            }
            else if (c > 0) { }
            else
            {
                Console.WriteLine("\t\t\t\t\t Invalid count-number!");
                goto CountAgain;
            }


            nWriter.WriteLine($"{ProductName}");
            iWriter.WriteLine($"{ProductId}");
            pWriter.WriteLine($"{Productprice}");
            cWriter.WriteLine($"{ProductCount}");

            nWriter.Close();
            iWriter.Close();
            pWriter.Close();
            cWriter.Close();

            Console.WriteLine(" \n\tProducte added\n");
            Console.Write(" Do yo wnat to add another product? [yes/no] : ");
            string yn = Console.ReadLine();
            if (yn.ToLower() == "yes")
            {
                Console.Clear();
                goto again;
            }
            else if (yn.ToLower() == "no")
            {
                Console.Clear();
                Admin.AdminList();
            }
            else
            {

                Console.WriteLine("\n\n\n\t\t\t\t\t OK, Have a good day!\n\n\n");
                Console.ReadKey();
            }




        }

       
       ////////////////////////////////////////// 

        public void DeleteProduct()
        {



            if (File.Exists("ndata.txt") == false)
            {
                Console.WriteLine("\nThere are no products!\n");

                Console.Write("\n\nGo back to menu? [yes] : ");
                string yno = Console.ReadLine();
                if (yno.ToLower() == "yes")
                {
                    Console.Clear();
                    Admin.AdminList();
                }
                else
                {
                    Console.WriteLine("\n\n\t\t\t\t\t have a great day!");
                    Console.ReadKey();
                }

            }
            else
            {
            again:
                Console.WriteLine("\n\t\t\t < Deleting Product >");

                Console.Write(" 1. Delete one product \n");
                Console.Write(" 2. Delete all products \n");
                Console.Write(" 3. Go back\n\n Enter number : ");

                string what = Console.ReadLine();
                if (what == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t < Deleting a Product >\n");

                    Console.WriteLine("\t\t\t< Existing Products > \n");
                    if (File.Exists("ndata.txt"))
                    {
                        StreamReader n2Reader = new StreamReader("ndata.txt");
                        StreamReader p2Reader = new StreamReader("pdata.txt");
                        StreamReader c2Reader = new StreamReader("cdata.txt");




                        Console.WriteLine("    Name                 Price               Count\n __________________________________________________________________________");

                        string ndata = n2Reader.ReadLine();
                        string pdata = p2Reader.ReadLine();
                        string cdata = c2Reader.ReadLine();


                        while (ndata != null)
                        {
                            Console.WriteLine($"    {ndata}                  {pdata}                  {cdata}");
                            ndata = n2Reader.ReadLine();
                            pdata = p2Reader.ReadLine();
                            cdata = c2Reader.ReadLine();


                        }

                        Console.WriteLine("_________________________________________________________________________\n\n");
                        n2Reader.Close();
                        p2Reader.Close();
                        c2Reader.Close();

                    }

                    string Pro;
                    Console.Write("\n Enter name of product you want to delete : ");
                    Pro = Console.ReadLine();
                    StreamReader nReader = new StreamReader("ndata.txt");
                    StreamWriter nWriter = new StreamWriter("ndata2.txt");
                    StreamReader iReader = new StreamReader("idata.txt");
                    StreamWriter iWriter = new StreamWriter("idata2.txt");
                    StreamReader pReader = new StreamReader("pdata.txt");
                    StreamWriter pWriter = new StreamWriter("pdata2.txt");
                    StreamReader cReader = new StreamReader("cdata.txt");
                    StreamWriter cWriter = new StreamWriter("cdata2.txt");

                    int i = 0;
                    string nline = nReader.ReadLine();
                    string iline = iReader.ReadLine();
                    string pline = pReader.ReadLine();
                    string cline = cReader.ReadLine();


                    while (nline != null)
                    {
                        if (nline.ToLower().Contains(Pro.ToLower()))
                        {
                            i++;
                            Console.WriteLine("    Name              ID                 Price               Count\n _____________________________________________________________________________");
                            Console.WriteLine($"    {nline}               {iline}                  {pline}                  {cline}");
                            Console.WriteLine("___________________________________________________________________\n");
                            Console.Write("\n Confirm deleting product [yes] : ");
                            string yn = Console.ReadLine();
                            if (yn.ToLower() == "yes")
                            {
                                Console.WriteLine("\n\n\t\tProduct deleted.\n\n");
                            }
                            else
                            {
                                Console.WriteLine("\n\t\tDeleting canceled.\n\n");
                                nWriter.WriteLine(nline);
                                iWriter.WriteLine(iline);
                                pWriter.WriteLine(pline);
                                cWriter.WriteLine(cline);

                            }
                        }
                        else
                        {
                            nWriter.WriteLine(nline);
                            iWriter.WriteLine(iline);
                            pWriter.WriteLine(pline);
                            cWriter.WriteLine(cline);
                        }
                        nline = nReader.ReadLine();
                        iline = iReader.ReadLine();
                        pline = pReader.ReadLine();
                        cline = cReader.ReadLine();


                    }


                    nReader.Close();
                    iReader.Close();
                    pReader.Close();
                    cReader.Close();

                    nWriter.Close();
                    iWriter.Close();
                    pWriter.Close();
                    cWriter.Close();

                    File.Delete("ndata.txt");
                    File.Delete("idata.txt");
                    File.Delete("pdata.txt");
                    File.Delete("cdata.txt");

                    File.Move("ndata2.txt", "ndata.txt");
                    File.Move("idata2.txt", "idata.txt");
                    File.Move("pdata2.txt", "pdata.txt");
                    File.Move("cdata2.txt", "cdata.txt");

                    if (i == 0)
                    {
                        Console.WriteLine("\n\n\t\tNo such product!\n");
                    }

                    Console.Write("\n\n Go back to menu? [yes] : ");
                    string yno = Console.ReadLine();
                    if (yno.ToLower() == "yes")
                    {
                        Console.Clear();
                        Admin.AdminList();
                    }
                    else
                    {
                        Console.WriteLine("\n\n\t\t\t\t have a great day!");
                        Console.ReadKey();
                    }
                }
                else if (what == "2")
                {
                    ////////
                    Console.WriteLine("\n\t\t\t < Deleting all Products \n>");

                    Console.WriteLine("\t\t\t< Existing Products > \n");
                    if (File.Exists("ndata.txt")) {
                        StreamReader n2Reader = new StreamReader("ndata.txt");
                        StreamReader p2Reader = new StreamReader("pdata.txt");
                        StreamReader c2Reader = new StreamReader("cdata.txt");




                        Console.WriteLine("    Name                 Price               Count\n __________________________________________________________________________");

                        string ndata = n2Reader.ReadLine();
                        string pdata = p2Reader.ReadLine();
                        string cdata = c2Reader.ReadLine();


                        while (ndata != null)
                        {
                            Console.WriteLine($"    {ndata}                  {pdata}                  {cdata}");
                            ndata = n2Reader.ReadLine();
                            pdata = p2Reader.ReadLine();
                            cdata = c2Reader.ReadLine();


                        }

                        Console.WriteLine("_________________________________________________________________________\n\n");
                        n2Reader.Close();
                        p2Reader.Close();
                        c2Reader.Close();

                    }
                    ////////
                    string yn;
                    Console.Write(" Confirm deleting all products? [yes] : ");
                    yn = Console.ReadLine();
                    if (yn.ToLower() == "yes")
                    {
                        File.Delete("ndata.txt");
                        File.Delete("idata.txt");
                        File.Delete("pdata.txt");
                        File.Delete("cdata.txt");

                        Console.WriteLine("\n\nProducts deleted.\n\n");

                        Console.Write("Go back to menu? [yes] : ");
                        string yno = Console.ReadLine();
                        if (yno.ToLower() == "yes")
                        {
                            Console.Clear();
                            Admin.AdminList();
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t\t\t\t have a great day!");
                            Console.ReadKey();
                        }


                    }
                    else
                    {
                        Console.WriteLine("\n\t\tDeleting canceled.\n\n");

                        Console.Write("\n\n Go back to menu? [yes] : ");
                        string yno = Console.ReadLine();
                        if (yno.ToLower() == "yes")
                        {
                            Console.Clear();
                            Admin.AdminList();
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t\t\t\t have a great day!");
                            Console.ReadKey();
                        }
                    }


                }
                else if (what == "3")
                {
                    Console.Clear();
                    Admin.AdminList();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t\t\tWrong Input!\n");
                    goto again;
                }

            }



        }

        ///////////////////////////////////////
        public void SearchProduct()
        {

            if (File.Exists("ndata.txt"))
            {
                Console.WriteLine("\n\t\t\t < Searching for Product >\n");

                string Pro;
                Console.Write("\nEnter name of product you want to search for : ");
                Pro = Console.ReadLine();
                StreamReader nReader = new StreamReader("ndata.txt");
                StreamReader iReader = new StreamReader("idata.txt");
                StreamReader pReader = new StreamReader("pdata.txt");
                StreamReader cReader = new StreamReader("cdata.txt");



                int i = 0;
                string nline = nReader.ReadLine();
                string iline = iReader.ReadLine();
                string pline = pReader.ReadLine();
                string cline = cReader.ReadLine();

                        Console.WriteLine("    Name              ID                 Price               Count\n _____________________________________________________________________________");
                while (nline != null)
                {
                    if (nline.ToLower().Contains(Pro.ToLower()))
                    {
                        i++;


                        Console.WriteLine($"    {nline}               {iline}                  {pline}                  {cline}");
                    }
                    nline = nReader.ReadLine();
                    iline = iReader.ReadLine();
                    pline = pReader.ReadLine();
                    cline = cReader.ReadLine();

                }

                Console.WriteLine("_________________________________________________________________________\n\n");





                nReader.Close();
                iReader.Close();
                pReader.Close();
                cReader.Close();


                if (i == 0)
                {
                    Console.WriteLine("\n\t\tProduct not found!\n");
                }

                Console.WriteLine("\n\n Go back to menu? [yes] : ");
                string yno = Console.ReadLine();
                if (yno.ToLower() == "yes")
                {
                    Console.Clear();
                    Admin.AdminList();
                }
                else
                {
                    Console.WriteLine("\n\n\t\t\t\t have a great day!");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("\t\t There are no products at the moment! \n");
                Console.WriteLine("\n\nGo back to menu? [yes] : ");
                string yno = Console.ReadLine();
                if (yno.ToLower() == "yes")
                {
                    Console.Clear();
                    Admin.AdminList();
                }
                else
                {
                    Console.WriteLine("\n\n\t\t\t\t have a great day!");
                    Console.ReadKey();
                }

            }


        }
    


        ///////////////////////////////////////////
        ///
        public void DisplayProducts()
        {
            if (File.Exists("ndata.txt") == false)
            {
                Console.WriteLine("There are no products!");
                Console.Write("\n\nDo yo wnat to go back to menu? [yes] : ");
                string yn = Console.ReadLine();
                if (yn.ToLower() == "yes")
                {
                    Console.Clear();
                    Admin.AdminList();

                }
                else
                {
                    Console.WriteLine("\n\n\n\t\t\t\t\t OK, Have a good day!\n\n\n");
                    Console.ReadKey();
                }
            }
            else
            {
                 StreamReader nReader = new StreamReader("ndata.txt");
                StreamReader iReader = new StreamReader("idata.txt");
                StreamReader pReader = new StreamReader("pdata.txt");
                StreamReader cReader = new StreamReader("cdata.txt");

                Console.WriteLine("\n\t\t\t < Existing Products >\n");



                Console.WriteLine("    Name              ID                 Price               Count\n __________________________________________________________________________");

                string ndata = nReader.ReadLine();
                string idata = iReader.ReadLine();
                string pdata = pReader.ReadLine();
                string cdata = cReader.ReadLine();


                while (ndata != null)
                {
                    Console.WriteLine($"    {ndata}               {idata}                  {pdata}                  {cdata}");
                     ndata = nReader.ReadLine();
                     idata = iReader.ReadLine();
                     pdata = pReader.ReadLine();
                     cdata = cReader.ReadLine();


                }

                Console.WriteLine("_________________________________________________________________________\n\n");
                nReader.Close();
                iReader.Close();
                pReader.Close();
                cReader.Close();


                    Console.Write(" Go back to menu? [yes] : ");
                string yn = Console.ReadLine();
                if(yn.ToLower() == "yes")
                {
                    Console.Clear();
                    Admin.AdminList();

                }
                else
                {
                    Console.WriteLine("\n\n\n\t\t\t\t\t OK, Have a good day!\n\n\n");
                    Console.ReadKey();
                }

            }

        }

    }
}
