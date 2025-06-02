using ApiAppDemo.Application.Handlers.BaseModel;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthor;

public class GetAuthorResponse : BaseResponse
{
    public Author? Author{ get; set; }
    public GetAuthorResponse() : base() { }
    public GetAuthorResponse(List<string> errors) : base(errors) { }
}
