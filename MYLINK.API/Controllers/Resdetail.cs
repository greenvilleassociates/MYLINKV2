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

public static class ResdetailEndpoints
{

    public static async void MapResdetailEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Resdetail").WithTags(nameof(Resdetail));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Resdetails.ToList();
            }

        })
        .WithName("GetAllResdetails")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Resdetails.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetResdetailById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Resdetail input) =>
        {
            using (var context = new CeContext())
            {
                Resdetail[] someResdetail = context.Resdetails.Where(m => m.Id == id).ToArray();
                context.Resdetails.Attach(someResdetail[0]);
                someResdetail[0].Descr = input.Descr;
                someResdetail[0].Category = input.Category;
                someResdetail[0].Startdate = input.Startdate;
                someResdetail[0].Enddate = input.Enddate;
                someResdetail[0].Certauthority = input.Certauthority;
                someResdetail[0].Status = input.Status;
                someResdetail[0].Emplid = input.Emplid;
                someResdetail[0].Location = input.Location;
                someResdetail[0].Userid = input.Userid;
                someResdetail[0].Employee = input.Employee;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateResdetail")
        .WithOpenApi();

        group.MapPost("/", async (Resdetail input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Resdetails.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateResdetail")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Resdetails.Add(std);
                Resdetail[] someResdetails = context.Resdetails.Where(m => m.Id == id).ToArray();
                context.Resdetails.Attach(someResdetails[0]);
                context.Resdetails.Remove(someResdetails[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteResdetail")
        .WithOpenApi();
    }
}

