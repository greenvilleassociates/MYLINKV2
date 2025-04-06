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

public static class GEMEndpoints
{
    
    public static async void MapGEMEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/GEM").WithTags(nameof(Gagridconfig));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Gagridconfigs.ToList();
            }

        })
        .WithName("GetAllGEMs")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Gagridconfigs.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetGEMById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Gagridconfig input) =>
        {
            using (var context = new CeContext())
            {
                Gagridconfig[] someGEM = context.Gagridconfigs.Where(m => m.Id == id).ToArray();
                context.Gagridconfigs.Attach(someGEM[0]);
                someGEM[0].Nodeid = input.Nodeid;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateGEM")
        .WithOpenApi();

        group.MapPost("/", async (Gagridconfig input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                input.Nodeid = dice;
                context.Gagridconfigs.Add(input);
                await context.SaveChangesAsync();                     
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateGEM")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.GEMs.Add(std);
                Gagridconfig[] someGEMs = context.Gagridconfigs.Where(m => m.Id == id).ToArray();
                context.Gagridconfigs.Attach(someGEMs[0]);
                context.Gagridconfigs.Remove(someGEMs[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteGEM")
        .WithOpenApi();
    }
}

   