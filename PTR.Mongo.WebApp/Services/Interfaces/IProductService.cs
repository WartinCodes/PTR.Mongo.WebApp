using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Dtos.Responses;

namespace PTR.Mongo.WebApp.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductResponseDto> GetAll();
    IEnumerable<ProductResponseDto> GetAllByUserIdAsync(int userId);
    Task<ProductResponseDto> GetByProductId(int productId);
    ProductResponseDto Create(CreateProductRequestDto request);
    void Delete(int id);
}