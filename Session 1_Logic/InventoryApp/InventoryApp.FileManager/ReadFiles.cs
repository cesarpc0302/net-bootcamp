using System;
using System.Collections.Generic;
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

    }
}
