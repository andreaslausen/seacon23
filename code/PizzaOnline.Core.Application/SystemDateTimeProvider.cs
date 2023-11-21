using System;
using PizzaOnline.Core.Application.Contracts.Adapters;

namespace PizzaOnline.Core.Application
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentDateTime => DateTime.Now;
        public DateTime CurrentDate => DateTime.Today;
    }
}