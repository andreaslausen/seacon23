using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace PizzaOnline.Architecture.Tests;

public class DependencyRules : ArchitectureTest
{
    [Fact]
    public void ApplicationShouldOnlyDependOnDomain()
    {
        var typesInApplication = Types().That().ResideInAssembly(ApplicationAssembly);

        var rule = Types().That().Are(typesInApplication).Should()
            .OnlyDependOn(Types().That()
                .ResideInAssembly(DomainAssembly).Or()
                .ResideInAssembly(ApplicationAssembly).Or()
                .ResideInAssembly(ApplicationContractsAssembly).Or()
                .ResideInAssembly(SystemAssembly).Or()
                .ResideInAssembly(SystemLinqAssembly));

        rule.Check(Architecture);
    }

    [Fact]
    public void ApplicationContractsShouldDependOnItself()
    {
        var typesInApplication = Types().That().ResideInAssembly(ApplicationContractsAssembly);

        var rule = Types().That().Are(typesInApplication).Should()
            .OnlyDependOn(Types().That()
                .ResideInAssembly(ApplicationContractsAssembly).Or()
                .ResideInAssembly(SystemAssembly));

        rule.Check(Architecture);
    }

    [Fact]
    public void DomainShouldOnlyDependOnItself()
    {
        var typesInDomain = Types().That().ResideInAssembly(DomainAssembly);

        var rule = Types().That().Are(typesInDomain).Should()
            .OnlyDependOn(Types().That()
                .ResideInAssembly(DomainAssembly).Or()
                .ResideInAssembly(SystemAssembly).Or()
                .ResideInAssembly(SystemLinqAssembly));

        rule.Check(Architecture);
    }

    [Fact]
    public void PersistenceCsvShouldOnlyDependOnDomain()
    {
        var typesInPersistence = Types().That().ResideInAssembly(PersistenceCsvAssembly);

        var rule = Types().That().Are(typesInPersistence).Should()
            .OnlyDependOn(Types().That()
                .ResideInAssembly(DomainAssembly).Or()
                .ResideInAssembly(PersistenceCsvAssembly).Or()
                .ResideInAssembly(SystemAssembly).Or()
                .ResideInAssembly(SystemLinqAssembly).Or()
                .ResideInAssembly(SystemLinqExpressionsAssembly).Or()
                .ResideInAssembly(CsvHelperAssembly)
            );

        rule.Check(Architecture);
    }

    [Fact]
    public void PersistenceMemoryShouldOnlyDependOnDomain()
    {
        var typesInPersistence = Types().That().ResideInAssembly(PersistenceMemoryAssembly);

        var rule = Types().That().Are(typesInPersistence).Should()
            .OnlyDependOn(Types().That()
                .ResideInAssembly(DomainAssembly).Or()
                .ResideInAssembly(PersistenceMemoryAssembly).Or()
                .ResideInAssembly(SystemAssembly).Or()
                .ResideInAssembly(SystemLinqAssembly));

        rule.Check(Architecture);
    }
}