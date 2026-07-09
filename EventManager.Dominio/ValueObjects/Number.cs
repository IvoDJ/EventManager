namespace EventManager.Dominio.ValueObjects;
using Comun;

public record Number
{
    public String Value {get; private set;}
    
    public Number(String value)
    {
        if((String.IsNullOrWhiteSpace(value) || !value.StartsWith("11")) && !value.StartsWith("221"))
        {
            throw new DomainException("El numero de telefono debe comenzar con 11 o 221");
        }
        if(value.Length != 10)
        {
            throw new DomainException("Teléfono inválido");
        }
        Value = value;
    }
    
}