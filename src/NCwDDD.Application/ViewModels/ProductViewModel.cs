using System;
using System.Text.Json.Serialization;
using NCwDDD.Domain.Models;

namespace NCwDDD.Application.ViewModels
{
	public class ProductViewModel
	{
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        //[JsonIgnore]
        //public Category Category { get; set; }

        public decimal Price { get; set; }

        public int StoredQuantity { get; set; }

        [JsonIgnore]
        public DateTime RegistrationDate { get; set; }
    }
}

