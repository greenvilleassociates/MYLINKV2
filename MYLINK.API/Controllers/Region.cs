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

public static class RegionEndpoints
{

    public static async void MapRegionEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Region").WithTags(nameof(Region));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Regions.ToList();
            }

        })
        .WithName("GetAllRegions")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Regions.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetRegionById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Region input) =>
        {
            using (var context = new CeContext())
            {
                Region[] someRegion = context.Regions.Where(m => m.Id == id).ToArray();
                context.Regions.Attach(someRegion[0]);
                someRegion[0].Description = input.Description;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateRegion")
        .WithOpenApi();

        group.MapPost("/", async (Region input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Regions.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateRegion")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Regions.Add(std);
                Region[] someRegions = context.Regions.Where(m => m.Id == id).ToArray();
                context.Regions.Attach(someRegions[0]);
                context.Regions.Remove(someRegions[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteRegion")
        .WithOpenApi();
    }
}

