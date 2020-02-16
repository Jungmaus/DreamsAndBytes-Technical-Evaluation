using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DreamsAndBytes.API.Models.Product;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Entity.Entities.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DreamsAndBytes.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IMapper mapper, IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            this._mapper = mapper;
            this._productService = productService;
            this._webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        [Route("GetAll")]
        public List<ProductModel> GetAll()
        {
            List<ProductModel> model = _mapper.Map<List<ProductModel>>(_productService.Get().ToList());
            return model;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ProductAddResponseModel> Add([FromForm]ProductAddRequestModel model)
        {
            ProductAddResponseModel response = new ProductAddResponseModel();
            if (ModelState.IsValid)
            {
                ProductEntity productEntity = _mapper.Map<ProductEntity>(model);
                productEntity.AddDate = DateTime.Now;

                if (model.Image != null && model.Image.Length > 0)
                {
                    string uiRootPath = string.Concat(_webHostEnvironment.ContentRootPath.Replace("API", "UI"), "/wwwroot/");
                    string guid = Guid.NewGuid().ToString();
                    var filePath = ($"{uiRootPath}/img/product/{guid}{model.Image.FileName}");

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    productEntity.ImagePath = ($"/img/product/{guid}{model.Image.FileName}");
                }

                _productService.Add(productEntity);
                _productService.SaveChanges();

                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Invalid input";
            }
            return response;
        }
    }
}