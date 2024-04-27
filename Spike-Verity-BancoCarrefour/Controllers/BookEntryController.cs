using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spike_Verity_BancoCarrefour.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    public class BookEntryController(IBookEntryService bookEntryService, ILogger<BookEntryController> logger) : ControllerBase
    {
        private readonly IBookEntryService _bookEntryService = bookEntryService;
        private readonly ILogger<BookEntryController> _logger = logger;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Release productDto)
        {
            try
            {
                var result = await _bookEntryService.Create(productDto);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { Errors = new[] { e.Message } });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao criar um novo book entry");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
