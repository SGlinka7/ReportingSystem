namespace ReportingSystem.Domain.Entities;

public class ReportCategory : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<Report> Reports { get; private set; } = new List<Report>();
}