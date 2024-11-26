using FinShark.Dtos.Stock;
using FinShark.Models;
namespace FinShark.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {

            return new StockDto
            {
                stockId = stockModel.stockId,
                symbol = stockModel.symbol,
                companyName = stockModel.companyName,
                purchase = stockModel.purchase,
                lastDiv = stockModel.lastDiv,
                industry = stockModel.industry,
                marketCap = stockModel.marketCap,
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                symbol = stockDto.symbol,
                companyName = stockDto.companyName,
                purchase = stockDto.purchase,
                lastDiv = stockDto.lastDiv,
                industry = stockDto.industry,
                marketCap = stockDto.marketCap,
            };
        }
    }
}
