using FinShark.Interfaces;
using FinShark.Models;
using FinShark.Data;
using Microsoft.EntityFrameworkCore;
using FinShark.Dtos.Stock;

namespace FinShark.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;

        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.ToListAsync();
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;

        }
        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.stockId == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _context.Stock.FirstOrDefaultAsync(x => x.stockId == id);
            if (existingStock != null)
            {
                return null;
            }

            existingStock.symbol = stockDto.symbol;
            existingStock.purchase = stockDto.purchase;
            existingStock.companyName = stockDto.companyName;
            existingStock.marketCap = stockDto.marketCap;
            existingStock.lastDiv = stockDto.lastDiv;
            existingStock.industry = stockDto.industry;

            await _context.SaveChangesAsync();

            return existingStock;
        }

        public async Task<List<Stock>> FindStockAsync(string searchTerm)
        {
             var stocks = await _context.Stock.Where(x => x.companyName.Contains(searchTerm)).ToListAsync();
            if (stocks == null)
            {
                return null;
            }

            return stocks;
        }
    }
}
