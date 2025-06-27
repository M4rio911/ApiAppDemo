using ApiAppDemo.Application.Dto.Authors;
using ApiAppDemo.Application.Handlers.BaseModel;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthors;

public class GetAuthorsResponse : BaseResponse
{
    public IEnumerable<AuthorDto?> Authors{ get; set; }
    public GetAuthorsResponse() : base() { }
    public GetAuthorsResponse(List<string> errors) : base(errors) { }
}
