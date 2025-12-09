
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Domain.Events
{
    public static class JobInformation
    {
        private static readonly Dictionary<string, Type> _indexedJobs = new()
        {
            { typeof(PlaidBankAccountSyncJobCreated).Name, typeof(PlaidBankAccountSyncJobCreated) },
        };

        public static bool IsJob(this IDomainEvent domainEvent)
        {
            return _indexedJobs.ContainsKey(domainEvent.GetType().Name);
        }
    }
}
