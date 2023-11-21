using System.Linq;
using ArchUnitNET.Domain.Dependencies;
using ArchUnitNET.Domain.Extensions;
using Xunit;

namespace PizzaOnline.Architecture.Tests;

public class PersistenceRules : ArchitectureTest
{
    [Fact]
    public void RepositoriesShouldNotUseOtherRepositories()
    {
        var services =
            Architecture.Classes.Where(s => s.Namespace.NameContains("Persistence") && s.NameEndsWith("Repository"));

        Assert.All(services, c => Assert.True(
            c.Dependencies.FirstOrDefault(d => 
                d is not ImplementsInterfaceDependency &&
                d.Origin.FullName != d.Target.FullName &&
                d.Target.NameEndsWith("Repository"))
            == null));
    }
}