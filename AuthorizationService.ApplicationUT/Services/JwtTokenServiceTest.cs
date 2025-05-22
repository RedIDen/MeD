using AuthorizationService.Application.Services;
using AuthorizationService.Domain.Model;
using Microsoft.Extensions.Configuration;

namespace AuthorizationService.ApplicationUT.Services;

public class JwtTokenServiceTest
{
    [Test]
    public void Generate()
    {
        var configDict = new Dictionary<string, string>
        {
            {"Jwt:Key", "verysecretkeyverysecretkeybabyboooo"},
            {"Jwt:Issuer", "testissuer"},
            {"Jwt:Audience", "testaudience"},
        };

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(configDict)
            .Build();

        var service = new JwtTokenService(config);
        var user = new AuthorizationUser(Guid.NewGuid(), "user", [1]);

        var token = service.Generate(user);

        Assert.That(token, Is.Not.Null);
        Assert.That(token, Has.Length.GreaterThan(10));
    }
}
