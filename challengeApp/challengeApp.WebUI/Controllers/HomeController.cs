using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challengeApp.WebUI.Models;
using challengeApp.Business.Abstract;
using challengeApp.Entities;
using Microsoft.EntityFrameworkCore;


namespace challengeApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string sortOrder)
        {
        
          
            return View(new ProductListModels()
            {
                Products = _productService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult PCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PCreate(ProductCreateModels model)
        {
            var entity = new Product()
            {
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                ProductDefinition = model.ProductDefinition,
                ProductImage = model.ProductImage,
            };
            _productService.Create(entity);
            return Redirect("Index");
        }
        [HttpGet]
        [Route("Home/Update/{id:int}")]
        public IActionResult Update(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var entity = _productService.GetById((int)id);
            if(entity==null)
            {
                return NotFound();
            }
            var model = new ProductCreateModels()
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                ProductImage = entity.ProductImage,
                ProductPrice = entity.ProductPrice,
                ProductDefinition = entity.ProductDefinition,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(ProductCreateModels model)
        {
            var entity = _productService.GetById(model.Id);
            if(entity==null)
            {
                return NotFound();
            }
            entity.ProductName = model.ProductName;
            entity.ProductPrice = model.ProductPrice;
            entity.ProductImage = model.ProductImage;
            entity.ProductDefinition = model.ProductDefinition;
            _productService.Update(entity);

            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var entity = _productService.GetById(id);
            if(entity!=null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Search(string search)
        {
            var model = new ProductListModels()
            {
                Products = _productService.GetSearch(search)
            };
            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
