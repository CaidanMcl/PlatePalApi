using Microsoft.AspNetCore.Mvc;
using PlatePalApi.Models;
using PlatePalApi.Services;

namespace PlatePalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberPlateController : ControllerBase
    {
        private readonly numPlateService _plateService;

        public NumberPlateController(numPlateService nPlateService) =>
            _plateService = nPlateService;

        [HttpGet]
        public async Task<List<NumberPlate>> Get() =>
            await _plateService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<NumberPlate>> Get(string id)
        {
            var plate = await _plateService.GetAsync(id);

            if (plate is null)
            {
                return NotFound();
            }

            return plate;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NumberPlate newNplate)
        {
            await _plateService.CreateAsync(newNplate);

            return CreatedAtAction(nameof(Get), new { id = newNplate.Id }, newNplate);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, NumberPlate updatesPnum)
        {
            var plate = await _plateService.GetAsync(id);

            if (plate is null)
            {
                return NotFound();
            }

            updatesPnum.Id = plate.Id;

            await _plateService.UpdateAsync(id, updatesPnum);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var plate = await _plateService.GetAsync(id);

            if (plate is null)
            {
                return NotFound();
            }

            await _plateService.RemoveAsync(id);

            return NoContent();
        }
    }
}