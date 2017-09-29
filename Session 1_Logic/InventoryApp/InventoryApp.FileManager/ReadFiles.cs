using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.FileManager
{
    public static class ReadFiles
    {
        public static string[] ListInventory()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Inventory.txt");
            return lines;
        }
        
        public static string[][] GetAllItems()
        {
            string[] Inv = ListInventory();
            string[][] FinalInv = new string[Inv.Length][];

            for (int i = 0; i < Inv.Length; i++)
            {
                string text = Inv[i];
                string[] separators = {" - "};
                FinalInv[i] = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }

            return FinalInv;

        }

        public static string InvoiceReport()
        {
            string Output = "";
            string[] fileEntries = Directory.GetFiles(@"Invoices\");

            int GrandTotal = 0;
            string[] separators = {"$","\\","."};

            foreach (string fileName in fileEntries)
            {

                string[] Inv = System.IO.File.ReadAllLines(fileName);
                string[] Total = Inv[Inv.Length-1].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string[] GetID = fileName.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Output = Output + "Invoice: " + GetID[1] + "\t| Total: $" + Total[1] + "\r\n";
                int Result = 0;
                Int32.TryParse(Total[1], out Result);
                GrandTotal += Result;
            }

            Output = Output + "---------------------------\r\n" + "Invoices Total: $" + GrandTotal + "\r\n";

            return Output;
        }

    }
}
