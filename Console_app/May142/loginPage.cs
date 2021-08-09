using System;
using static System.Console;
using System.IO;
using UserSignUp;


namespace UserInterface
{
    class UserLogin : UserSignUp.UserSignUp
    {
        public static void Main(string[] args)
        {
            // Define the 2 file names for products and user info
            const string PROD_FILE = "ProdFile.txt";
            const string DATA_FILE = "DataBase.txt";

            DateTime logTime = DateTime.Now;
            string fileName = null;
            DateTime currentTime;
            string FileTime = null;




            //to define variables to check credentials and quantity of each purchase
            bool check = false; // checks if credentials correct and returns true
            string checkContinue = null; //boolean that returns false if user chooses not to continue
            double Total = 0; // Holds total purchased price
            int Quantity = 0; // Hold quantity of each item purchased
            string Selection = null; // Holds and checks selected item against array field of items
            string usernameCheck = null; // Holds username input and checks it against array field of usernames
            string passwordCheck = null; // Holds password input and checks it against array field of passwords
            string[,] credentials = null; // Holds Email/ Password/ Username
            string[,] products = null; // Holds product/ Price
            int i = 0; // integer i used in For loops
            int AccProtec = 0; // checks for number of password attempts inside while loop and accumulates each time
            string allItems = null; // holds all the items purchased to put into log file at the end

            bool signUp = false;
            // Method to put file data into a 2D array
            fileToArray(DATA_FILE, ref credentials);


            // Prompt user for username and check against the field of username inside array
            WriteLine("Please enter your Username or signup(S): ");
            usernameCheck = ReadLine();

            if (usernameCheck.ToUpper() == "S") //Takes to sign up page
            {
                SignUp();
                signUp = true;
                WriteLine("\n Thank you for signing up, please reopen the app to sign in");

            }

            for (i = 0; i < credentials.GetLength(0); i++) //Goes through columns of 2D array
            {
                if (usernameCheck.ToUpper() == credentials[i, 1]) //Check for username
                {
                    WriteLine("Please Enter your Password");
                    passwordCheck = ReadLine();

                    while (passwordCheck != credentials[i, 2] && AccProtec < 4) // if password is incorrect
                    {
                        WriteLine("Wrong password");
                        passwordCheck = ReadLine();
                        AccProtec++; // to limit password input tries
                    }

                    if (passwordCheck == credentials[i, 2]) // if password is correct
                    {
                        check = true;
                        break;
                    }
                    WriteLine("Total attempt limit exeeded");

                }

            }






            if (check == false && signUp == false)
            {
                WriteLine("\n Username doesn't exist, type 'S': Sign up or any key to exit");
                checkContinue = ReadLine().ToUpper();
                if (checkContinue == "S")
                {
                    SignUp();
                }

                else
                {
                    WriteLine("hava a nice day!");
                }
            }








            // Start the purchasing app
            while (check)
            {


                try
                {
                    int prodRows = fileToArray(PROD_FILE, ref products);// To put product file into 2D array with Product and price

                    int price = 0;
                    string item = null; // products of the product file "ProdFile"


                    // write all contents of array 
                    for (i = 0; i < products.GetLength(0); i++)
                    {
                        item = products[i, 0];
                        price = int.Parse(products[i, 1]);
                        WriteLine("{0} is {1}$", item, price);

                    }

                    WriteLine("\nPlease make your selection from the menu (write the name): ");
                    Selection = ReadLine();

                    for (i = 0; i < products.GetLength(0); i++)
                    {


                        //to check if item exists 
                        if (Selection.ToUpper() == products[i, 0].ToUpper())
                        {
                            price = int.Parse(products[i, 1]);

                            WriteLine("\n{0} is {1}$", Selection, price);


                            WriteLine("\nHow many {0}s would you like to purchase? ", Selection);
                            Int32.TryParse(ReadLine(), out Quantity);


                            allItems += Selection + ",";
                            Total += Quantity * price;
                            WriteLine("\nSo far your total is {0}$", Total);
                            break;
                        }



                        //WriteLine("item doesn't exist, please make a slelection from the menu");
                        //Selection = ReadLine();



                    }


                    // check for continue shopping
                    WriteLine("Would you like to continue shopping? (Y/N)");
                    checkContinue = ReadLine().ToUpper();

                    if (checkContinue == "N")
                    {

                        WriteLine("\nYour total is: {0}$", Total);


                        currentTime = DateTime.Now; // To Get current time
                        FileTime = currentTime.ToString("yyyyMMdd_HHmmss");//To write current time in a string

                        // To make a reciept for the customer
                        fileName = "Reciept_" + usernameCheck + "_" + FileTime + ".txt";

                        FileStream recieptFileWrite =
                            new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        StreamWriter Writer = new StreamWriter(recieptFileWrite);

                        Writer.WriteLine(ToFile());
                        Writer.Close();
                        recieptFileWrite.Close();

                        // to write records to the log file
                        using (StreamWriter writeToLog = File.AppendText("Log.txt"))
                        {
                            writeToLog.WriteLine(ToFile());
                            writeToLog.Close();
                        }

                        check = false;

                        break;
                    }
                }

                catch
                {
                    WriteLine("Wrong input please try again");
                }


            }




            //method to put user info into a string
            string ToFile()
            {


                String s = ""; // to right user info into an array to put in reciept and log files
                s += "\nNew Login: \nDate: " + logTime.ToString("yyyyMMdd_HHmmss\n");
                s += "Username: " + usernameCheck + "\n";
                s += "Purchase item: " + allItems + "\n";
                s += "Purchase total: " + Total + "\n";
                return s;
            }
        }

    }
}