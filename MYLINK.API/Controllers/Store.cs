using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using Enterprise.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http;
namespace somecontrollers.Controllers;

public static class StoreEndpoints
{

    public static async void MapStoreEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Store").WithTags(nameof(Store));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Stores.ToList();
            }

        })
        .WithName("GetAllStores")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Stores.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetStoreById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Store input) =>
        {
            using (var context = new CeContext())
            {
                Store[] someStore = context.Stores.Where(m => m.Id == id).ToArray();
                context.Stores.Attach(someStore[0]);
                someStore[0].Description = input.Description;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateStore")
        .WithOpenApi();

        group.MapPost("/", async (Store input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Stores.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateStore")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Stores.Add(std);
                Store[] someStores = context.Stores.Where(m => m.Id == id).ToArray();
                context.Stores.Attach(someStores[0]);
                context.Stores.Remove(someStores[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteStore")
        .WithOpenApi();
    }
}

