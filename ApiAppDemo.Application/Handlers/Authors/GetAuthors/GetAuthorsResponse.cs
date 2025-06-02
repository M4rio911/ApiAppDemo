using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthors;

public class GetAuthorsResponse : BaseResponse
{
    public IEnumerable<Author?> Authors{ get; set; }
    public GetAuthorsResponse() : base() { }
    public GetAuthorsResponse(List<string> errors) : base(errors) { }
}
