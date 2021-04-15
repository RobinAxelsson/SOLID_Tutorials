using System;

namespace DIP_ConsoleUI
{
    class Program
    {
        /*
        * DI-states that high level modules should not depend on low level modules.
        * Should not depend on details. Use Factory. In first version Program depends on Person and Chore.
        * The Chore is also high level because it depends on the Logger and the e-mailer class.
        * Logger and e-mailer doesn't depend on anyone.
        * Bottom line: if we change out logger or e-mailer it will break chore AND program.cs.
        * 
        * Program
        * Person   Chore
        *              Logger
        *              e-mailer
        *version one ends at
        *
        *Dependency inversion vs dependency injection(encourage dependency injection)
        *new makes dependency
        *somewhere you have to new up!
        *      centralize it!
        *      one class in console UI?
         *
         *              https://youtu.be/NnZZMkwI6KI?t=463
         *              
         *      You can swap out a interface and it works directly, you don't have to change everywhere
         *      Your application is a bunch of little parts, with no dependency's.
         *      You are now setup for dependency injection.
         *      
         *      DEPENDS ON INTERFACES!
         *      UNIT TEST SIMPLE!
         *      If new "e-mailer" and new logger is tightly coupled its hard to test the method.
         *      Now we can create test classes that doesn't send emails with the test.
         *      You don't have to do it manually it can be done by moqing. A interface that pretends to work so 
         *      we can test the other.
         *      "If you see new somewhere you have tight coupling"
         *      
         *      - we don't have new anywhere in the code
         *      - program.cs does not depend on chore or person
         *      - the chore doesn't depend on the chore or e-mailer
         *      
         *      Your applications will always need to be upgraded!
         */
        static void Main(string[] args)
        {
            IPerson owner = Factory.CreatePerson();

            owner.FirstName = "Bob";
            owner.LastName = "Man";
            owner.EmailAddress = "bob.man@raxcorp.com";
            owner.PhoneNumber = "123456";

            IChore chore = Factory.CreateChore();
            chore.ChoreName = "Take out the trash";
            chore.Owner = owner;

            chore.PerformedWork(3);
            chore.PerformedWork(1.5);
            chore.CompleteChore();

            Console.ReadLine();
        }
    }
}