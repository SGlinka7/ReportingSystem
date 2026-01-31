using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Domain.Entities;

namespace ReportingSystem.Application.Reports.Commands.CreateReport;

public record CreateReportCommand : IRequest<int>
{
    public required string Title {get; init; }
    public string? Description {get; init; }
    public int CategoryId {get; init; }
}

public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var report = new Report
        {
            Title = request.Title,
            Description = request.Description,
            CategoryId = request.CategoryId
        };

        _context.Reports.Add(report);
        await _context.SaveChangesAsync(cancellationToken);

        return report.Id;
    }
}