namespace FinShark.Dtos.Comment
{
    public class CommentDto
    {
        public int commentID { get; set; }
        public int? stockId { get; set; }
        public String title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}
