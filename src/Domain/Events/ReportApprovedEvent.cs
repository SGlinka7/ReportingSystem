namespace ReportingSystem.Domain.Events;

public class ReportApprovedEvent : BaseEvent
{
    public ReportApprovedEvent (Report report)
    {
        Report = report;
    }

    public Report Report { get; }
}