using ReportingSystem.Domain.Entities;
using ReportingSystem.Domain.Enums;

namespace ReportingSystem.Application.Reports.Queries.GetReports;

public class ReportBriefDto
{
    public int Id {get; init; }
    public required string Title {get; init; }
    
    public ReportStatus Status {get; init; }
    public DateTimeOffset Created {get; init; }

    public static ReportBriefDto FromEntity(Report report)
    {
        return new ReportBriefDto
        {
            Id = report.Id,
            Title = report.Title,
            Status = report.Status,
            Created = report.Created,
        };
    }
}