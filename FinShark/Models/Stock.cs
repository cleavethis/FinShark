using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.Models
{
    public class Stock
    {
        public int stockId { get; set; }
        public string symbol { get; set; } = string.Empty;
        public string companyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal lastDiv { get; set; }
        public string industry { get; set; } = string.Empty;
        public long marketCap { get; set; }
        public List<Comment> comments { get; set; } = new List<Comment>();

    }
}
