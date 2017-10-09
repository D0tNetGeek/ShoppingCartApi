using Domain.Core.ExternalModules.Contracts;
using NLog;

namespace Domain.Core.ExternalModules.Concrete
{
    public class DefaultCourierSender : ICourierSender
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void Send(string to, string message)
        {
            _logger.Info($"Message has been successfully sent to {to}");
        }
    }
}