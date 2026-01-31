using MediatR;
using Microsoft.Extensions.Logging;
using ReportingSystem.Domain.Events;

namespace ReportingSystem.Application.Reports.EventHandlers;

public class ReportSubmittedEventHandler : INotificationHandler<ReportSubmittedEvent>
{
    private readonly ILogger<ReportSubmittedEventHandler> _logger;

    public ReportSubmittedEventHandler(ILogger<ReportSubmittedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ReportSubmittedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Report {ReportId} was submitted.", notification.Report.Id);

        // Tu można dodać: wysłanie emaila, notyfikację, itp.

        return Task.CompletedTask;
    }
}