using Carmel.Connect.Domain.Enums.Theme;
using Linq2db.AssociationIssue.Common;

namespace Linq2db.AssociationIssue.MemberAggregate;

public class ThemeSettings(
    int id,
    int memberId,
    Theme theme,
    SidebarPosition sidebarPosition,
    SidebarBehavior sidebarBehavior,
    bool sidebarCompact) : Entity(id)
{
    public int MemberId { get; private set; } = memberId;
    public Theme Theme { get; set; } = theme;
    public SidebarPosition SidebarPosition { get; set; } = sidebarPosition;
    public SidebarBehavior SidebarBehavior { get; set; } = sidebarBehavior;
    public bool SidebarCompact { get; set; } = sidebarCompact;
}