using System;
using static System.Console;


// Define a class for User and set rules for its properties


namespace UserClass

{

    // To define User class 
    public class UsersClass
    {


        // defining properties of user class fields 
        private string firstname; // first name of User
        private string lastname;
        private string email;
        private string username;
        private string password;

        public int Count;

        public String FirstName
        {
            get { return firstname; } // returns the value from user input
            set { firstname = value.Trim(); } // trims spaces and sets it to firstname
        }

        public String LastName
        {
            get { return lastname; }
            set { lastname = value.Trim(); }
        }
        // Email properties
        public string Email
        {
            get
            {
                return email;
            }

            set
            {

                if (!value.Contains("@") || !value.Contains("."))// checks for email format
                {
                    WriteLine("The Email Address is invalid please enter your Email: (Must contain @ and domain)");
                    Email = ReadLine();
                }




                email = value.Trim();
            }
        }
        // UserName properties
        public string UserName
        {
            get
            {
                return username;
            }

            set
            {
                username = value.Trim();
            }
        }
        // Password properties
        public String Password
        {
            get
            {
                return password;
            }

            set
            {
                if (value.Length < 8)
                {
                    WriteLine("Password is too short, choose at least 8 characters"); // checks for password length
                    Password = ReadLine();
                }
                else
                {
                    password = value.Trim();
                }
            }
        }

    }
}

