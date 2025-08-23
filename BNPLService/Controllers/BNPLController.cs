using BNPLService.Services;
using Microsoft.AspNetCore.Mvc;

using System;

namespace BNPLService.Controllers
{
    [ApiController]
    [Route("api/bnpl")]
    public class BNPLController : ControllerBase
    {
        private readonly BNPLManager _bnplManager;
        public BNPLController(BNPLManager bnplManager)
        {
            _bnplManager = bnplManager;
        }

        [HttpGet]
        public IActionResult GetAllApplications()
        {
            var applications = _bnplManager.GetAllApplications();
            return Ok(applications);
        }
        [HttpGet("{id}")]
        public IActionResult GetApplicationById(Guid id)
        {
            var application = _bnplManager.GetApplicationById(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }
        [HttpPost]
        public IActionResult CreateApplication([FromBody] BNPLAppCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var application = _bnplManager.CreateApplication(dto.UserId, dto.ProductId);
            return CreatedAtAction(nameof(GetAllApplications), new { id = application.Id }, application);
        }
    }
}

