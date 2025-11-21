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
    
    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        await _context.Comment.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateCommentAsync(Comment comment)
    {
        var existingComment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == comment.Id);
        if (existingComment == null)
        {
            return null;
        }
        existingComment.Content = comment.Content;
        existingComment.CreatedAt = comment.CreatedAt;
        existingComment.Title = comment.Title;
        await _context.SaveChangesAsync();
        return existingComment;
    }

    public async Task<Comment?> DeleteCommentAsync(int id)
    {
         var comment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == id);
         if (comment == null) return null;
         _context.Comment.Remove(comment);
         await _context.SaveChangesAsync();
         return comment;

    }
}