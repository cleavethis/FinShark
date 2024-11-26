using FinShark.Interfaces;
using FinShark.Models;
using FinShark.Data;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
            
        }
        Task<List<Stock>> IStockRepository.GetAllAsync()
        {
            return _context.Stock.ToListAsync();
        }
    }
}
