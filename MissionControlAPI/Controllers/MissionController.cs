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
    public class MissionController : ControllerBase
    {
        private readonly SpaceContext _context;
        private readonly IMapper _mapper;

        public MissionController(SpaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMissions()
        {
            try
            {
                var missions = await _context.Missions
                                              .Include(m => m.Rocket)
                                              .ToListAsync();

                // Use AutoMapper to map to MissionDTO
                var missionDTOs = _mapper.Map<List<MissionDTO>>(missions);

                return Ok(missionDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMission([FromBody] MissionDTO missionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Map the MissionDTO to Mission entity
                var mission = _mapper.Map<Mission>(missionDTO);

                // Add mission and related entities to the database
                await _context.Missions.AddAsync(mission);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMission), new { id = mission.MissionId }, missionDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MissionDTO>> GetMission(int id)
        {
            try
            {
                var mission = await _context.Missions
                                            .Include(m => m.Rocket)
                                            .FirstOrDefaultAsync(m => m.MissionId == id);

                if (mission == null)
                    return NotFound("Mission not found.");

                // Use AutoMapper to map to MissionDTO
                var missionDTO = _mapper.Map<MissionDTO>(mission);

                return Ok(missionDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMission(int id, [FromBody] MissionDTO missionDTO)
        {
            if (id != missionDTO.MissionId)
                return BadRequest("Mission ID mismatch.");

            try
            {
                var existingMission = await _context.Missions.FindAsync(id);
                if (existingMission == null)
                    return NotFound("Mission not found.");

                // Map the MissionDTO to existingMission entity
                _mapper.Map(missionDTO, existingMission);

                _context.Missions.Update(existingMission);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMission(int id)
        {
            try
            {
                var existingMission = await _context.Missions.FindAsync(id);
                if (existingMission == null)
                    return NotFound("Mission not found.");

                _context.Missions.Remove(existingMission);
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
