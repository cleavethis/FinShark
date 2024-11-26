using FinShark.Data;
using Microsoft.AspNetCore.Mvc;
using FinShark.Mappers;
using FinShark.Dtos.Stock;
using FinShark.Models;
using Microsoft.OpenApi.Validations;
using Microsoft.EntityFrameworkCore;
using FinShark.Interfaces;

namespace FinShark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> getById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
            {

                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
           
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(getById), new { id = stockModel.stockId }, stockModel);

        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if (stockModel == null)
            { return NotFound(); }

           
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepo.DeleteAsync(id);

            if (stockModel == null) { return NotFound(); };

           

            return NoContent();

        }
    

        [HttpGet("find")]
        public async Task<IActionResult> FindStock(string searchTerm)
        {
            var stocks = await _stockRepo.FindStockAsync(searchTerm);
            return Ok(stocks);
        }
    }
}
