using Catalog.Application.Dtos;

namespace Catalog.Api.Models.Products;

public sealed record UpdateProductRequest(ProductDto ProductDto);
