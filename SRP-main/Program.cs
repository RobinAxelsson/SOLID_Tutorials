using System;

namespace SRP_main
{
    /*
     * SRP - single responsibility principle
     *
     * One change for one purpose only change in one place!
     *
     * Broken application apart in nitty pieces
     * On change you know exactly where to go (assuming good naming)
     * Folder structure with lots of classes
     * Readable main!
     * generally small mathods and small classes!
     * 
     * if navigating with F12! It doesnt mather how many files there is.
     * easier to understand smaller chunks, easier to read
     * 
     * Find the ballance
     * 
     * Rule of thumb! If you have to scroll think about it.
     * Do you change this class for more then one reason?
     * 
     */

    class Program
    {
        static void Main(string[] args) //Main is only responsible for flow
        {
            StandardMessages.WelcomeMessage();

            Person user = PersonDataCapture.Capture(); //Hard coupling (bad)

            bool isUserValid = PersonValidator.Validate(user); 

            if (isUserValid == false)
            {
                StandardMessages.EndApplication();
                return;
            }

            AccountGenerator.CreateAccount(user);

            StandardMessages.EndApplication();
        }
    }
    public class PersonValidator
    {
        public static bool Validate(Person person)
        {
            if (string.IsNullOrEmpty(person.FirstName))
            {
                StandardMessages.DisplayValidationError("first name");
                return false;
            }
            if (string.IsNullOrEmpty(person.LastName))
            {
                StandardMessages.DisplayValidationError("last name");
                return false;
            }
            return true;
        }
    }
    public class AccountGenerator //accountspecific class
    {
        public static void CreateAccount(Person user)
        {
            Console.WriteLine($"Your username is: {user.FirstName} {user.LastName}");
        }
    }
    public class PersonDataCapture
    {
        public static Person Capture() //the only reason to change this class is when changing the information to capture
        {
            Person output = new Person();

            Console.Write("enter first name: ");
            output.FirstName = Console.ReadLine();

            Console.Write("enter last name: ");
            output.LastName = Console.ReadLine();

            return output;
        }
    }
    public static class StandardMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to my application"); //This one is dependent on the Console
        }
        public static void EndApplication()
        {
            Console.ReadLine();
        }
        public static void DisplayValidationError(string fieldName)
        {
            Console.WriteLine($"you did not give a valid {fieldName}!");
        }
    }
    public class Person
    {
        public string FirstName;
        public string LastName;
    }
}
