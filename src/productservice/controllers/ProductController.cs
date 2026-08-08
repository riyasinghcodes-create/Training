using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using productservice.data;
using Microsoft.EntityFrameworkCore;

namespace productservice.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    

    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{name}", Name = "GetProductByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());

            if (product == null)
            {
                return Ok(new
                {
                    found = false,
                    message = $"Product '{name}' not found."
                });
            }

            return Ok(new
            {
                found = true,
                product
            });
        }
    }
}