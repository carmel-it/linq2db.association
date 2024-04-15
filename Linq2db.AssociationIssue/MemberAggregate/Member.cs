using Linq2db.AssociationIssue.Common;

namespace Linq2db.AssociationIssue.MemberAggregate;

public class Member(int id, Guid externalId, string name, string email, ThemeSettings? settings) : AggregateRoot(id)
{
    public Guid ExternalId { get; private set; } = externalId;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;

    // Associations
    public ThemeSettings? ThemeSettings { get; set; } = settings;
}