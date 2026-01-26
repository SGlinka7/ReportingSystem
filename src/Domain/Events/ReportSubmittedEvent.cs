namespace ReportingSystem.Domain.Events;

public class ReportSubmittedEvent : BaseEvent 
{
    public ReportSubmittedEvent (Report report)
    {
        Report = report;
    }

    public Report Report { get; }
}