using FinShark.Data;
using Microsoft.AspNetCore.Mvc;
using FinShark.Mappers;
using FinShark.Dtos.Stock;
using FinShark.Models;
using Microsoft.OpenApi.Validations;

namespace FinShark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var stocks = _context.Stock.ToList().Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]

        public IActionResult getById([FromRoute] int id)
        {
            var stock = _context.Stock.Find(id);

            if (stock == null)
            {

                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            _context.Stock.Add(stockModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(getById), new { id = stockModel.stockId }, stockModel);

        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
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

            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stock.FirstOrDefault(x => x.stockId == id);

            if (stockModel == null) { return NotFound(); };

            _context.Stock.Remove(stockModel);
            _context.SaveChanges();

            return NoContent();

        }
    

        [HttpGet("find")]
        public IActionResult FindStock(string searchTerm)
        {
            var stocks = _context.Stock.Where(x => x.companyName.Contains(searchTerm)).ToList();
            return Ok(stocks);
        }
    }
}
