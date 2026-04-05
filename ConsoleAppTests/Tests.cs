using Xunit;
using ConsoleApp.Uttils;

namespace ConsoleAppTests;

public class Tests
{
    [Fact]
    public void PasswordManager_ShouldInitialize_Successfully()
    {
        var passwordManager = new PasswordManager();

        Assert.NotNull(passwordManager);
    }
}
