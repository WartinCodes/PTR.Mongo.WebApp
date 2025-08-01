using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Dtos.Responses;

namespace PTR.Mongo.WebApp.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryResponseDto> GetAllByUserId(int userId);
        CategoryResponseDto Create(CreateCategoryRequestDto request);
        void Delete(int id);
    }
}
