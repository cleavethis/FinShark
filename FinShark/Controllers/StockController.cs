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
            var stock = await _context.Stock.FindAsync(id);

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
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(getById), new { id = stockModel.stockId }, stockModel);

        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = _context.Stock.FirstOrDefault(x => x.stockId == id);

            if (stockModel == null)
            { return NotFound(); }

            stockModel.symbol = updateDto.symbol;
            stockModel.purchase = updateDto.purchase;
            stockModel.companyName = updateDto.companyName;
            stockModel.marketCap = updateDto.marketCap;
            stockModel.lastDiv = updateDto.lastDiv;
            stockModel.industry = updateDto.industry;

           await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = _context.Stock.FirstOrDefault(x => x.stockId == id);

            if (stockModel == null) { return NotFound(); };

             _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    

        [HttpGet("find")]
        public async Task<IActionResult> FindStock(string searchTerm)
        {
            var stocks = await _context.Stock.Where(x => x.companyName.Contains(searchTerm)).ToListAsync();
            return Ok(stocks);
        }
    }
}
