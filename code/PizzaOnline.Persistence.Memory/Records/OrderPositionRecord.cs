using System;

namespace PizzaOnline.Persistence.Memory.Records
{
    public class OrderPositionRecord
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int Count { get; set; }
        public Guid PizzaId { get; set; }
    }
}