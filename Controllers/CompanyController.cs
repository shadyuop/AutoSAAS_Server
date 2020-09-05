using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSAAS.Data;
using AutoSAAS.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoSAAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _context;
        public CompanyController(DataContext context)
        {
            _context = context;

        }

        // GET api/company
        [HttpGet("")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return Ok(companies);
        }

        // GET api/company/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(i => i.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST api/company
        [HttpPost("")]
        public async Task<IActionResult> PostCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanies", new { id = company.Id }, company);
        }

        // PUT api/company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            company.Id = id;
            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompanies", new { id = company.Id }, company);
        }

        // DELETE api/company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyById(int id)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(i => i.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return Ok(company);

        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }

    }
}