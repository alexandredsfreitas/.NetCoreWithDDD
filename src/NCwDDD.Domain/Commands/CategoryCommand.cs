using System;
using NCwDDD.Domain.Models;

namespace NCwDDD.Domain.Commands
{
	public class CategoryCommand
	{
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public CategoryType CategoryType { get; protected set; }
    }
}

