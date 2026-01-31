using MediatR;
using ReportingSystem.Application.Common.Exceptions;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Domain.Entities;

namespace ReportingSystem.Application.Reports.Commands.ApproveReport;

public record ApproveReportCommand(int Id) : IRequest;

public class ApproveReportCommandHandler : IRequestHandler<ApproveReportCommand>
{
    private readonly IApplicationDbContext _context;

    public ApproveReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ApproveReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _context.Reports.FindAsync(new object[] { request.Id }, cancellationToken);

        if (report == null)
        {
            throw new NotFoundException(nameof(Report), request.Id.ToString());
        }

        report.Approve();

        await _context.SaveChangesAsync(cancellationToken);
    }
}