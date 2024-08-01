using Tarifikacija.Entities;

namespace Tarifikacija.Features.Subject.GetSubjects;

internal sealed class Response
{
    public List<SubjectEntity> Subjects { get; set; }
}