using FinShark.Data;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
           return await _context.Comment.FindAsync(id);
        }
    }
}
