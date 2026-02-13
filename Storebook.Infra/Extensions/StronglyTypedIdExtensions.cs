using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Storebook.Infra;

public static class StronglyTypedIdExtensions
{
    public static PropertyBuilder<TStronglyTypedId> HasStronglyTypedIdConversion<TStronglyTypedId>(
        this PropertyBuilder<TStronglyTypedId> property)
        where TStronglyTypedId : struct
    {
        var valueProperty = typeof(TStronglyTypedId).GetProperty("Value")!;

        var converter = new ValueConverter<TStronglyTypedId, Guid>(
            id => (Guid)valueProperty.GetValue(id)!,
            value => (TStronglyTypedId)Activator.CreateInstance(typeof(TStronglyTypedId), value)!
        );

        return property.HasConversion(converter)
                       .ValueGeneratedNever();
    }
}
