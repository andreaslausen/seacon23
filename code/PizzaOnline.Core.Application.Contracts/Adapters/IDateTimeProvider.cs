using System;

namespace PizzaOnline.Core.Application.Contracts.Adapters
{
    public interface IDateTimeProvider
    {
        DateTime CurrentDateTime { get; }
        DateTime CurrentDate { get; }
    }
}