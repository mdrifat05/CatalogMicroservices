using Catalog.Application.Dtos;
using Catalog.Application.Pagination;
using Catalog.Application.Products.Commands.CreateProduct;
using Catalog.Application.Products.Commands.DeleteProduct;
using Catalog.Application.Products.Commands.UpdateProduct;
using Catalog.Application.Products.Queries.GetProductById;
using Catalog.Application.Products.Queries.GetProducts;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

public sealed record CreateProductRequest(ProductDto ProductDto);

public sealed record CreateProductResponse(Guid Id);

public sealed record UpdateProductRequest(ProductDto ProductDto);

public sealed record UpdateProductResponse(bool IsSuccess);

public sealed record DeleteProductResponse(bool IsSuccess);

public sealed record GetByIdProductResponse(ProductDto Product);

public sealed record GetProductResponse(PaginatedResult<ProductDto> Product);


[Route("api/[controller]")]
[ApiController]
public class ProductController(ISender sender) : ControllerBase
{

    // GET api/product
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaginationRequest request)
    {
        var result = await sender.Send(new GetProductsQuery(request));
        var response = result.Adapt<GetProductResponse>();
        return Ok(response);
    }

    // GET api/product/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await sender.Send(new GetProductByIdQuery(id));
        var response = result.Adapt<GetByIdProductResponse>();
        return Ok(response);
    }

    // POST api/product
    [HttpPost]
    public async Task<IActionResult> Post(CreateProductRequest request)
    {
        var command = request.Adapt<CreateProductCommand>();
        var result = await sender.Send(command);

        var response = result.Adapt<CreateProductResponse>();
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    // PUT api/product
    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductRequest request)
    {
        var command = request.Adapt<UpdateProductCommand>();
        var result = await sender.Send(command);
        var response = result.Adapt<UpdateProductResponse>();
        return Ok(response);
    }

    // DELETE api/product/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await sender.Send(new DeleteProductCommand(id));
        var response = result.Adapt<DeleteProductResponse>();
        return Ok(response);
    }
}