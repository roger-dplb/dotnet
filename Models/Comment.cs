using System.ComponentModel.DataAnnotations.Schema;

namespace meta.Models;

public class Comment
{
   public int Id { get; set; }
   public string Title { get; set; } = string.Empty;
   public string Content { get; set; } = string.Empty;
   public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   public int? StockId { get; set; }// nav property 
   public Stock? Stock { get; set; }
}