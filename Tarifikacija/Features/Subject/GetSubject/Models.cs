
namespace Tarifikacija.Features.Subject.GetSubject;

sealed record Request(int Id);
sealed record Response(string Title, string Description);

