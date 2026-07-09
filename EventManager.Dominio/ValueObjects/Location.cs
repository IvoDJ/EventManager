namespace EventManager.Dominio.ValueObjects;
using Comun;

public record Location
{
    public string Value {get;private set;}

    public Location(String value)
    {
      if(String.IsNullOrWhiteSpace(value) || value.All(char.IsDigit))
        {
            throw new DomainException("La ubicación ingresada es inválida");
        }
      Value = value;
    }
}