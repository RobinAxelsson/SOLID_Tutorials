namespace DIP_ConsoleUI
{
    public interface IMessageSender
    {
        void SendMessage(IPerson person, string message);
    }
}