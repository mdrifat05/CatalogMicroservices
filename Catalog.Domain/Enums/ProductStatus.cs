using System.Runtime.Serialization;

namespace Catalog.Domain.Enums;

public enum ProductStatus
{
    [EnumMember(Value = "In Stock")]
    InStock,
    [EnumMember(Value = "Out of Stock")]
    OutOfStock,
    [EnumMember(Value = "Archived")]
    Archived
}
