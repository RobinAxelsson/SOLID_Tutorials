using System;
using System.Collections.Generic;
using System.Text;

namespace DIP_ConsoleUI
{
    public class Texter : IMessageSender
    {
        public void SendMessage(IPerson person, string message) => Console.WriteLine($"I am texting {person.FirstName} {person.LastName}: {message}");
    }
}
