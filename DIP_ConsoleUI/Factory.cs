using System;
using System.Collections.Generic;
using System.Text;

namespace DIP_ConsoleUI
{
    public static class Factory
    {
        public static IPerson CreatePerson() => new Person();
        public static IChore CreateChore() => new Chore(CreateLogger(), CreateMessageSender());
        public static IMessageSender CreateMessageSender() => new Texter();
        public static ILogger CreateLogger() => new Logger();
    }
}
