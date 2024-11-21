using FXT.Application.Services;
using FXT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FXT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyRateController : ControllerBase
    {
        private readonly ICurrencyRateService _currencyRateService;

        public CurrencyRateController(ICurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            var rates = await _currencyRateService.GetCurrencyRatesAsync();
            return Ok(rates);
        }

        [HttpPost]
        public async Task<IActionResult> AddRate([FromBody] CurrencyRate rate)
        {
            if (rate == null || string.IsNullOrWhiteSpace(rate.CurrencyPair))
            {
                return BadRequest("Invalid currency rate data.");
            }

            var result = await _currencyRateService.AddCurrencyRateAsync(rate);
            return CreatedAtAction(nameof(GetRates), result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRate(Guid id, [FromBody] CurrencyRate rate)
        {
            if (id == Guid.Empty || rate == null || rate.Id != id)
            {
                return BadRequest("Invalid request.");
            }

            await _currencyRateService.UpdateCurrencyRateAsync(rate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRate(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid request.");
            }

            await _currencyRateService.DeleteCurrencyRateAsync(id);
            return NoContent();
        }
    }
}
