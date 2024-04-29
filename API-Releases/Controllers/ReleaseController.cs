using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Report.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    public class ReleaseController(IAccountingService bookEntryService) : ControllerBase
    {
        private readonly IAccountingService _bookEntryService = bookEntryService;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Release release)
        {
            try
            {
                var result = await _bookEntryService.Create(release);
                return Created(nameof(Get), result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { Errors = new[] { e.Message } });
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _bookEntryService.Get(id);
            return Ok(result);
        }
    }
}
