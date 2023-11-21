using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace PizzaOnline.Architecture.Tests;

public class DomainRules : ArchitectureTest
{
    [Fact]
    public void DomainShouldNotUseRepositories()
    {
        var rule = Classes().That().ResideInAssembly(DomainAssembly).Should()
            .NotDependOnAny(Types().That().HaveNameEndingWith("Repository"));
        
        rule.Check(Architecture);
    }
}