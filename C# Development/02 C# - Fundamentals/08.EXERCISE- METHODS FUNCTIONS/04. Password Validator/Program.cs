using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {

            Validation(Console.ReadLine());
        }

        static void Validation(string password)
        {
            string validation = ValidatePassBetweenSixAndTenCharacters(password);
            //asdasdas!
            if (validation != null)
            {
                Console.WriteLine(validation);
            }

            string validation2 = ValidateContainsOnlyDigitsAndLetters(password);

            if (validation2 != null)
            {
                Console.WriteLine(validation2);
            }
            string validationThree = ValidateHasAtleastTwoDigits(password);

            if (validationThree != null)
            {
                Console.WriteLine(validationThree);
            }
            if (validation == null && validation2 == null && validationThree == null)
            {
                Console.WriteLine("Password is valid");
            }



        }       //Check if 1,2,3 are correct
        //
        static string ValidatePassBetweenSixAndTenCharacters(string password)
        {
            int length = password.Length;
            string res = null;
            if (length < 6 || length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            return res;
        }  //1
        //
        static string ValidateContainsOnlyDigitsAndLetters(string password)
        {
            string result = null;
            for (int i = 0; i < password.Length; i++)
            {
                if (!(char.IsLetterOrDigit(password[i])))
                {
                    result = "Password must consist only of letters and digits";
                    break;
                }
            }
            return result;
        }  //2
        //

        static string ValidateHasAtleastTwoDigits(string password)
        {
            int COUNTER = 0;
            string res = null;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    COUNTER++;
                }

                if (COUNTER == 2)
                {
                    
                    break;
                }
            }

            if (COUNTER>=2)
            {
                res = "Password must have at least 2 digits";
            }
            return res;
        }  //3

    }
}
