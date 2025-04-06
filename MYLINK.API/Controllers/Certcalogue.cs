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

public static class CertcalogueEndpoints
{

    public static async void MapCertcalogueEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Certcalogue").WithTags(nameof(Certcalogue));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Certcalogues.ToList();
            }

        })
        .WithName("GetAllCertcalogues")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Certcalogues.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetCertcalogueById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Certcalogue input) =>
        {
            using (var context = new CeContext())
            {
                Certcalogue[] someCertcalogue = context.Certcalogues.Where(m => m.Id == id).ToArray();
                context.Certcalogues.Attach(someCertcalogue[0]);
                someCertcalogue[0].Description = input.Description;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateCertcalogue")
        .WithOpenApi();

        group.MapPost("/", async (Certcalogue input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Certcalogues.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateCertcalogue")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Certcalogues.Add(std);
                Certcalogue[] someCertcalogues = context.Certcalogues.Where(m => m.Id == id).ToArray();
                context.Certcalogues.Attach(someCertcalogues[0]);
                context.Certcalogues.Remove(someCertcalogues[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteCertcalogue")
        .WithOpenApi();
    }
}

