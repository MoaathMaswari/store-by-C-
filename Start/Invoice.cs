using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Start
{
     abstract class Invoice
    {
        static protected int InvoiceId { get; set; } 

        static protected void GetInvoiceID()
        {
            if (File.Exists("id.txt") == false)
            {
                StreamWriter writerID = new StreamWriter("id.txt");
                writerID.WriteLine(2);
                InvoiceId = 1;
                writerID.Close();

            }
            else { 

            StreamReader readID = new StreamReader("Id.txt");
            int ID = Convert.ToInt32(readID.ReadLine());
            InvoiceId = ID;
            ID++;
            readID.Close();

            StreamWriter writerID = new StreamWriter("id.txt");

            writerID.WriteLine(ID);
            writerID.Close();
        }
        }

        public abstract void GetInvoice(List<string> names, List<string> counts, List<string> cost);
    }
}
