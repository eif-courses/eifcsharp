using FastEndpoints;

namespace Tarifikacija.Features.Subject.CreateSubject;

sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    private readonly AppDbContext _dbContext;
    public Endpoint(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Configure()
    {
        Post("/subject/create-subject");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var subject = Map.ToEntity(r);
        
        _dbContext.Subjects.Add(subject);
        await _dbContext.SaveChangesAsync(c);

        var response = new Response($"Dalykas {subject.Title} sėkmingai sukurtas!");
        
        await SendAsync(response,200, c);
    }
}