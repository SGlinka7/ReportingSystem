using MediatR;
using Microsoft.EntityFrameworkCore;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Domain.Enums;

namespace ReportingSystem.Application.Reports.Queries.GetReports;

public record GetReportsQuery(ReportStatus? Status = null) : IRequest<List<ReportBriefDto>>;

public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<ReportBriefDto>>
{
    private readonly IApplicationDbContext _context;

    public GetReportsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReportBriefDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Reports
        .Include(r => r.Category)
        .AsQueryable();

        if (request.Status.HasValue)
        {
            query = query.Where(r => r.Status == request.Status.Value);
        }

        var reports = await query
            .OrderByDescending(r => r.Created)
            .ToListAsync(cancellationToken);

        return reports.Select(ReportBriefDto.FromEntity).ToList();
    }
}