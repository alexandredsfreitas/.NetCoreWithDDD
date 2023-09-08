using System;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}

