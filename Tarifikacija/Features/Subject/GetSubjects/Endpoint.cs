using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Tarifikacija.Features.Subject.GetSubjects;

sealed class Endpoint : EndpointWithoutRequest<Response>
{
    
    private readonly AppDbContext _dbContext;

    public Endpoint(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public override void Configure()
    {
        Get("/subject/get-subjects");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        var subjects = await _dbContext.Subjects.ToListAsync(c);
        
        await SendOkAsync(new Response
        { 
            Subjects = subjects
        }, c);
        
    }
}