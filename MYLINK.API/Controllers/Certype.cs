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

public static class CerttypeEndpoints
{

    public static async void MapCerttypeEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Certtype").WithTags(nameof(Certtype));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Certtypes.ToList();
            }

        })
        .WithName("GetAllCerttypes")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Certtypes.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetCerttypeById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Certtype input) =>
        {
            using (var context = new CeContext())
            {
                Certtype[] someCerttype = context.Certtypes.Where(m => m.Id == id).ToArray();
                context.Certtypes.Attach(someCerttype[0]);
                someCerttype[0].Description = input.Description;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateCerttype")
        .WithOpenApi();

        group.MapPost("/", async (Certtype input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Certtypes.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateCerttype")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Certtypes.Add(std);
                Certtype[] someCerttypes = context.Certtypes.Where(m => m.Id == id).ToArray();
                context.Certtypes.Attach(someCerttypes[0]);
                context.Certtypes.Remove(someCerttypes[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteCerttype")
        .WithOpenApi();
    }
}

