using MediatR;
using ReportingSystem.Application.Common.Exceptions;
using ReportingSystem.Application.Common.Interfaces;
using ReportingSystem.Domain.Entities;
using ReportingSystem.Domain.Enums;

namespace ReportingSystem.Application.Reports.Commands.UpdateReport;

public record UpdateReportCommand : IRequest
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public int CategoryId { get; init; }
}  

public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand>
{
    private readonly IApplicationDbContext _context;
    
    public UpdateReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(UpdateReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _context.Reports.FindAsync(new object[] { request.Id }, cancellationToken);

        if(report == null)
        {
            throw new NotFoundException(nameof(Report), request.Id.ToString());
        }

        //Only draft is editable
        if (report.Status != ReportStatus.Draft)
        {
            throw new InvalidOperationException("Only draft reports can be edited.");
        }

        report.Title = request.Title;
        report.Description = request.Description;
        report.CategoryId = request.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}