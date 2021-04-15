using System;

namespace LSP
{
    /*
     * Liskov substitution principle
     * 
     *  Definition: "If S is a subtype T, then object of type T should be able to be 
     *  replaced with an object of type S without breaking the program.
     *  
     *  First version you can't replace Employee with CEO without getting exceptions.
     *  "A child type like manager or CEO should be able to replace each other"
     *  
     *  Covariance - talks about the return type - the return type shouldn't change (doesn't work with the language anyways)
     *  Contra-variance - talks about input type (doesn't really work either, maybe with interfaces)
     *  preconditions - you can not strengthen them in subtypes/children (add exceptions) rank > 0
     *  postconditions - you can not weaken post-conditions in child.
     *  
     *  You can not return new exceptions!
     *  
     *  You can't make radical changes, bottom line.
     *  We need to have a correct view of inheritance, lean towards interfaces!
     *  
     *  The problem with inheritance you can't be tripped out.
     *  Inheritance requires "Is a..." relation!
     *  
     *  A manager is an employee!
     *  A CEO is not an employee per method definition AssignManager();
     *  
     *  LSP flashlight on inheritance, is this true inheritance?
     *  
     *  Do not inherit unshared variables and methods!
     *  OCP - employee:
     *        want other classes to inherit to get same code base.
     *        have to make parent methods virtual in the beginning to not violate OCP
     *        - You have to know what methods you want to override - where you should write virtual
     *        - Violate OCP - going in and changing base class
     *        
     *  Inheritance has many limitations, you should be sure about the "Is a..." relation.
     *  
     *  Children works everywhere.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Manager accountingVP = new Manager();

            accountingVP.FirstName = "Emma";
            accountingVP.LastName = "Stone";
            accountingVP.CalculatePerHourRate(4);

            BaseEmployee emp = new Employee();

            emp.FirstName = "Tim";
            emp.LastName = "Corey";
            //emp.AssignManager(accountingVP);
            emp.CalculatePerHourRate(2);

            Console.WriteLine($"{emp.FirstName}'s salary is ${emp.Salary}/hour.");
            Console.ReadLine();
        }
    }
}
