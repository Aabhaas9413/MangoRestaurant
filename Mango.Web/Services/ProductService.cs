using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;                   
        }
        public async Task<T> CreateProductsAsync<T>(ProductDto productDto)
        {
           return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                ApiUrl = SD.ProductAPIBase + "api/products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductsAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,                
                ApiUrl = SD.ProductAPIBase + "api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ProductAPIBase + "api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ProductAPIBase + "api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductsAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                ApiUrl = SD.ProductAPIBase + "api/products",
                AccessToken = ""
            });
        }
    }
}
