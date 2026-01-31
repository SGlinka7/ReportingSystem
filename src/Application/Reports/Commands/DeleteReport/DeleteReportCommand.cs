using MediatR;
using ReportingSystem.Application.Common.Exceptions;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Domain.Entities;

namespace ReportingSystem.Application.Reports.Commands.DeleteReport;

public record DeleteReportCommand(int Id) : IRequest;

public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _context.Reports.FindAsync(new object[] { request.Id }, cancellationToken);

        if (report == null)
        {
            throw new NotFoundException(nameof(Report), request.Id.ToString());
        }

        _context.Reports.Remove(report);
        await _context.SaveChangesAsync(cancellationToken);
    }
}