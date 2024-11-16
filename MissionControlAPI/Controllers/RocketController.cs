using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissionControlAPI.Models;
using MissionControlAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketController : ControllerBase
    {
        private readonly SpaceContext _context;
        private readonly IMapper _mapper;

        public RocketController(SpaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRockets()
        {
            try
            {
                var rockets = await _context.Rockets
                                            .Include(r => r.Missions)
                                            .ToListAsync();

                // Use AutoMapper to map to RocketDTO
                var rocketDTOs = _mapper.Map<List<RocketDTO>>(rockets);

                return Ok(rocketDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRocket([FromBody] RocketDTO rocketDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Map the RocketDTO to Rocket entity
                var rocket = _mapper.Map<Rocket>(rocketDTO);

                // Add rocket and related entities to the database
                await _context.Rockets.AddAsync(rocket);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRocket), new { id = rocket.RocketId }, rocketDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RocketDTO>> GetRocket(int id)
        {
            try
            {
                var rocket = await _context.Rockets
                                           .Include(r => r.Missions)
                                           .FirstOrDefaultAsync(r => r.RocketId == id);

                if (rocket == null)
                    return NotFound("Rocket not found.");

                // Use AutoMapper to map to RocketDTO
                var rocketDTO = _mapper.Map<RocketDTO>(rocket);

                return Ok(rocketDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRocket(int id, [FromBody] RocketDTO rocketDTO)
        {
            if (id != rocketDTO.RocketId)
                return BadRequest("Rocket ID mismatch.");

            try
            {
                var existingRocket = await _context.Rockets.FindAsync(id);
                if (existingRocket == null)
                    return NotFound("Rocket not found.");

                // Map the RocketDTO to existingRocket entity
                _mapper.Map(rocketDTO, existingRocket);

                _context.Rockets.Update(existingRocket);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRocket(int id)
        {
            try
            {
                var existingRocket = await _context.Rockets.FindAsync(id);
                if (existingRocket == null)
                    return NotFound("Rocket not found.");

                _context.Rockets.Remove(existingRocket);
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
