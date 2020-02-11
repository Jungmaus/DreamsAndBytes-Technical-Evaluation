using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DreamsAndBytes.Builder;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.Enums;
using DreamsAndBytes.UI.Models.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DreamsAndBytes.UI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, IMapper mapper, IProductTypeService productTypeService, IWebHostEnvironment env)
        {
            this._productService = productService;
            this._mapper = mapper;
            this._productTypeService = productTypeService;
            this._env = env;
        }

        public IActionResult Index() => View(
            _mapper.Map<List<ProductVM>>(
            _productService.Get(x => !x.IsDeleted).ToList()
            ));

        public IActionResult Management()
        {
            List<ProductVM> model = _mapper.Map<List<ProductVM>>(
            _productService.Get(x => !x.IsDeleted).ToList());

            foreach(var item in model)
            {
                item.ProductTypeName = _productTypeService.Get(x => x.ID == item.ProductTypeId && !x.IsDeleted).FirstOrDefault()?.Name;
            }

            return View(model);
        }


        public IActionResult Add()
        {
            AddProductVM model = new AddProductVM()
            {
                ProductTypeSelectList = DropdownBuilder.CreateProductTypeDropdownList(
                        _productTypeService.Get(x => !x.IsDeleted).ToList())
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddProductVM model)
        {
            if (ModelState.IsValid)
            {
                ProductEntity productEntity = _mapper.Map<ProductEntity>(model);

                if (model.Image != null && model.Image.Length > 0)
                {
                    string guid = Guid.NewGuid().ToString();
                    var filePath = ($"{_env.WebRootPath}/img/product/{guid}{model.Image.FileName}");

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    productEntity.ImagePath = ($"/img/product/{guid}{model.Image.FileName}");
                }

                _productService.Add(productEntity);
                _productService.SaveChanges();

                ViewBag.OperationResult = OperationResultEnum.Success;
            }
            else
            {
                ViewBag.OperationResult = OperationResultEnum.Failure;
            }

            model.ProductTypeSelectList = DropdownBuilder.CreateProductTypeDropdownList(
                        _productTypeService.Get(x => !x.IsDeleted).ToList());

            return View(model);
        }


        public IActionResult Edit(int id)
        {
            ProductEntity product = _productService.Get(x => x.ID == id && !x.IsDeleted).FirstOrDefault();
            
            if (product == null)
                return RedirectToAction("Managament");

            EditProductVM model = _mapper.Map<EditProductVM>(product);
            model.ProductTypeSelectList = DropdownBuilder.CreateProductTypeDropdownList(_productTypeService.Get(x => !x.IsDeleted).ToList());

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductVM model)
        {
            if(ModelState.IsValid)
            {
                ProductEntity product = _productService.Get(x => x.ID == model.ID && !x.IsDeleted).FirstOrDefault();

                if (product == null)
                    return RedirectToAction("Managament");

                product = _mapper.Map<ProductEntity>(model);

                if (model.Image != null && model.Image.Length > 0)
                {

                    if (System.IO.File.Exists(_env.WebRootPath + product.ImagePath))
                    {
                        System.IO.File.Delete(_env.WebRootPath + product.ImagePath);
                    }

                    string guid = Guid.NewGuid().ToString();
                    var filePath = ($"{_env.WebRootPath}/img/product/{guid}{model.Image.FileName}");

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    product.ImagePath = model.ImagePath = ($"/img/product/{guid}{model.Image.FileName}");

                }
                
                _productService.Update(product);
                _productService.SaveChanges();

                ViewBag.OperationResult = OperationResultEnum.Success;
            }
            else
            {
                ViewBag.OperationResult = OperationResultEnum.Failure;
            }

            model.ProductTypeSelectList = DropdownBuilder.CreateProductTypeDropdownList(_productTypeService.Get(x => !x.IsDeleted).ToList());
            return View(model);
        }


        [HttpPost]
        public void Delete(int id)
        {
            _productService.Delete(
                _productService.Get(x => x.ID == id).FirstOrDefault()
                );
            _productService.SaveChanges();
        }
    }
}