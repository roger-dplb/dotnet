using meta.Models;

namespace meta.Interfaces;

public interface ICommentRepository

{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(int id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<Comment?> UpdateCommentAsync(Comment comment);
    Task <Comment?>DeleteCommentAsync(int id);
}