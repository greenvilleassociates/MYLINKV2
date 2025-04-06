using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using Enterprise.Models;
namespace somecontrollers.Controllers;

public static class EmployeeEndpoints
{

    public static async void MapEmployeeEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Employee").WithTags(nameof(Employee));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Employees.ToList();
            }

        })
        .WithName("GetAllEmployees")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Employees.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetEmployeeById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Employee input) =>
        {
            using (var context = new CeContext())
            {
                Employee[] someEmployee = context.Employees.Where(m => m.Id == id).ToArray();
                context.Employees.Attach(someEmployee[0]);
                someEmployee[0].Employeeid = input.Employeeid;
                someEmployee[0].Employeetenure = input.Employeetenure;
                someEmployee[0].EmployeeEmail = input.EmployeeEmail;
                someEmployee[0].Employeestartdate = input.Employeestartdate;
                someEmployee[0].EmployeeReturndate = input.EmployeeReturndate;
                someEmployee[0].Hrid = input.Hrid;
                someEmployee[0].Hrsystemconstring = input.Hrsystemconstring;
                someEmployee[0].Fullname = input.Fullname;
                someEmployee[0].Userid = input.Userid;
                someEmployee[0].Userprofileid = input.Userprofileid;
                context.SaveChanges();
                //await context.SaveChangesAsync();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateEmployee")
        .WithOpenApi();

        group.MapPost("/", async (Employee input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                input.Id = dice;
                context.Employees.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateEmployee")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Employees.Add(std);
                Employee[] someEmployees = context.Employees.Where(m => m.Id == id).ToArray();
                context.Employees.Attach(someEmployees[0]);
                context.Employees.Remove(someEmployees[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteEmployee")
        .WithOpenApi();
    }
}

