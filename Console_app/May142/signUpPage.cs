using System;
using System.IO;
using static System.Console;
using UserClass;
using File_IO_Methods;



namespace UserSignUp
{

    class UserSignUp : Mymethod//To read from user database file for duplicate comparison
    {


        public static void SignUp()
        {
            // define 2D array and file to check for duplicates
            string[,] credentials = null;
            const string DATA_FILE = "DataBase.txt";
            fileToArray(DATA_FILE, ref credentials);


            //Defining File attributes           
            const String DataFile = "DataBase.txt";

            // To define User 
            UsersClass User = new UsersClass();

            // To creat a list for the User
            var Userarr = new string[] { };


            // To get User info
            WriteLine("***Welcome to Ticket Purchasing***");

            User.FirstName = Ask("PLease enter your First name: ");

            User.LastName = Ask("Please enter your Last name: ");

            User.Email = Ask("Please enter your email: ");
            // to check for duplicates
            for (int i = 0; i < credentials.GetLength(0); i++)
            {
                while (User.Email.ToUpper() == credentials[i, 0].ToUpper())
                {
                    WriteLine("Email Already exists, enter a new email");
                    User.Email = ReadLine();
                }


            }

            User.UserName = Ask("Enter a username: ");
            // to check for duplicates
            for (int i = 0; i < credentials.GetLength(0); i++)
            {
                if (User.UserName.ToUpper() == credentials[i, 1].ToUpper())
                {
                    WriteLine("Username Already exists, please choose another username");
                    User.UserName = ReadLine();
                }

            }

            User.Password = Ask("Enter a password (At least 8 characters):");

            // To count number of Users
            User.Count++;

            // To add User info to a Array
            for (int i = 0; i < Userarr.Length; i++)
            {
                Userarr[i] = Convert.ToString(User);
            }

            // To Create a file for User with time and .txt extention

            //FileTime = CurrentTime.ToString("MM/dd/yyyy HH:mm:ss");



            // To create a Database txt file with Username, Email and Password 
            using (StreamWriter writerDB = File.AppendText(DataFile))
            {
                writerDB.Write(User.Count + " " + User.Email.ToUpper() + "," + User.UserName.ToUpper() + "," + User.Password + "\n");
                writerDB.Close();

            }

            WriteLine("\nCongradulations! your account was created successfully.");

        }

        // Ask method for userInfo inputs
        static string Ask(string question)
        {
            string Ans;

            WriteLine(question);
            Ans = ReadLine().Trim();

            while (Ans == "")
            {
                WriteLine("you didn't type anything,");
                WriteLine(question);
                Ans = ReadLine().Trim();
            }

            return Ans;
        }


    }
}



