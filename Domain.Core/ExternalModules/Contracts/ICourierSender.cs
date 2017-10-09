namespace Domain.Core.ExternalModules.Contracts
{
    public interface ICourierSender
    {
        void Send(string to, string message);
    }
}