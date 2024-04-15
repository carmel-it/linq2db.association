using Linq2db.AssociationIssue.Configurations;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace Linq2db.AssociationIssue.Data;

public class CarmelContext : DataConnection
{
    static CarmelContext()
    {
        var builder = new FluentMappingBuilder(ContextSchema);

        var assembly = typeof(IEntityConfiguration<>).Assembly;
        var types = assembly.GetTypes();
        var entityConfigurationTypes = types.Where(t =>
            t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityConfiguration<>)));

        foreach (var type in entityConfigurationTypes)
        {
            var instance = Activator.CreateInstance(type);
            var configureMethod = type.GetMethod("Configure");

            if (instance != null && configureMethod != null) configureMethod.Invoke(instance, [builder]);
        }

        builder.Build();
    }

    public CarmelContext()
        : base(new DataOptions().UseMappingSchema(ContextSchema))
    {
    }

    public CarmelContext(DataOptions<CarmelContext> options)
        : base(options.Options.UseMappingSchema(ContextSchema))
    {
    }

    private static MappingSchema ContextSchema { get; } = new();
}