using System.Reflection;
using ArchUnitNET.Loader;
using CsvHelper.Configuration;
using PizzaOnline.Core.Application.Contracts.Adapters;
using PizzaOnline.Core.Application.Services;
using PizzaOnline.Core.Domain.Models;
using PizzaOnline.Persistence.Memory;

namespace PizzaOnline.Architecture.Tests
{
    public abstract class ArchitectureTest
    {
        protected static Assembly ApplicationAssembly => typeof(OrderService).Assembly;
        protected static Assembly ApplicationContractsAssembly => typeof(IDateTimeProvider).Assembly;
        protected static Assembly DomainAssembly => typeof(Pizza).Assembly;
        protected static Assembly PersistenceCsvAssembly => typeof(PizzaRepository).Assembly;
        protected static Assembly PersistenceMemoryAssembly => typeof(CustomerRepository).Assembly;

        protected static Assembly SystemAssembly => typeof(object).Assembly;
        protected static Assembly SystemLinqAssembly => typeof(System.Linq.Enumerable).Assembly;
        protected static Assembly SystemLinqExpressionsAssembly => typeof(System.Linq.Expressions.Expression).Assembly;
        protected static Assembly CsvHelperAssembly => typeof(ClassMap).Assembly;

        // Dieses Array muss erweitert werden, wenn neue Projekte hinzugefügt werden.
        private static readonly Assembly[] Assemblys =
        {
            ApplicationAssembly,
            ApplicationContractsAssembly,
            DomainAssembly,
            PersistenceCsvAssembly,
            PersistenceMemoryAssembly,
            SystemAssembly,
            SystemLinqAssembly,
            SystemLinqExpressionsAssembly,
            CsvHelperAssembly
        };

        protected static readonly ArchUnitNET.Domain.Architecture Architecture =
            new ArchLoader().LoadAssembliesIncludingDependencies(Assemblys).Build();
    }
}