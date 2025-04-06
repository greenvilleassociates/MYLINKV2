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

public static class CompanyEndpoints
{

    public static async void MapCompanyEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Company").WithTags(nameof(Company));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Companies.ToList();
            }

        })
        .WithName("GetAllCompanies")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Companies.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetCompanyById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Company input) =>
        {
            using (var context = new CeContext())
            {
                Company[] someCompany = context.Companies.Where(m => m.Id == id).ToArray();
                context.Companies.Attach(someCompany[0]);
                someCompany[0].Companyname = input.Companyname;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateCompany")
        .WithOpenApi();

        group.MapPost("/", async (Company input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Companies.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateCompany")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Companies.Add(std);
                Company[] someCompanies = context.Companies.Where(m => m.Id == id).ToArray();
                context.Companies.Attach(someCompanies[0]);
                context.Companies.Remove(someCompanies[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteCompany")
        .WithOpenApi();
    }
}

