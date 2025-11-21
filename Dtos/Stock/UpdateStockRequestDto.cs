using System.ComponentModel.DataAnnotations;

namespace meta.Dtos.Stock;

public class UpdateStockRequestDto
{
    [Required]
    [MaxLength(5,ErrorMessage =  "Symbol cannot exceed 5 characters")]
    [MinLength(5, ErrorMessage = "Symbol must have at least 5 characters")]
    public string Symbol { get; set; } = string.Empty;
    [Required]
    [MaxLength(100,ErrorMessage =  "Company Name cannot exceed 100 characters]")]
    [MinLength(2, ErrorMessage = "Company Name must have at least 2 characters")]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(1, 10000000, ErrorMessage = "Purchase must be between 1 and 1,000,000,000")]
    public decimal Purchase { get; set; }
    [Required]
    [Range(0, 10000, ErrorMessage = "Dividend must] be between 0 and $10000")]
    public decimal Dividend { get; set; }
    [Required]
    [Range(0, 10000, ErrorMessage = "Dividend must] be between 0 and $10000")]
    public decimal LastDiv { get; set; }
    [Required]
    [MaxLength(50,ErrorMessage =  "Industry cannot exceed 50 characters")]
    [MinLength(2, ErrorMessage = "Industry must have at least 2 characters")]
    public string Industry { get; set; } = string.Empty;
    [Required]
    [Range(1000, 1000000000000, ErrorMessage = "Market Cap must be between $1,000 and $1,000,000,000,000")]
    public long MarketCap { get; set; }
}