namespace PTR.Mongo.WebApp.Models.Dtos.Requests;

public class AuthenticationRequestDto
{
    public string RestaurantName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
