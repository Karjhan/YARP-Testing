using Commons.Primitives;

namespace Reports_API.Domain.Entities;

public class Report(Guid id) : Entity(id)
{
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public DateTime DateCreated { get; private set; }
    
    public DateTime LastUpdated { get; private set; }

    public Report(
        Guid id, 
        string title, 
        string description) : this(id)
    {
        Title = title;
        Description = description;
        DateCreated = DateTime.UtcNow;
        LastUpdated = DateTime.UtcNow;
    }

    public static Report Create(
        Guid id,
        string title,
        string description
    )
    {
        Report report = new Report(id, title, description);

        return report;
    }

    public void Update(string newTitle, string newDescription)
    {
        Title = newTitle;
        Description = newDescription;
        LastUpdated = DateTime.UtcNow;
    }
}