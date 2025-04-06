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

public static class UserlogEndpoints
{

    public static async void MapUserlogEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Userlog").WithTags(nameof(Userlog));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Userlogs.ToList();
            }

        })
        .WithName("GetAllUserlogs")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Userlogs.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetUserlogById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Userlog input) =>
        {
            using (var context = new CeContext())
            {
                Userlog[] someUserlog = context.Userlogs.Where(m => m.Id == id).ToArray();
                context.Userlogs.Attach(someUserlog[0]);
                someUserlog[0].Descr = input.Descr;
                someUserlog[0].Userid = input.Userid;
                someUserlog[0].Role = input.Role;                 
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateUserlog")
        .WithOpenApi();

        group.MapPost("/", async (Userlog input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Userlogs.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateUserlog")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Userlogs.Add(std);
                Userlog[] someUserlogs = context.Userlogs.Where(m => m.Id == id).ToArray();
                context.Userlogs.Attach(someUserlogs[0]);
                context.Userlogs.Remove(someUserlogs[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteUserlog")
        .WithOpenApi();
    }
}

