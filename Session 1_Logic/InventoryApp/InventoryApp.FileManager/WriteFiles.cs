using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.FileManager
{
    public static class WriteFiles
    {

        // return 1 = todo bien
        // return 0 = ya existe el ID
        public static int AddArticle(string ID, string article)
        {
            int output = 0;
            if (CheckID(ID))
            {
                return output;
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Inventory.txt", true))
                {
                    file.WriteLine(article);
                }
                output = 1;
            }
            return output;
            
        }


        //Check if the ID already exists
        public static bool CheckID(string ID)
        {
            string[][] Inv = ReadFiles.GetAllItems();
            for (int i = 0; i < Inv.Length; i++)
            {
                if (AuxiliaryFunctions.CheckID(ID, Inv[i][0]))
                {
                    return true;
                }
            }
            return false;
        }
    


        // return 1 = todo bien
        // return 2 = no hay cantidad suficiente
        // return 0 = no existe el ID
        public static int ModifyQuantity(string ID, string quantity)
        {
            string result = "";
            int output = 0;
            string[][] Inv = ReadFiles.GetAllItems();
            for (int i = 0; i < Inv.Length; i++)
            {
                if (AuxiliaryFunctions.CheckID(ID, Inv[i][0]))
                {
                    if (AuxiliaryFunctions.CheckQuantities(Inv[i][3], quantity))
                    {
                        output = 1;
                        Inv[i][3] = (Int32.Parse(Inv[i][3]) + (Int32.Parse(quantity))).ToString();
                    }
                    else
                    {
                        output = 2;
                    }
                }
                result = result + Inv[i][0] + " - " + Inv[i][1] + " - " + Inv[i][2] + " - " + Inv[i][3];
                if (i < Inv.Length-1)
                {
                    result = result + "\r\n";
                }
            }

            System.IO.File.WriteAllText(@"Inventory.txt", result);
            return output;
        }

        // return 1 = todo bien
        // return 0 = no existe el ID
        public static int RemoveArticle(string ID)
        {
            string result = "";
            int output = 0;
            string[][] Inv = ReadFiles.GetAllItems();
            for (int i = 0; i < Inv.Length; i++)
            {
                if (AuxiliaryFunctions.CheckID(ID, Inv[i][0]))
                {
                    output = 1;
                }
                else
                {
                    result = result + Inv[i][0] + " - " + Inv[i][1] + " - " + Inv[i][2] + " - " + Inv[i][3];
                    if (i < Inv.Length - 1)
                    {
                        result = result + "\r\n";
                    }
                }
                
            }

            System.IO.File.WriteAllText(@"Inventory.txt", result);
            return output;
        }

    }
}
