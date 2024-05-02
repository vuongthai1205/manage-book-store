
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class CommentRepository : BaseRepository<Comment> , ICommentRepository
    {
        BookStoreDbContext _db;
        public CommentRepository(BookStoreDbContext _con) : base(_con)
        {
            _db = _con;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentWithBookId(int idBook)
        {
            var comments = await _db.Comments.Where(e => e.BookId == idBook).ToListAsync();
            return comments;
        }
    }
}