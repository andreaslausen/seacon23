using System;

namespace PizzaOnline.Persistence.Memory.Records
{
    public class OrderRecord
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime OrderTimeStamp { get; set; }
    }
}