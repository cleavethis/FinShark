using FinShark.Data;
using Microsoft.AspNetCore.Mvc;
using FinShark.Mappers;
using FinShark.Dtos.Stock;
using FinShark.Models;

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
          
            return CreatedAtAction(nameof(getById), new { id = stockModel.stockId}, stockModel);

        }
    }
           
}
