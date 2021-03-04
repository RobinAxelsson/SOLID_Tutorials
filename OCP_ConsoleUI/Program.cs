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
     *     
     *     First to implement OCP: Do NOT tie yourself to classes (more in D in solid)
     *          Instead use interfaces!
     *          Dont change names halfway down the road
     *          Inteface = contract
     *          DRY - dont repeat yourself
     *          
     * Tutorial: https://youtu.be/VFlk43QGEgc?t=1966
     */

    class Program
    {
        static void Main(string[] args)
        {

            var applicants = new List<IApplicantModel>()
           {
               new PersonModel { FirstName = "bob", LastName = "al"},
               new PersonModel { FirstName = "bert", LastName = "filial"},
               new PersonModel { FirstName = "beata", LastName = "sjal", IsManager = true}
           };

            var employees = new List<EmployeeModel>();

            foreach (var a in applicants)
                employees.Add(a.AccountProcessor.Create(a));

            foreach (var e in employees)
                Console.WriteLine(
                    $"{e.FirstName} {e.LastName}: {e.EmailAddress}");

            Console.ReadLine();
        }

        public interface IAccounts
        {
            EmployeeModel Create(IApplicantModel person);
        }

        public class Accounts : IAccounts
        {
            public EmployeeModel Create(IApplicantModel person)
            {
                var output = new EmployeeModel();

                output.FirstName = person.FirstName;
                output.LastName = person.LastName;
                output.EmailAddress = $"{person.FirstName.Substring(0, 1)}.{person.LastName}@rax.com IsManager: {person.IsManager}"; //this is against DRY so maybe do something here its same as in the other interface

                
                //Commenting out if-statements and adding switch changes functioning code, introduces bugs, and we forget to implement it
                //Endangering what we have already done - if it works - don't modify it in ways that introduces bugs.

                return output;
            }
        }

        public class ManagerAccounts : IAccounts
        {
            public EmployeeModel Create(IApplicantModel person)
            {
                var output = new EmployeeModel();

                output.FirstName = person.FirstName;
                output.LastName = person.LastName;
                output.EmailAddress = $"{person.FirstName.Substring(0, 1)}.{person.LastName}@rax.com IsManager: {person.IsManager}";

                return output;
            }
        }

        public class PersonModel : IApplicantModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsManager { get; set; }
            public IAccounts AccountProcessor { get; set; } = new Accounts();

        }
        public class ManagerModel : IApplicantModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsManager { get; set; }
            public IAccounts AccountProcessor { get; set; }
        }

        public interface IApplicantModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsManager { get; set; }
            public IAccounts AccountProcessor { get; set; }
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
