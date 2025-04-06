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

public static class ManagerEndpoints
{

    public static async void MapManagerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Manager").WithTags(nameof(Manager));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Managers.ToList();
            }

        })
        .WithName("GetAllManagers")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Managers.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetManagerById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Manager input) =>
        {
            using (var context = new CeContext())
            {
                Manager[] someManager = context.Managers.Where(m => m.Id == id).ToArray();
                context.Managers.Attach(someManager[0]);
                someManager[0].Fullname = input.Fullname;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateManager")
        .WithOpenApi();

        group.MapPost("/", async (Manager input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Managers.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateManager")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Managers.Add(std);
                Manager[] someManagers = context.Managers.Where(m => m.Id == id).ToArray();
                context.Managers.Attach(someManagers[0]);
                context.Managers.Remove(someManagers[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteManager")
        .WithOpenApi();
    }
}

