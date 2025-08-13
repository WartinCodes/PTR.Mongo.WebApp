namespace PTR.Mongo.WebApp.Models.Dtos.Requests
{
    public class CreateReviewRequest
    {
        public string ProductId { get; set; }
        public string AuthorName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
