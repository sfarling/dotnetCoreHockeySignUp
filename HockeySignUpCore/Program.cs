using System;
using System.IO;

namespace HockeySignUpCore
{
    class Program
    {
        static void Main(string[] args)
        {
            String firstName = args[0];
            String lastName = args[1];
            String email = args[2];


            DateTimeDay h = new DateTimeDay();
            //Get the signup date day of week and ID
            String signupDate = h.GetDate();
            String signupDay = h.GetDay();
            String signUpId = h.GetId(signupDay);

            //Exit if incorrect day
            if (signUpId == "Not Found")
            {
                File.WriteAllText("result.txt", signupDay + " Incorrect day to sign up for");
                System.Environment.Exit(0);
            }

            //Build the form URI
            String URI = "https://bouldervalley.consoria.com/" + signupDate + "/reserve/" + signUpId;

            //Sign up
            SignUp s1 = new SignUp();
            s1.signup(URI, firstName, lastName, email);
        }
    }
}
