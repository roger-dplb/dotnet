using System.ComponentModel.DataAnnotations;

namespace meta.Dtos.Comment;

public class UpdateCommentDto
{
    [Required]
    [MinLength(5, ErrorMessage =  "Title must have at least 5 characters")]
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(10, ErrorMessage =  "Content must have at least 10 characters")]
    [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters")]
    public string Content { get; set; } = string.Empty;
}