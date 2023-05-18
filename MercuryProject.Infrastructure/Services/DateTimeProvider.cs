using MercuryProject.Application.Common.Interfaces.Services;

namespace MercuryProject.Infrastructure.Services
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
