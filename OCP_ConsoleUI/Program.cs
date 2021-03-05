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
     *          Don't change names halfway down the road
     *          Interface = contract
     *          DRY - don't repeat yourself
     *          
     * Tutorial: https://youtu.be/VFlk43QGEgc?t=1966
     * 
     * Interfaces allow us to change the implementation.
     */

    class Program
    {
        static void Main(string[] args)
        {

            var applicants = new List<IApplicantModel>()
           {
               new PersonModel { FirstName = "bob", LastName = "al"},
               new ExecutiveModel { FirstName = "bert", LastName = "filial"},
               new ManagerModel { FirstName = "beata", LastName = "sjal"}
           };

            var employees = new List<EmployeeModel>();

            foreach (var a in applicants)
                employees.Add(a.AccountProcessor.Create(a));

            foreach (var e in employees)
                Console.WriteLine(
                    $"{e.FirstName} {e.LastName}: {e.EmailAddress} IsManager: {e.IsManager} IsExecutive; {e.IsExecutive}");

            Console.ReadLine();
        }
    }
}
