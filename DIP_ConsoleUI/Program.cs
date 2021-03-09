using System;

namespace DIP_ConsoleUI
{
    class Program
    {
        /*
         * DI-states that high level modules should not depend on low level modules.
         * Should not depend on details. Use Factory. In first version Program depends on Person and Chore.
         * The Chore is also high level because it depends on the Logger and the Emailer class.
         * Logger and emailer doesn't depend on anyone.
         * Bottom line: if we change out logger or emailer it will break chore AND program.cs.
         * 
         * Program
         * Person   Chore
         *              Logger
         *              Emailer
         *version one ends at
         *              https://youtu.be/NnZZMkwI6KI?t=463
         */
        static void Main(string[] args)
        {
            var owner = new Person
            {
                FirstName = "Bob",
                LastName = "Man",
                EmailAddress = "bob.man@raxcorp.com",
                PhoneNumber = "123456"
            };

            var chore = new Chore
            {
                ChoreName = "Take out the trash",
                Owner = owner
            };

            chore.PerformedWork(3);
            chore.PerformedWork(1.5);
            chore.CompleteChore();

            Console.ReadLine();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class Chore
    {
        public string ChoreName { get; set; }
        public Person Owner { get; set; }
        public double HoursWorked { get; private set; }
        public bool IsComplete { get; private set; }
        public void PerformedWork(double hours)
        {
            HoursWorked += hours;
            Logger log = new Logger();
            log.Log($"Performed work on {ChoreName}");
        }
        public void CompleteChore()
        {
            IsComplete = true;
            Logger log = new Logger();
            log.Log($"Completed {ChoreName}");

            Emailer emailer = new Emailer();
            emailer.SendEmail(Owner, $"The chore {ChoreName} is complete.");
        }
    }
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Write to Console: {message}");
        }
    }
    public class Emailer
    {
        public void SendEmail(Person person, string message)
        {
            Console.WriteLine($"Simulating sending an email to {person.EmailAddress}");
        }
    }
}