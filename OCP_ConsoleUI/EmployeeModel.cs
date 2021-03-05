using System;
using System.Collections.Generic;
using System.Text;

namespace OCP_ConsoleUI
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsManager { get; set; } = false;

        public bool IsExecutive { get; set; } = false;

        //adds this to get manager, this is dependent on the face of the project
        //This is okay because it doesn't break any tests
        //If not okay to edit the class add an Interface IManager with extra property.
    }
}
