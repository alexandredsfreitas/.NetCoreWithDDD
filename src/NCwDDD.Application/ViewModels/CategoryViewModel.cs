using System;
using NCwDDD.Domain.Models;

namespace NCwDDD.Application.ViewModels
{
	public class CategoryViewModel
	{
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }

        public ProductViewModel Product { get; set; }
    }

}

