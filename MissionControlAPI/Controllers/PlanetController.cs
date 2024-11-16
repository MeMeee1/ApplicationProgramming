using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissionControlAPI.Models;
using MissionControlAPI.Models.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MissionControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly SpaceContext _context;
        private readonly IMapper _mapper;

        public PlanetController(SpaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanets()
        {
            try
            {
                var planets = await _context.Planets
                                             .Include(p => p.Rockets)
                                             .ThenInclude(r => r.Missions)
                                             .ToListAsync();

                
                var planetDTOs = _mapper.Map<List<PlanetDTO>>(planets);

                return Ok(planetDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanet([FromBody] PlanetDTO planetDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
               
                var planet = _mapper.Map<Planet>(planetDTO);

                // Add planet and related entities to the database
                await _context.Planets.AddAsync(planet);
                await _context.SaveChangesAsync();

                // Return the created PlanetDTO with a 201 Created status
                return CreatedAtAction(nameof(GetPlanet), new { id = planet.PlanetId }, planetDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetDTO>> GetPlanet(int id)
        {
            try
            {
                var planet = await _context.Planets
                                           .Include(p => p.Rockets)
                                           .ThenInclude(r => r.Missions)
                                           .FirstOrDefaultAsync(p => p.PlanetId == id);

                if (planet == null)
                    return NotFound("Planet not found.");

               
                var planetDTO = _mapper.Map<PlanetDTO>(planet);

                return Ok(planetDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlanet(int id, [FromBody] PlanetDTO planetDTO)
        {
            if (id != planetDTO.PlanetId)
                return BadRequest("Planet ID mismatch.");

            try
            {
                var existingPlanet = await _context.Planets.FindAsync(id);
                if (existingPlanet == null)
                    return NotFound("Planet not found.");

               
                _mapper.Map(planetDTO, existingPlanet);

                _context.Planets.Update(existingPlanet);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlanet(int id)
        {
           
            try
            {
                var existingPlanet = await _context.Planets.FindAsync(id);
                if (existingPlanet == null)
                    return NotFound("Planet not found.");

                _context.Planets.Remove(existingPlanet);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
