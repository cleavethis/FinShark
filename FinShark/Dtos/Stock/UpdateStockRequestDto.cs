namespace FinShark.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        public string symbol { get; set; } = string.Empty;
        public string companyName { get; set; } = string.Empty;

        public decimal purchase { get; set; }
        public decimal lastDiv { get; set; }
        public string industry { get; set; } = string.Empty;
        public long marketCap { get; set; }
    }
}
