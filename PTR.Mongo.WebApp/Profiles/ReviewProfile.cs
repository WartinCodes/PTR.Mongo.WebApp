using AutoMapper;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Dtos.Responses;

namespace PTR.Mongo.WebApp.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewRequest, Review>();
        }
    }
}
