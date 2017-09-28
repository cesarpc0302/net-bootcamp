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
        

    }
}
