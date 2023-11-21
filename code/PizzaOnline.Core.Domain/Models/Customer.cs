using System;

namespace PizzaOnline.Core.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; }
        public int Number { get; }
        public string Name { get; }
        public string Address { get; }
        public string Mail { get; }

        public Customer(Guid id, int number, string name, string address, string mail)
        {
            Id = id;
            Number = number;
            Name = name;
            Address = address;
            Mail = mail;
        }
    }
}