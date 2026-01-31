using MediatR;
using ReportingSystem.Application.Common.Exceptions;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Domain.Entities;

namespace ReportingSystem.Application.Reports.Commands.SubmitReport;

public record SubmitReportCommand(int Id) : IRequest;

public class SubmitReportCommandHandler : IRequestHandler<SubmitReportCommand>
{
    private readonly IApplicationDbContext _context;

    public SubmitReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SubmitReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _context.Reports.FindAsync(new object[] { request.Id }, cancellationToken);

        if (report == null)
        {
            throw new NotFoundException(nameof(Report), request.Id.ToString());
        }

        // Wywołuje metodę domenową (rzuci wyjątek jeśli nie Draft)
        report.Submit();

        await _context.SaveChangesAsync(cancellationToken);
    }
}