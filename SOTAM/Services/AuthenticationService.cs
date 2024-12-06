using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SOTAM.Models;
using SOTAM.Interfaces;

public class AuthenticationService : IAuthenticationService
{
    private readonly SotamContext _context;

    public AuthenticationService(SotamContext context)
    {
        _context = context;
    }

    // Login logic
    public bool Login(string username, string password)
    {
        // Fetch the admin record by username
        var admin = _context.Admins.FirstOrDefault(a => a.Username == username);
        if (admin == null) return false; // Username does not exist

        // Validate the hashed password
        return VerifyPassword(password, admin.Password);
    }

    // Registration logic
    public bool Register(string fullName, string username, string password)
    {
        // Check if the username is already taken
        if (_context.Admins.Any(a => a.Username == username))
            return false;

        // Hash the password
        string hashedPassword = HashPassword(password);

        // Add new admin
        var newAdmin = new Admin
        {
            FullName = fullName,
            Username = username,
            Password = hashedPassword
        };

        _context.Admins.Add(newAdmin);
        _context.SaveChanges();

        return true;
    }

    // Hash the password using SHA256
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

    // Verify hashed password
    private bool VerifyPassword(string inputPassword, string storedHash)
    {
        string inputHash = HashPassword(inputPassword);
        return inputHash == storedHash;
    }
}
