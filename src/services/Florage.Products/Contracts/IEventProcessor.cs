namespace Florage.Products.Contracts
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
