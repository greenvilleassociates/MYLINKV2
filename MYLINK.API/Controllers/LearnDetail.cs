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

public static class LearndetailEndpoints
{

    public static async void MapLearndetailEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Learndetail").WithTags(nameof(Learndetail));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Learndetails.ToList();
            }

        })
        .WithName("GetAllLearndetails")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Learndetails.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetLearndetailById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Learndetail input) =>
        {
            using (var context = new CeContext())
            {
                Learndetail[] someLearndetail = context.Learndetails.Where(m => m.Id == id).ToArray();
                context.Learndetails.Attach(someLearndetail[0]);
                someLearndetail[0].Description = input.Description;
                someLearndetail[0].Userid = input.Userid;
                someLearndetail[0].Employeeidasint = input.Employeeidasint;
                someLearndetail[0].Employee = input.Employee;
                someLearndetail[0].Employeeid = input.Employeeid;
                someLearndetail[0].Learningmodulesid = input.Learningmodulesid;
                someLearndetail[0].Cataloguesku = input.Cataloguesku;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateLearndetail")
        .WithOpenApi();

        group.MapPost("/", async (Learndetail input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Learndetails.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateLearndetail")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Learndetails.Add(std);
                Learndetail[] someLearndetails = context.Learndetails.Where(m => m.Id == id).ToArray();
                context.Learndetails.Attach(someLearndetails[0]);
                context.Learndetails.Remove(someLearndetails[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteLearndetail")
        .WithOpenApi();
    }
}

