using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using Azure.Messaging.ServiceBus;
using Enterprise.Models;
using Services;
using Newtonsoft.Json;
namespace somecontrollers.Controllers;

public static class CertificationEndpoints
{

    public static async void MapCertificationEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Certification").WithTags(nameof(Certification));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Certifications.ToList();
            }

        })
        .WithName("GetAllCertifications")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Certifications.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetCertificationById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", async (int id, Certification input, ServiceBusService serviceBusService) =>
        {
            using (var context = new CeContext())
            {
                Certification[] someCertification = context.Certifications.Where(m => m.Id == id).ToArray();
                context.Certifications.Attach(someCertification[0]);
                someCertification[0].Employee = input.Employee;
                someCertification[0].Employeeid = input.Employeeid;
                someCertification[0].EmployeeEmail = input.EmployeeEmail;
                someCertification[0].Certname = input.Certname;
                someCertification[0].Revision = input.Revision;
                someCertification[0].Certdate = input.Certdate;
                someCertification[0].Revisedate = input.Revisedate;
                someCertification[0].Bu = input.Bu;
                someCertification[0].Comments = input.Comments;
                someCertification[0].Certificationbloburl = input.Certificationbloburl;
                someCertification[0].Certlevel = input.Certlevel;
                someCertification[0].Userid = input.Userid;
                someCertification[0].Fullname = input.Fullname;
                someCertification[0].Certype = input.Certype;
                context.SaveChanges();
                //await context.SaveChangesAsync();

                var messageObject = new
                {
                    email = input.EmployeeEmail,
                    subject = "Certification " + input.Certname + " has been updated!",
                    body = "Congratulations! Certification " + input.Certname + " has been updated for " + input.Fullname + "!\n\n" +
                           "Certification Date: " + input.Certdate + "\n" +
                           "Expiration Date: " + input.Revisedate + "\n" +
                           "Certification Level: " + input.Certlevel + "\n"
                };

                string jsonMessage = JsonConvert.SerializeObject(messageObject);

                await serviceBusService.SendMessageAsync(jsonMessage);

                return TypedResults.Accepted("Updated ID:" + input.Id);

            }


        })
        .WithName("UpdateCertification")
        .WithOpenApi();

        group.MapPost("/", async (Certification input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Certifications.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
     .WithName("CreateCertification")
     .WithOpenApi();



        group.MapPost("/notify", async (Certification input, ServiceBusService serviceBusService) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                // input.Id = dice;
                context.Certifications.Add(input);
                await context.SaveChangesAsync();

                var messageObject = new
                {
                    email = input.EmployeeEmail,
                    subject = "Certification " + input.Certname + " has been created!",
                    body = "Congratulations! Certification " + input.Certname + " has been created for " + input.Fullname + "!\n\n" +
                           "Certification Date: " + input.Certdate + "\n" +
                           "Expiration Date: " + input.Revisedate + "\n" +
                           "Certification Level: " + input.Certlevel + "\n"
                };

                string jsonMessage = JsonConvert.SerializeObject(messageObject);

                await serviceBusService.SendMessageAsync(jsonMessage);

                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateCertificationNotify")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Certifications.Add(std);
                Certification[] someCertifications = context.Certifications.Where(m => m.Id == id).ToArray();
                context.Certifications.Attach(someCertifications[0]);
                context.Certifications.Remove(someCertifications[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteCertification")
        .WithOpenApi();
    }
}

