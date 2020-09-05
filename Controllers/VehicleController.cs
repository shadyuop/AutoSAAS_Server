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
    public class VehicleController : ControllerBase
    {
        private readonly DataContext _context;
        public VehicleController(DataContext context)
        {
            _context = context;

        }

        // GET api/vehicle
        [HttpGet("")]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return Ok(vehicles);
        }

        // GET api/vehicle/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(i => i.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        // POST api/vehicle
        [HttpPost("")]
        public async Task<IActionResult> PostVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicles", new { id = vehicle.Id }, vehicle);
        }

        // PUT api/vehicle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            vehicle.Id = id;
            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVehicles", new { id = vehicle.Id }, vehicle);
        }

        // DELETE api/vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleById(int id)
        {
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(i => i.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(vehicle);

        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }

}