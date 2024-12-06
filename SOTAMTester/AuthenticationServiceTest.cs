using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SOTAM.Models;
using SOTAM.Services;  // Use your namespace for AuthenticationService
using Xunit;

namespace SOTAM.Tests
{
    public class AuthenticationServiceTest
    {
        // Helper method to create an in-memory database context
        private SotamContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<SotamContext>()
                .UseInMemoryDatabase("TestSOTAM")  // Use an in-memory database for testing
                .Options;

            return new SotamContext(options);
        }

        [Fact]
        public void Register_Admin_Success()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);

            // Act
            bool result = authService.Register("John Doe", "johndoe", "password123");

            // Assert
            Assert.True(result); // Ensure that the registration was successful

            var admin = context.Admins.FirstOrDefault(a => a.Username == "johndoe");
            Assert.NotNull(admin);  // Ensure that the new admin was actually added to the in-memory database
            Assert.Equal("John Doe", admin.FullName); // Ensure the full name is correct
            Assert.Equal("johndoe", admin.Username);  // Ensure the username is correct
        }

        [Fact]
        public void Register_Admin_Failure_UsernameTaken()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);

            // First registration should succeed
            authService.Register("John Doe", "johndoe", "password123");

            // Act
            bool result = authService.Register("Jane Doe", "johndoe", "password456");

            // Assert
            Assert.False(result);  // Ensure that registration fails if the username is already taken
        }

        [Fact]
        public void Login_Admin_Success()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);

            // Register an admin
            authService.Register("Jane Doe", "janedoe", "password123");

            // Act
            bool loginResult = authService.Login("janedoe", "password123");

            // Assert
            Assert.True(loginResult); // Login should succeed with correct username and password
        }

        [Fact]
        public void Login_Admin_Failure_InvalidPassword()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);

            // Register an admin
            authService.Register("Jane Doe", "janedoe", "password123");

            // Act
            bool loginResult = authService.Login("janedoe", "wrongpassword");

            // Assert
            Assert.False(loginResult);  // Login should fail with an incorrect password
        }

        [Fact]
        public void Login_Admin_Failure_InvalidUsername()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);

            // Act
            bool loginResult = authService.Login("nonexistentuser", "password123");

            // Assert
            Assert.False(loginResult);  // Login should fail when the username doesn't exist
        }
    }
}
