using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Self.DTO;
using Self.Entity;
using log4net;
using Self.Services;
using System;
using System.Collections.Generic;

namespace Self.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceService _conferenceService;
        private readonly ILogger<ConferenceController> _logger;
        private readonly IMapper _mapper;

        public ConferenceController(IConferenceService conferenceService, IMapper mapper, ILogger<ConferenceController> logger)
        {
            _conferenceService = conferenceService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllConferences()
        {
            try
            {
                var conferences = _conferenceService.GetAllConferences();
                var conferenceDTOs = _mapper.Map<List<conferenceDTO>>(conferences);
                _logger.LogInformation("Retrieved all conferences successfully.");
                return Ok(conferenceDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all conferences.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetConferenceById(int id)
        {
            try
            {
                var conference = _conferenceService.GetConferenceById(id);
                if (conference == null)
                {
                    _logger.LogWarning($"Conference with ID {id} not found.");
                    return NotFound($"Conference with ID {id} not found.");
                }
                var conferenceDTO = _mapper.Map<conferenceDTO>(conference);
                _logger.LogInformation($"Retrieved conference with ID {id} successfully.");
                return Ok(conferenceDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving conference with ID {id}.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateConference([FromBody] conferenceDTO conferenceDTO)
        {
            try
            {
                var conference = _mapper.Map<Conference>(conferenceDTO);
                _conferenceService.CreateConference(conference);
                return CreatedAtAction(nameof(GetConferenceById), new { id = conference.conferenceID }, _mapper.Map<conferenceDTO>(conference));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating conference.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConference(int id, [FromBody] conferenceDTO conferenceDTO)
        {
            try
            {
                if (id != conferenceDTO.conferenceID)
                {
                    return BadRequest("Conference ID mismatch.");
                }
                var conference = _mapper.Map<Conference>(conferenceDTO);
                _conferenceService.UpdateConference(conference);
                return Ok(_mapper.Map<conferenceDTO>(conference));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating conference with ID {id}.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConference(int id)
        {
            try
            {
                _conferenceService.DeleteConference(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting conference with ID {id}.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
