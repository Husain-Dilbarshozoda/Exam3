using Domain.Dtos;
using Domain.Models;
using Infrastructure.Response;

namespace Infrastructure.Interfaces;

public interface IProductsService
{
    Task<Responce<bool>> Create(CreateProductsDto products);
    Task<Responce<List<Products>>> GetAll();
    Task<Responce<Products>>? GetById(int id);
    Task<Responce<bool>> Update(Products products);
    Task<Responce<bool>> Delete(int id);
}