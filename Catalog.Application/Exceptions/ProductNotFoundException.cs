﻿using BuildingBlocks.Exceptions;

namespace Catalog.Application.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id) : base($"Product", id)
    {

    }
}
