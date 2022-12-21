using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductById<T>(int id);
        Task<T> CreateProductsAsync<T>(ProductDto productDto);
        Task<T> UpdateProductsAsync<T>(ProductDto productDto);
        Task<T> DeleteProductsAsync<T>(int id);


    }
}
