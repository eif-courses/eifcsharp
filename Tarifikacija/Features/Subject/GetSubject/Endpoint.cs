using FastEndpoints;

namespace Tarifikacija.Features.Subject.GetSubject;

sealed class Endpoint : Endpoint<Request, Response>
{
    private readonly AppDbContext _dbContext;

    public Endpoint(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/subject/get-subject/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var subjectId = r.Id;
        var subject = await _dbContext.Subjects.FindAsync(subjectId);

        if (subject != null)
        {
            var response = new Response(subject.Title, subject.Description);
            await SendAsync(response, 200, c);
        }
        else
        {
            await SendAsync(new Response("Not found", "Wrong id or not exists"), 404, c);
        }
        
        
    }
}