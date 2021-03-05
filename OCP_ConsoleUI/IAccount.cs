using System;
using System.Collections.Generic;
using System.Text;

namespace OCP_ConsoleUI
{
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
            output.EmailAddress = $"{person.FirstName.Substring(0, 1)}.{person.LastName}@rax.com";
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
            output.EmailAddress = $"{person.FirstName.Substring(0, 1)}.{person.LastName}@rax.com";
            output.IsManager = true;

            return output;
        }
    }
    public class ExecutiveAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            var output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{person.FirstName.Substring(0, 1)}.{person.LastName}@rax.com";

            output.IsManager = true;
            output.IsExecutive = true;

            return output;
        }
    }
}
