using ReportingSystem.Domain.Entities;

namespace ReportingSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Report> Reports { get; }
    
    DbSet<ReportCategory> ReportCategories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
