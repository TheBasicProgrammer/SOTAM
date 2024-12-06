namespace SOTAM.Interfaces // This namespace aligns with your project structure
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password);
        bool Register(string fullName, string username, string password);
    }
}
