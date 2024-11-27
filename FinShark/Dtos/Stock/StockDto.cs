using FinShark.Dtos.Comment;

namespace FinShark.Dtos.Stock
{
    public class StockDto
    {
        public int stockId { get; set; }
        public string symbol { get; set; } = string.Empty;
        public string companyName { get; set; } = string.Empty;
        public decimal purchase { get; set; }
        public decimal lastDiv { get; set; }
        public string industry { get; set; } = string.Empty;
        public long marketCap { get; set; }
        public List<CommentDto> comments { get; set; }
      
    }
}
