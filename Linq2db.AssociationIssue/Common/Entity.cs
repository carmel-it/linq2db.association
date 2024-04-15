namespace Linq2db.AssociationIssue.Common;

// https://www.c-sharpcorner.com/article/guid-vs-sequential-integers-a-great-debate-in-database-design
public abstract class Entity(int id, Guid? code = null)
{
    public int Id { get; } = id;
    public Guid Code { get; } = code ?? Guid.NewGuid();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) return false;

        return ((Entity)obj).Id == Id || ((Entity)obj).Code == Code;
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }
}