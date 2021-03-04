using System;
using System.Collections.Generic;

namespace OCP_Library
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public static List<Person> GeneratePersons()
        {
            var peoplelist = new List<Person>()
           {
               new Person { FirstName = "bob", LastName = "al"},
               new Person { FirstName = "bert", LastName = "filial"},
               new Person { FirstName = "beata", LastName = "sjal"}
           };

            return peoplelist;
        }
    }
    
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}