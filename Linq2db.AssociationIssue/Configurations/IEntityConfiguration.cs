using Linq2db.AssociationIssue.Common;
using LinqToDB.Mapping;

namespace Linq2db.AssociationIssue.Configurations;

public interface IEntityConfiguration<T> where T : Entity
{
    void Configure(FluentMappingBuilder builder);
}