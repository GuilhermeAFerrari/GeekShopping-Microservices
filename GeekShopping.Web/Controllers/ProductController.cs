﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllAsync();
            return View(products);
        }

        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProductCreate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateAsync(product);
                if (response is not null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(product);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var product = await _productService.FindByIdAsync(id);

            if (product is not null) return View(product);
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProductUpdate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateAsync(product);
                if (response is not null) return RedirectToAction(nameof(ProductIndex));
            }

            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _productService.FindByIdAsync(id);

            if (product is not null) return View(product);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN)]
        public async Task<IActionResult> ProductDelete(ProductModel product)
        {
            var response = await _productService.DeleteByIdAsync(product.Id);
            if (response) return RedirectToAction(nameof(ProductIndex));

            return View(product);
        }
    }
}