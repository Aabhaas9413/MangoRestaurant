using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result)); 
            }
            return View(list);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.CreateProductsAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }                
            }
            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.GetProductById<ResponseDto>(productId);
                if (response != null && response.IsSuccess == true)
                {
                    ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductsAsync<ResponseDto>(productDto);
                if (response != null && response.IsSuccess == true)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.GetProductById<ResponseDto>(productId);
                if (response != null && response.IsSuccess == true)
                {
                    ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductsAsync<ResponseDto>(productDto.ProductId);
                if (response != null && response.IsSuccess == true)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDto);
        }
    }
}
