namespace PTR.Mongo.WebApp.Models.Dtos.Responses
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
