using MediatR;
using Microsoft.EntityFrameworkCore;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Application.Reports.Queries.GetReportById;
using ReportingSystem.Domain.Entities;
using ReportingSystem.Domain.Enums;

namespace ReportingSystem.Application.Reports.Queries.GetReportById;

public record GetReportByIdQuery(int Id) : IRequest<ReportDetailDto>;

public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDetailDto>
{
    private readonly IApplicationDbContext _context;

    public GetReportByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReportDetailDto> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
    {
        var report = await _context.Reports
        .Include(r => r.Category)
        .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if(report == null)
        {
            throw new NotFoundException(nameof(Report), request.Id.ToString());
        }

        return ReportDetailDto.FromEntity(report);
    }

}