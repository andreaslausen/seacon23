using System;

namespace PizzaOnline.Persistence.Memory.Records
{
    public class CustomerRecord
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; }
        public string Address { get; }
        public string Mail { get; }
    }
}