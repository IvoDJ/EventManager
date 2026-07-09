namespace EventManager.Dominio.Entities;

using EventManager.Dominio.Abstractions;
using EventManager.Dominio.Comun;
using ValueObjects;

public class Contact : Entity
{
  public Name Name {get; private set;} = null!;
  public Number Number {get; private set;} = null!;

  public Contact(Name name, Number number)
    {
        this.Name = name; 
        this.Number = number; 
    }
  protected Contact(){}
}