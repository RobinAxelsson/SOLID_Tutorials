namespace LSP
{
    public class Employee : BaseEmployee, IManaged
    {
        public IEmployee Manager { get; set; }
        public void AssignManager(IEmployee manager)
        {
            //simulate doing tasks here
            //otherwise property set-statement
            Manager = manager;
        }
    }
}
