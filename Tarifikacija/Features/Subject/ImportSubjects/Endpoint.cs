using FastEndpoints;

namespace Tarifikacija.Features.Subject.ImportSubjects;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/subject/import-subjects");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        await SendAsync(new Response
        {
            Id = 2,
            Title = "Programavimas C#"
        });
    }
   
}