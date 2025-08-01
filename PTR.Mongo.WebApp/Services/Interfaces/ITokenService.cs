namespace PTR.Mongo.WebApp.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(string username);
}
