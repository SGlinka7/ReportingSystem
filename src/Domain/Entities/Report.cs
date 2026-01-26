namespace ReportingSystem.Domain.Entities;

using Domain.Enums;

public class Report : BaseAuditableEntity
{
    public string Title {get; set;} = string.Empty;

    public string? Description {get; set;}

    public ReportStatus Status {get; private set;} = ReportStatus.Draft;

    //Foreign key
    public  int CategoryId {get; set;}

    //Category navigation
    public ReportCategory Category {get; set;} = null!;

    public void Submit()
    {
        if(Status != ReportStatus.Draft)
            throw new InvalidOperationException("Only draft reports can be submitted.");

        Status = ReportStatus.Submitted;
        AddDomainEvent(new ReportSubmittedEvent(this));
    }

    public void Approve()
    {
        if(Status != ReportStatus.Submitted)
            throw new InvalidOperationException("Only submitted reports can be approved");

        Status = ReportStatus.Approved;
        AddDomainEvent(new ReportApprovedEvent(this));
    }

    public void Reject()
    {
        if(Status != ReportStatus.Submitted)
            throw new InvalidOperationException("Only submitted report can be rejected");

        Status = ReportStatus.Rejected;
    }
}