namespace backend
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetAllCommentWithBookId(int idBook);

    }
}