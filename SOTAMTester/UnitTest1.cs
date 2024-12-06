using System;
using System.Linq;
using Xunit;
using SOTAM.Models;
using SOTAM.Services;
using Microsoft.EntityFrameworkCore;

namespace SOTAM.Tests
{
    public class AuthenticationServiceTests
    {
        // Create an in-memory database for testing
        private SotamContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<SotamContext>()
                .UseInMemoryDatabase(databaseName: "TestSOTAM") // In-memory database for testing
                .Options;

            var context = new SotamContext(options);
            return context;
        }

        [Fact]
        public void Register_Admin_ShouldReturnTrue_WhenUsernameIsUnique()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);

            // Act
            bool registrationResult = authService.Register("Test Admin", "testadmin", "password123");

            // Assert
            Assert.True(registrationResult);
            var admin = context.Admins.FirstOrDefault(a => a.Username == "testadmin");
            Assert.NotNull(admin);
        }

        [Fact]
        public void Login_ShouldReturnTrue_WhenCredentialsAreCorrect()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);
            authService.Register("Test Admin", "testadmin", "password123");

            // Act
            bool loginResult = authService.Login("testadmin", "password123");

            // Assert
            Assert.True(loginResult);
        }

        [Fact]
        public void Login_ShouldReturnFalse_WhenUsernameIsIncorrect()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);
            authService.Register("Test Admin", "testadmin", "password123");

            // Act
            bool loginResult = authService.Login("wrongadmin", "password123");

            // Assert
            Assert.False(loginResult);
        }

        [Fact]
        public void Login_ShouldReturnFalse_WhenPasswordIsIncorrect()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var authService = new AuthenticationService(context);
            authService.Register("Test Admin", "testadmin", "password123");

            // Act
            bool loginResult = authService.Login("testadmin", "wrongpassword");

            // Assert
            Assert.False(loginResult);
        }
    }
}
