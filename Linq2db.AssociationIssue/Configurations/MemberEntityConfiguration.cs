using Linq2db.AssociationIssue.MemberAggregate;
using LinqToDB.Mapping;

namespace Linq2db.AssociationIssue.Configurations;

public class MemberEntityConfiguration : IEntityConfiguration<Member>
{
    public void Configure(FluentMappingBuilder builder)
    {
        builder
            .Entity<Member>()
            // .HasSchemaName("Member")
            .HasTableName("Member")
            .Property(e => e.Id).IsPrimaryKey().IsIdentity().HasColumnName("Id")
            .Property(e => e.Code).IsNotNull().HasColumnName("Code")
            .Property(e => e.ExternalId).IsNotNull().HasColumnName("ExternalId")
            .Property(e => e.Name).IsNotNull().HasColumnName("Name")
            .Property(e => e.Email).IsNotNull().HasColumnName("Email")
            .Property(e => e.ThemeSettings).Association(e => e.ThemeSettings, e => e.Id, c => c!.MemberId, true);
    }
}