using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.FileManager
{
    public static class WriteFiles
    {

        public static void AddArticle(string article)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Inventory.txt", true))
            {
                file.WriteLine(article);
            }
        }

    }
}
