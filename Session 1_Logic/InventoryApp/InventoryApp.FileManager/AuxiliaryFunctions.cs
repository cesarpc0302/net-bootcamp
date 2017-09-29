using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.FileManager
{
    public static class AuxiliaryFunctions
    {
        public static bool CheckID(string ID, string Value)
        {
            if (Int32.Parse(ID) == Int32.Parse(Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckQuantities(string Actual, string Rest)
        {
            if (Int32.Parse(Actual) + Int32.Parse(Rest) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string[] GetDescription(string[][] Inventory, string ID)
        {
            string[] result = new string[Inventory[0].Length];
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (ID == Inventory[i][0])
                {
                    result = Inventory[i];
                }
            }
            return result;
            
        }
    }
}
