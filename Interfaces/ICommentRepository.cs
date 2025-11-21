using meta.Models;

namespace meta.Interfaces;

public interface ICommentRepository

{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(int id);
}