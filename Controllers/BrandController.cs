using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSAAS.Data;
using AutoSAAS.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using AutoSAAS.Models;

namespace AutoSAAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly DataContext _context;
        public BrandController(DataContext context)
        {
            _context = context;

        }

        // GET api/brand
        [HttpGet("")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context.Brands.ToListAsync();
            return Ok(brands);
        }

        // GET api/brand/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brand = await _context.Brands.SingleOrDefaultAsync( i => i.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        // POST api/brand
        [HttpPost("")]
        public async Task<IActionResult> PostBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrands", new { id = brand.Id }, brand);
        }

        // PUT api/brand/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            brand.Id = id;
            _context.Entry(brand).State = EntityState.Modified;

           try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBrands", new { id = brand.Id }, brand);
        }

        // DELETE api/brand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrandById(int id)
        {
            var brand = await _context.Brands.SingleOrDefaultAsync( i => i.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return Ok(brand);

        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}