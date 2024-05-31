using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Start
{
    class Customer : Invoice
    {
        static public string BuyProduct { get; set; }
        static public void buy()
        {

            List<string> names = new List<string>();
            List<string> cout = new List<string>();
            List<string> cost = new List<string>();

        buyAgain:
            if (File.Exists("ndata.txt") == true)
            {

                Console.Clear();
                ///////////


                StreamReader n2Reader = new StreamReader("ndata.txt");
                    StreamReader p2Reader = new StreamReader("pdata.txt");
                    StreamReader c2Reader = new StreamReader("cdata.txt");

                    Console.WriteLine("\t\t\t< Existing Products > \n");

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
                
                    /////////

                    Console.Write("\t\t\t\t\tWelcom cusomer\n\n What Product do you what to buy : ");
                    BuyProduct = Console.ReadLine();


                    StreamReader nReader = new StreamReader("ndata.txt");
                    StreamReader pReader = new StreamReader("pdata.txt");
                    StreamReader cReader = new StreamReader("cdata.txt");

                    string name = nReader.ReadLine();
                    string price = pReader.ReadLine();
                    int count = Convert.ToInt32(cReader.ReadLine());
                    int found = 0;
                    int cLeft = 0;

                    while (name != null)
                    {
                        if (BuyProduct.ToLower().Trim() == name)
                        {
                            found++;
                            
                            again:
                                Console.Write($"\n How many of {name} do you want? ");
                                int c = 0;
                                try { c = Convert.ToInt32(Console.ReadLine()); }
                                catch
                                {
                                    Console.WriteLine("\t\t\t\t Enter an integar number!");
                                    Console.Clear();
                                    goto again;
                                }
                                if (c > count)
                                {

                                    Console.WriteLine($"\t\t\t\n Sorry, We only have {count} of {name } left");
                                    goto again;
                                }

                                Console.Write($"\n It will cost you {c * Convert.ToDecimal(price)}(YR) for {c} of {name}. Continue? [yes] : ");
                                string yesno = Console.ReadLine();
                                if (yesno.ToLower() == "yes")
                                {
                                    cLeft = count - c;
                                    names.Add(BuyProduct);
                                    cout.Add($"{c }");
                                    cost.Add($"{c * Convert.ToDecimal(price)}");

                                    break;
                                }
                            else
                            {
                                goto sth;
                            }

                        }

                        name = nReader.ReadLine();
                        price = pReader.ReadLine();
                        count = Convert.ToInt32(cReader.ReadLine());
                    }

                    nReader.Close();
                    pReader.Close();
                    cReader.Close();

                    nReader = new StreamReader("ndata.txt");
                    cReader = new StreamReader("cdata.txt");
                    StreamWriter cWriter = new StreamWriter("cdata2.txt");

                    string nr = nReader.ReadLine();
                    string cr = cReader.ReadLine();

                    while (nr != null)
                    {
                        if (nr == BuyProduct.ToLower())
                        {
                            cWriter.WriteLine($"{cLeft}");
                        }
                        else
                        {
                            cWriter.WriteLine(cr);
                        }
                        cr = cReader.ReadLine();
                        nr = nReader.ReadLine();

                    }

                    nReader.Close();
                    cReader.Close();
                    cWriter.Close();
                    File.Delete("cdata.txt");
                    File.Move("cdata2.txt", "cdata.txt");

                    if (found == 0)
                    {
                        Console.WriteLine(" \n\n Sorry, We don't have such product!");
                    }
                    Console.Write("\n Do you wnat to buy something else? [yes] : ");
                    string yno = Console.ReadLine();
                    if (yno.ToLower() == "yes")
                    {
                        goto buyAgain;
                    }

                }

                if (File.Exists("ndata.txt") == false)
                {
                    Console.Clear();
                    Console.WriteLine("\n There are no products at the moment!");
                }
                if (File.Exists("ndata.txt"))
                {
                    Console.Clear();
                    Customer cus = new Customer();
                    cus.GetInvoice(names, cout, cost);
                }

                    sth:
                Console.Write("\n\n Go back? [yes] : ");
                string yeno = Console.ReadLine();
                if (yeno.ToLower() == "yes")
                {
                    Program.Start();
                }
                else
                {
                    Console.WriteLine("\t\t\t Have a nice day!");
                    Console.ReadKey();
                }




            }
        

        public override void GetInvoice(List<string> names,List<string> counts, List<string> cost )
        {
            StreamWriter Owriter = File.AppendText("seals.txt");
            Invoice.GetInvoiceID();
            Console.WriteLine("\n_________________ INVOICE _______________________");
            Console.WriteLine($"\n_______________ Invoice ID {Invoice.InvoiceId} __________________\n\n");
            Console.WriteLine(" Product    Count     Cost ");
            Console.WriteLine("_____________________________");
            for (int i = 0 ; i< names.Count; i++)
            {
                Owriter.WriteLine($" {names[i]}             {Invoice.InvoiceId}              {counts[i]}           {cost[i]}(YR)          {DateTime.Now}");

                Console.WriteLine($" {names[i]}        {counts[i]}       {cost[i]}(YR) \n");
            }
            Owriter.Close();

            decimal TotalCost = 0;
            for (int i = 0; i<cost.Count; i++)
            {
                TotalCost += Convert.ToDecimal(cost[i]) ;
            }


            Console.WriteLine("_______________________________________________");
            Console.WriteLine($"Total Cost = {TotalCost} YR");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine($"date : {DateTime.Now}");
            Console.WriteLine("_______________________________________________");

        }

    }
}
