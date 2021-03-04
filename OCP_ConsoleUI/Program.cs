using System;
using System.Collections.Generic;

namespace OCP_ConsoleUI
{
    /*
     * Open closed principle
     *      open for extension
     *      closed for modification
     *          We don't change the stuff that is in production!
     *          If a new scenario comes along we shouldn't need to change current code but extend it
     *          Scenario - somethings that is running in production
     *          Boss - actually we need to change the system
     *              1. we need a manager
     *              2. we need executive
     *              3. more example new person technician
     *     Rethink the system - how to make it more flexible from start
     *              What did we change?
     *                      All classes... thats a lot for a system that is already working!
     *                      From simple to messy with 2-3 changes
     */
    class Program
    {
        static void Main(string[] args)
        {

            var applicants = new List<PeronModel>()
           {
               new PeronModel { FirstName = "bob", LastName = "al"},
               new PeronModel { FirstName = "bert", LastName = "filial"},
               new PeronModel { FirstName = "beata", LastName = "sjal"}
           };

            var employees = new List<EmployeeModel>();
            var accountProcessor = new Accounts();

            foreach (var a in applicants)
                employees.Add(accountProcessor.Create(a));

            foreach (var e in employees)
                Console.WriteLine(
                    $"{e.FirstName} {e.LastName}: {e.EmailAddress}");

            Console.ReadLine();
        }

        public class Accounts
        {
            public EmployeeModel Create(PeronModel person)
            {
                var output = new EmployeeModel();

                output.FirstName = person.FirstName;
                output.LastName = person.LastName;
                output.EmailAddress = $"{person.FirstName.Substring(0, 1)}.{person.LastName}@rax.com";

//Commenting out if-statements and adding switch changes functioning code, introduces bugs, and we forget to implement it
//Endangering what we have already done - if it works - don't modify it in ways that introduces bugs.

                return output;
            }
        }
        public class PeronModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class EmployeeModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }

            //adds this to get manager, this is dependent on the face of the project
            //This is okay because it doesn't break any tests
            //If not okay to edit the class add an Interface IManager with extra property.
        }
    }
}
