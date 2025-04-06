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

public static class UsersessionEndpoints
{

    public static async void MapUsersessionEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Usersession").WithTags(nameof(Usersession));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Usersessions.ToList();
            }

        })
        .WithName("GetAllUsersessions")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Usersessions.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetUsersessionById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Usersession input) =>
        {
            using (var context = new CeContext())
            {
                Usersession[] someUsersession = context.Usersessions.Where(m => m.Id == id).ToArray();
                context.Usersessions.Attach(someUsersession[0]);
                someUsersession[0].Token = input.Token;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateUsersession")
        .WithOpenApi();

        group.MapPost("/", async (Usersession input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Usersessions.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateUsersession")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Usersessions.Add(std);
                Usersession[] someUsersessions = context.Usersessions.Where(m => m.Id == id).ToArray();
                context.Usersessions.Attach(someUsersessions[0]);
                context.Usersessions.Remove(someUsersessions[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteUsersession")
        .WithOpenApi();
    }
}

