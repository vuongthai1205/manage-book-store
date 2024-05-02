namespace backend{
    public interface ICommentService{
        Task<Comment> AddComment(CommentRequest commentRequest);
        Task<Comment> UpdateComment(int id,CommentRequest commentRequest);
        Task<bool> DeleteComment(int id);
        Task<Comment> GetComment(int id);
        Task<IEnumerable<Comment>> GetAllComment();
        Task<IEnumerable<Comment>> GetAllCommentWithBookId(int idBook);

    }
}