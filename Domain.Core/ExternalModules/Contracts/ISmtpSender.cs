namespace Domain.Core.ExternalModules.Contracts
{
    public interface ISmtpSender
    {
        void Send(string to, string message);
    }
}