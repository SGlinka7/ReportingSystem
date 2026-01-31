using MediatR;
using ReportingSystem.Application.Common.Exceptions;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Domain.Entities;

namespace ReportingSystem.Application.Reports.Commands.RejectReport;

public record RejectReportCommand(int Id) : IRequest;

public class RejectReportCommandHandler : IRequestHandler<RejectReportCommand>
{
    private readonly IApplicationDbContext _context;

    public RejectReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RejectReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _context.Reports.FindAsync(new object[] { request.Id }, cancellationToken);

        if (report == null)
        {
            throw new NotFoundException(nameof(Report), request.Id.ToString());
        }

        report.Reject();

        await _context.SaveChangesAsync(cancellationToken);
    }
}