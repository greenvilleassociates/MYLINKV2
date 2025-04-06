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

public static class CertrequirementsEndpoints
{

    public static async void MapCertrequirementsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Certrequirements").WithTags(nameof(Certrequirement));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Certrequirements.ToList();
            }

        })
        .WithName("GetAllCertrequirements")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Certrequirements.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetCertrequirementsById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Certrequirement input) =>
        {
            using (var context = new CeContext())
            {
                Certrequirement[] someCertrequirements = context.Certrequirements.Where(m => m.Id == id).ToArray();
                context.Certrequirements.Attach(someCertrequirements[0]);
                someCertrequirements[0].Certid = input.Certid;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateCertrequirements")
        .WithOpenApi();

        group.MapPost("/", async (Certrequirement input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Certrequirements.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateCertrequirements")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Certrequirements.Add(std);
                Certrequirement[] someCertrequirements = context.Certrequirements.Where(m => m.Id == id).ToArray();
                context.Certrequirements.Attach(someCertrequirements[0]);
                context.Certrequirements.Remove(someCertrequirements[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteCertrequirements")
        .WithOpenApi();
    }
}

