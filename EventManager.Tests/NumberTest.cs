using EventManager.Dominio.ValueObjects;
using EventManager.Dominio.Comun;

namespace EventManager.Tests;

public class NumberTest
{
    [Fact]

    public void Number_WithValidValue_ShouldCreateSuccessfully()
    {
        var number = new Number("1132334456");
        var number2 = new Number("2213455472");
        Assert.Equal("1132334456", number.Value);
        Assert.Equal("2213455472", number2.Value);
    } 

    [Fact]

    public void Number_WithInvalidValue_ShouldThrowDomainException()
    {
        Assert.Throws<DomainException>(() => new Number("23424"));
    }

    [Fact]
public void Number_WithValidPrefixButTooShort_ShouldThrowDomainException()
{
    Assert.Throws<DomainException>(() => new Number("1132"));
}
}