using meta.Data;
using meta.Interfaces;
using meta.Models;
using Microsoft.EntityFrameworkCore;

namespace meta.Repository;

public class CommentRepository(ApplicationDbContext context): ICommentRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _context.Comment.ToListAsync();
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
        var comment = await _context.Comment.FindAsync(id);
        return comment ?? null!;
    }
}