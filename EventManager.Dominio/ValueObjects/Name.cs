using EventManager.Dominio.Comun;

namespace EventManager.Dominio.ValueObjects;

public record Name
{
    public String Value {get; private set;}
    public Name(String value)
    {
        if (String.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("El nombre es obligatorio");
        }
        Value = value;
    }
}