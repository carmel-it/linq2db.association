using Carmel.Connect.Domain.Enums.Theme;
using Linq2db.AssociationIssue.Common;
using Linq2db.AssociationIssue.MemberAggregate;
using LinqToDB.Mapping;

namespace Linq2db.AssociationIssue.Configurations;

public class ThemeSettingsEntityConfiguration : IEntityConfiguration<ThemeSettings>
{
    public void Configure(FluentMappingBuilder builder)
    {
        builder
            .Entity<ThemeSettings>()
            // .HasSchemaName("Member")
            .HasTableName("ThemeSettings")
            .Property(e => e.Id).IsPrimaryKey().IsIdentity().HasColumnName(nameof(Entity.Id))
            .Property(e => e.Code).IsNotNull().HasColumnName("Code")
            .Property(e => e.MemberId).HasColumnName("MemberId")
            .Property(e => e.Theme).HasConversion(v => (int)v, v => (Theme)v).HasColumnName(nameof(ThemeSettings.Theme))
            .Property(e => e.SidebarBehavior).HasConversion(v => (int)v, v => (SidebarBehavior)v)
            .HasColumnName(nameof(ThemeSettings.SidebarBehavior))
            .Property(e => e.SidebarPosition).HasConversion(v => (int)v, v => (SidebarPosition)v)
            .HasColumnName(nameof(ThemeSettings.SidebarPosition))
            .Property(e => e.SidebarCompact).HasColumnName(nameof(ThemeSettings.SidebarCompact));
    }
}