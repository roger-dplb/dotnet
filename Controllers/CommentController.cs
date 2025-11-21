using meta.Interfaces;
using AutoMapper;
using meta.Dtos.Comment;
using Microsoft.AspNetCore.Mvc;

namespace meta.Controllers;

[ApiController]
[Route("api/comment")]
public class CommentController(ICommentRepository repository, IMapper mapper) : ControllerBase
{
    private readonly ICommentRepository _repo = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _repo.GetAllCommentsAsync();
        var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(comments);
        return Ok(commentsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var comment = await _repo.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        var commentDto = _mapper.Map<CommentDto>(comment);
        return Ok(commentDto);
    }
}