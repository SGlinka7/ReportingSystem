using ReportingSystem.Domain.Entities;
using ReportingSystem.Domain.Enums;

namespace ReportingSystem.Application.Reports.Queries.GetReportById;

public class ReportDetailDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public ReportStatus Status { get; init; }
    public int? CategoryId { get; init; }
    public string? CategoryName { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset LastModified { get; init; }
    public string? Description { get; init; }

    public static ReportDetailDto FromEntity(Report report)
    {
        return new ReportDetailDto
        {
            Id = report.Id,
            Title = report.Title,
            Status = report.Status,
            CategoryId = report.CategoryId,
            Created = report.Created,
            LastModified = report.LastModified,
            Description = report.Description
        };
    }
}