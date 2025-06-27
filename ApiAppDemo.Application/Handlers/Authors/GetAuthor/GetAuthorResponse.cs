using ApiAppDemo.Application.Dto.Authors;
using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthor;

public class GetAuthorResponse : BaseResponse
{
    public AuthorDto? Author{ get; set; }
    public GetAuthorResponse() : base() { }
    public GetAuthorResponse(List<string> errors) : base(errors) { }
    public GetAuthorResponse(string error) : base(error) { }
}
