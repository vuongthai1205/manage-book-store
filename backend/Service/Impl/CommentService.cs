
using AutoMapper;

namespace backend
{
    public class CommentService : ICommentService{
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        public CommentService(ICommentRepository _commentRepository, IMapper _mapper){
            commentRepository = _commentRepository;
            mapper = _mapper;
        }

        public async Task<Comment> AddComment(CommentRequest commentRequest)
        {
            Comment comment = mapper.Map<CommentRequest, Comment>(commentRequest);
            return await commentRepository.AddAsync(comment);
        }

        public async Task<bool> DeleteComment(int id)
        {
            Comment comment =  await commentRepository.DeleteAsync(id);
            if(comment is not null) {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            return await commentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentWithBookId(int idBook)
        {
            return await commentRepository.GetAllCommentWithBookId(idBook);
        }

        public async Task<Comment> GetComment(int id)
        {
            return await commentRepository.GetByIdAsync(id);
        }

        public async Task<Comment> UpdateComment(int id, CommentRequest commentRequest)
        {
            Comment comment = await commentRepository.GetByIdAsync(id);
            mapper.Map(commentRequest, comment);
            return await commentRepository.UpdateAsync(comment);
        }
    }
}