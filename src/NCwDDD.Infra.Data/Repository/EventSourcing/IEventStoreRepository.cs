using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCwDDD.Domain.Core.Events;

namespace NCwDDD.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}

