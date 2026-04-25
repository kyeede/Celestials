using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Extensions;

internal static class ConversionExtensions
{
    extension(PropertyBuilder<ulong> propertyBuilder)
    {
        public PropertyBuilder<ulong> HasSnowflakeConversion()
        {
            return propertyBuilder.HasConversion(toProvider => unchecked((long)toProvider), fromProvider => unchecked((ulong)fromProvider));
        }
    }

    extension(PropertyBuilder<ulong?> propertyBuilder)
    {
        public PropertyBuilder<ulong?> HasNullableSnowflakeConversion()
        {
            return propertyBuilder.HasConversion(
                toProvider => toProvider.HasValue ? unchecked((long?)toProvider.Value) : null,
                fromProvider => fromProvider.HasValue ? unchecked((ulong?)fromProvider.Value) : null
            );
        }
    }
}
