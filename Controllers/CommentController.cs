using meta.Interfaces;
using AutoMapper;
using meta.Dtos.Comment;
using meta.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace meta.Controllers;

[ApiController]
[Route("api/comment")]
public class CommentController(ICommentRepository commentRepository, IMapper mapper, IStockRepository stockRepository) : ControllerBase
{
    private readonly ICommentRepository _commentRepo = commentRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IStockRepository _stockRepo = stockRepository;

    [HttpGet]
    public async Task<IActionResult> GetAll( )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comments = await _commentRepo.GetAllCommentsAsync();
        var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(comments);
        return Ok(commentsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comment = await _commentRepo.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        var commentDto = _mapper.Map<CommentDto>(comment);
        return Ok(commentDto);
    }
    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (!await _stockRepo.StockExistsAsync(stockId))
        {
            return NotFound($"Stock with ID {stockId} not found.");
        }
        var commentModel = _mapper.Map<meta.Models.Comment>(commentDto);
        commentModel.StockId = stockId;
        await _commentRepo.CreateCommentAsync(commentModel);
        var createdCommentDto = _mapper.Map<CommentDto>(commentModel);
        return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, createdCommentDto);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto commentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingComment = await _commentRepo.GetCommentByIdAsync(id);
        if (existingComment == null)
        {
            return NotFound();
        }
        _mapper.Map(commentDto, existingComment);
        var updatedComment = await _commentRepo.UpdateCommentAsync(existingComment);
        var updatedCommentDto = _mapper.Map<CommentDto>(updatedComment);
        return Ok(updatedCommentDto);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var deletedComment = await _commentRepo.DeleteCommentAsync(id);
        if (deletedComment == null)
        {
            return NotFound("Comment does not exist.");
        }
        return NoContent();
    }
}