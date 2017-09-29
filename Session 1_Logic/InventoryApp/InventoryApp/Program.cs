using System;
using System.Configuration;
using InventoryApp.FileManager;

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
                Console.WriteLine("Press ENTER to exit...");
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
                    printInventory();
                    break;

                // Create a new article
                case 2:
                    CreateArticle();
                    break;

                // Modify the artile quantities
                case 3:
                    ModifyQuantity();
                    break;

                // Remove an article
                case 4:
                    RemoveArticle();
                    break;

                // Exit application
                case 5:
                    Console.Clear();
                    Console.WriteLine("Exiting... Press ENTER to continue...");
                    return;

                // Invalid input case
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option, try again...");
                    Console.WriteLine(" ");
                    break;
            }

            loadAdminMenu();

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
                    printInventory();
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
                    Console.WriteLine("Exiting... Press Enter to continue...");
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


        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // List inventory

        static void printInventory()
        {
            string[] inv = ReadFiles.ListInventory();
            Console.Clear();
            Console.WriteLine("Inventory:");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("");
            Console.WriteLine("Total Items: {0}", inv.Length);
            Console.WriteLine("");

            foreach (string line in inv)
            {
                Console.WriteLine("\t" + line);
            }

            Console.WriteLine("");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("");

            Console.WriteLine("Press ENTER to return to the main menu...");
            Console.ReadLine();
            Console.Clear();
        }


        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // Create new article

        static void CreateArticle()
        {

            Console.Clear();
            Console.WriteLine("Create new article:");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");

            Console.WriteLine("");
            Console.Write("Article ID: ");
            string ArticleID = Console.ReadLine();

            while (!Int32.TryParse(ArticleID, out int test))
            {
                Console.WriteLine("");
                Console.WriteLine("Incorrect entry, please try again... ");
                Console.WriteLine("");
                Console.Write("Article ID: ");
                ArticleID = Console.ReadLine();
            }

            Console.Write("");
            Console.Write("Article Name: ");
            string ArticleName = Console.ReadLine();

            Console.Write("");
            Console.Write("Article Cost: ");
            string ArticleCost = Console.ReadLine();

            while (!Int32.TryParse(ArticleCost, out int test))
            {
                Console.WriteLine("");
                Console.WriteLine("Incorrect entry, please try again... ");
                Console.WriteLine("");
                Console.Write("Article Cost: ");
                ArticleCost = Console.ReadLine();
            }

            Console.Write("");
            Console.Write("Article Quantity: ");
            string ArticleQuantity = Console.ReadLine();

            while (!Int32.TryParse(ArticleQuantity, out int test))
            {
                Console.WriteLine("");
                Console.WriteLine("Incorrect entry, please try again... ");
                Console.WriteLine("");
                Console.Write("Article Quantity: ");
                ArticleQuantity = Console.ReadLine();
            }

            Console.WriteLine("");
            Console.Clear();

            string Article = ArticleID + " - " + ArticleName + " - " + ArticleCost + " - " + ArticleQuantity;

            int result = WriteFiles.AddArticle(ArticleID, Article);

            if (result == 1)
            {
                Console.WriteLine("Article added succesfully!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("The ID is aready in use, please select another one");
                Console.WriteLine("");
            }
            
        }


        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // Modify article quantity

        static void ModifyQuantity()
        {
            Console.Clear();
            Console.WriteLine("Modify article quantity:");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");

            Console.WriteLine("");
            Console.Write("Article ID: ");
            string ArticleID = Console.ReadLine();

            while (!Int32.TryParse(ArticleID, out int ID))
            {
                Console.WriteLine("");
                Console.WriteLine("Incorrect entry, please try again... ");
                Console.WriteLine("");
                Console.Write("Article ID: ");
                ArticleID = Console.ReadLine();
            }

            Console.WriteLine("");
            Console.Write("Quantity to add: ");
            string ArticleQuantity = Console.ReadLine();

            while (!Int32.TryParse(ArticleQuantity, out int Quantity))
            {
                Console.WriteLine("");
                Console.WriteLine("Incorrect entry, please try again... ");
                Console.WriteLine("");
                Console.Write("Quantity to add: ");
                ArticleQuantity = Console.ReadLine();
            }

            int result = WriteFiles.ModifyQuantity(ArticleID, ArticleQuantity);

            Console.Clear();
            switch (result)
            {
                case 0:
                    Console.WriteLine("Article ID not found");
                    break;
                case 1:
                    Console.WriteLine("Article updated succesfully!");
                    break;
                case 2:
                    Console.WriteLine("Not enough product in stock to proceed with the transaction");
                    break;
                default:
                    break;
            }
            
            Console.WriteLine("");
        }


        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // Remove article

        static void RemoveArticle()
        {
            Console.Clear();
            Console.WriteLine("Remove article: ");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");
            Console.WriteLine("-- -- -- -- -- -- -- -- -- --");

            Console.WriteLine("");
            Console.Write("Article ID: ");
            string ArticleID = Console.ReadLine();

            while (!Int32.TryParse(ArticleID, out int ID))
            {
                Console.WriteLine("");
                Console.WriteLine("Incorrect entry, please try again... ");
                Console.WriteLine("");
                Console.Write("Article ID: ");
                ArticleID = Console.ReadLine();
            }
           

            int result = WriteFiles.RemoveArticle(ArticleID);

            Console.Clear();
            switch (result)
            {
                case 0:
                    Console.WriteLine("Article ID not found, nothing to remove");
                    break;
                case 1:
                    Console.WriteLine("Article removed succesfully!");
                    break;
                default:
                    break;
            }

            Console.WriteLine("");
        }
    }
}
