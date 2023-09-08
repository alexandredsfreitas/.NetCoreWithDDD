using System;
using NCwDDD.Domain.Models;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Commands
{
	public class CategoryCommand : Command
	{
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public CategoryType CategoryType { get; protected set; }
    }
}

