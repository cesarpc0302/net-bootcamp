using System;
using System.Configuration;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string locked = ConfigurationManager.AppSettings["bloked"].ToString();

            // Validate if application is locked
            if (locked == "false")
            {
                // If no arguments were passed login as User
                if (args.Length == 0)
                {
                    Console.WriteLine("Logged as User");
                    //LoginAsUser();
                }
                // If admin was passed as argument login as admin
                else if (args[0] == "admin")
                {
                    Console.WriteLine("Logged as Admin");
                    //LoginAsAdmin();
                }
                // In case of invalid arguments
                else
                {
                    Console.WriteLine("Error Launching Application: Invalid Params");
                }
            }
            // In case the app is locked
            else
            {
                Console.WriteLine("The application is currently locked for security reasons.");
                Console.WriteLine("Please contact your system administrator.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }

        }
    }
}
