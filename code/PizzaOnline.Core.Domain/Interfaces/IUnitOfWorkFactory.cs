using System;

namespace PizzaOnline.Core.Domain.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }

    internal class TestUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }
}