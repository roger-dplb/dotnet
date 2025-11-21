using AutoMapper;
using meta.Models;
using meta.Dtos.Comment;

namespace meta.Mappers;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>();
    }
}