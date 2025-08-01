namespace PTR.Mongo.WebApp.Models.Dtos.Requests;

public class CreateCategoryRequestDto
{
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}
