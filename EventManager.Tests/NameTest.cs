using EventManager.Dominio.ValueObjects;
using EventManager.Dominio.Comun;

namespace EventManager.Tests;

public class NameTests
{
    [Fact]
    public void Name_WithValidValue_ShouldCreateSuccessfully()
    {
        // Arrange & Act
        var name = new Name("Ivan DJ");

        // Assert
        Assert.Equal("Ivan DJ", name.Value);
    }

    [Fact]
    public void Name_WithEmptyValue_ShouldThrowDomainException()
    {
        // Assert
        Assert.Throws<DomainException>(() => new Name(""));
    }

    [Fact]
    public void Name_WithWhiteSpace_ShouldThrowDomainException()
    {
        // Assert
        Assert.Throws<DomainException>(() => new Name("   "));
    }
}