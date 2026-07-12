namespace EventManagerFront.Services;

public class AuthService
{
    public bool IsLoggedIn { get; private set; }
    public event Action? OnChange;

    public void SetLoggedIn(bool value)
    {
        IsLoggedIn = value;
        OnChange?.Invoke();
    }
}