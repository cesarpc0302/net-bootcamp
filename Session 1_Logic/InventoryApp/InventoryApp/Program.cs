using System;
using System.Configuration;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Properties.Settings.Default.Bloked = false;  //for testing purposes
            // Validate if application is locked
            if (!Properties.Settings.Default.Bloked)
            {
                // If no arguments were passed login as User
                if (args.Length == 0)
                {
                    Console.WriteLine("Logged as User");
                    LoginAsUser();
                }
                // If admin was passed as argument login as admin
                else if (args[0] == "admin")
                {
                    Console.WriteLine("Logged as Admin");
                    LoginAsAdmin();
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



        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // Admin Login

        // Ask for the credentials and call checkCredentials to validate them
        // Counts the log in attempts to lock the application if exceeded 3 failed attempts 
        static void LoginAsAdmin()
        {
            int tries = 0;

            // count of the login attempts
            while (tries < 3)
            {

                //Ask for username and password
                Console.WriteLine("Login system");
                Console.Write("Enter your Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your Password: ");
                Console.ForegroundColor = ConsoleColor.Black;
                string password = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                string usr = ConfigurationManager.AppSettings["username"];
                string pass = ConfigurationManager.AppSettings["password"];

                // Call check credentials for validation
                if (username == usr && password == pass)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome {0}", username);
                    Console.WriteLine(" ");
                    loadAdminMenu();
                    break;
                }
                else
                {
                    tries++;

                    Console.Clear();
                    Console.WriteLine("Incorrect Username or Password, please try again...");
                    Console.WriteLine("Attemps remaining: {0}", 3 - tries);

                }
            }
            

            // if there are 3 failed login attempts locks the application
            if (tries == 3)
            {
                Properties.Settings.Default.Bloked = true;
                Properties.Settings.Default.Save();

                Console.Clear();
                Console.WriteLine("Login failed. You have exceeded the maximum number of attempts allowed.");
                Console.WriteLine("The application will be blocked for security, please contact your system administrator.");
                return;
            }

        }


        // Load administrator menu
        
        static void loadAdminMenu()
        {

            // Print admin menu
            Console.WriteLine("Administrator Menu");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("1.  List Inventory");
            Console.WriteLine("2.  Create new article");
            Console.WriteLine("3.  Modify article quantity");
            Console.WriteLine("4.  Remove article");
            Console.WriteLine("5.  Exit application");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.Write("Please select an option: ");
            string option = Console.ReadLine();


            // get user input and validate it 
            int opt = 0;
            Int32.TryParse(option, out opt);


            // Switch between the differents menu options
            switch (opt)
            {

                //List the inventory
                case 1:
                    Console.Clear();
                    Console.WriteLine("Inventory:");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    loadAdminMenu();
                    break;

                // Create a new article
                case 2:
                    Console.Clear();
                    Console.WriteLine("Create new article:");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    loadAdminMenu();
                    break;

                // Modify the artile quantities
                case 3:
                    Console.Clear();
                    Console.WriteLine("Modify article quantity:");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    loadAdminMenu();
                    break;

                // Remove an article
                case 4:
                    Console.Clear();
                    Console.WriteLine("Remove article:");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    loadAdminMenu();
                    break;

                // Exit application
                case 5:
                    Console.Clear();
                    Console.WriteLine("Exiting... Press any key to continue...");
                    return;

                // Invalid input case
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option, try again...");
                    Console.WriteLine(" ");
                    loadAdminMenu();
                    break;
            }
        }


        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // User Login

        // Clear the screen and call the load user menu function
        static void LoginAsUser()
        {
            Console.Clear();
            Console.WriteLine("Welcome User");
            Console.WriteLine(" ");
            loadUserMenu();

        }


        // Prints the user menu
        static void loadUserMenu()
        {

            //Print user menu

            Console.WriteLine("User Menu");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("1.  List Inventory");
            Console.WriteLine("2.  Create new invoice");
            Console.WriteLine("3.  Invoices Report");
            Console.WriteLine("4.  Exit application");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.Write("Please select an option: ");
            string option = Console.ReadLine();


            // parse the user input and validate it 
            int opt = 0;
            Int32.TryParse(option, out opt);


            // Switch beetween different options of the menu
            switch (opt)
            {

                // List the whole inventory
                case 1:
                    Console.Clear();
                    Console.WriteLine("Inventory:");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    break;

                // Create a new invoice
                case 2:
                    Console.Clear();
                    Console.WriteLine("Create new invoice:");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    break;

                // Display te invoices report
                case 3:
                    Console.Clear();
                    Console.WriteLine("Invoices report:");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
                    break;

                // Exit application
                case 4:
                    Console.Clear();
                    Console.WriteLine("Exiting... Press any key to continue...");
                    return;

                // Invalid option case
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option, try again...");
                    Console.WriteLine(" ");
                    break;
            }

            loadUserMenu(); // load user menu again 

        }
    }
}
