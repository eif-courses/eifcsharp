using FastEndpoints;
using Tarifikacija.Entities;
namespace Tarifikacija.Features.Subject.CreateSubject;


sealed class Mapper: Mapper<Request, Response, SubjectEntity>
{
    public override SubjectEntity ToEntity(Request r)
    {
        return new()
        {
            Title = r.Title,
            Description = r.Description
        };
    }
    
}