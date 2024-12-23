using System.Net;
using Dapper;
using Domain.Dtos;
using Domain.Models;
using Infrastructure.DataContaxt;
using Infrastructure.Interfaces;
using Infrastructure.Response;

namespace Infrastructure.Services;

public class ProductsService(IConTaxt conTaxt):IProductsService
{
    public async Task<Responce<bool>> Create(CreateProductsDto products)
    {
        using var connection = conTaxt.Connection();
        var sql = "insert into Products(Name,Description,Price,StockQuantity,CategoryName,CreatedDate) values(@Name,@Description,@Price,@StockQuantity,@CategoryName,@CreatedDate);";
        var res =await connection.ExecuteAsync(sql,products);
        if (res == 0)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Responce<bool>(true);
    }

    public async Task<Responce<List<Products>>> GetAll()
    {
        using var connection = conTaxt.Connection();
        var sql = "select * from Products";
        var res = (await connection.QueryAsync<Products>(sql)).ToList();
        return new Responce<List<Products>>(res);
    }

    public async Task<Responce<Products>>? GetById(int id)
    {
        using var connection = conTaxt.Connection();
        var sql = "select * from Products where id=@ID";
        var res = await connection.QueryFirstOrDefaultAsync<Products>(sql, new { ID = id });
        return new Responce<Products>(res);
    }

    public async Task<Responce<bool>> Update(Products products)
    {
        using var connection = conTaxt.Connection();
        var sql = "update Products set Name=@Name,Description=@Description,Price=@Price,StockQuantity=@StockQuantity,CategoryName=@CategoryName,CreatedDate=@CreatedDate where id=Id;";
        var res = await connection.ExecuteAsync(sql, products);
        if (res == 0)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Responce<bool>(true);
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        using var connection = conTaxt.Connection();
        var sql = "delete from Products where id=@ID";
        var res = await connection.ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Responce<bool>(true);
    }
}