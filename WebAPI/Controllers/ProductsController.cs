using Domain.Dtos;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductsService productsService):ControllerBase
{

    [HttpPost]
    public async Task<Responce<bool>> Create(CreateProductsDto products)
    {
        return await productsService.Create(products);
    }

    [HttpGet]
    public async Task<Responce<List<Products>>> GetAll()
    {
        return await productsService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<Responce<Products>>? GetById(int id)
    {
        return await productsService.GetById(id);
    }

    [HttpPut]
    public async Task<Responce<bool>> Update(Products products)
    {
        return await productsService.Update(products);
    }

    [HttpDelete]
    public async Task<Responce<bool>> Delete(int id)
    {
        return await productsService.Delete(id);
    }    
}