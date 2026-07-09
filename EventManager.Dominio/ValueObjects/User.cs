using EventManager.Dominio.Comun;

namespace EventManager.Dominio.ValueObjects;

public record User
{
 public String Username{get; private set;}
 public String Password{get; private set;}   

 public User(String username, String password)
    {
        Username = String.IsNullOrWhiteSpace(username) 
                   ? throw new DomainException("El nombre de usuario es obligatorio")
                   : username;

        if(String.IsNullOrWhiteSpace(password)) throw new DomainException("La contraseña es obligatoria");
        if(!password.Any(char.IsDigit)) throw new DomainException("La contraseña debe tener al menos un número");
        if(!password.Any(char.IsSymbol) && !password.Any(char.IsPunctuation)) throw new DomainException("La contraseña debe tener al menos un carácter especial");
        Password = password;
    }

protected User(){}
}