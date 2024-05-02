using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace backend;
[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase{
    private readonly ICommentService commentService;
    public CommentController (ICommentService _commentService) {
        commentService = _commentService ;
    }
    [HttpGet]
    [EnableQuery]
    public async Task<IEnumerable<Comment>> GetAll() {

        return await commentService.GetAllComment();
    }
    [HttpPost]
    public async Task<Comment> CreateComment([FromBody] CommentRequest commentRequest){
        return await commentService.AddComment(commentRequest);
    }
    [HttpGet("{id}")]
    public async Task<Comment> GetCommentById(int id ){
        return await commentService.GetComment(id);
    }

    [HttpGet("idBook/{id}")]
    public async Task<IEnumerable<Comment>> GetCommentByIdBook(int id ){
        return await commentService.GetAllCommentWithBookId(id);
    }
    [HttpPut("{id}")]
    public async Task<Comment> UpdateComment(int id, [FromBody] CommentRequest commentRequest ){
        return await commentService.UpdateComment(id, commentRequest);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id){
        var isDelete = await commentService.DeleteComment(id);
        if(isDelete)    
        {
            return NoContent();
        }
        return BadRequest();
    }
}