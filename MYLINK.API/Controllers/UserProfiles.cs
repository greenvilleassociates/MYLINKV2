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

public static class UserprofileEndpoints
{

    public static async void MapUserprofileEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Userprofile").WithTags(nameof(Userprofile));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Userprofiles.ToList();
            }

        })
        .WithName("GetAllUserprofiles")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Userprofiles.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetUserprofileById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Userprofile input) =>
        {
            using (var context = new CeContext())
            {
                Userprofile[] someUserprofile = context.Userprofiles.Where(m => m.Id == id).ToArray();
                context.Userprofiles.Attach(someUserprofile[0]);
                someUserprofile[0].Address1 = input.Address1;
                someUserprofile[0].Address2 = input.Address2;
                someUserprofile[0].City = input.City;
                someUserprofile[0].Stateregion = input.Stateregion;
                someUserprofile[0].Country = input.Country;
                someUserprofile[0].Phone = input.Phone;
                someUserprofile[0].Cellphone = input.Cellphone;
                someUserprofile[0].Sms = input.Sms;
                someUserprofile[0].Email = input.Email;
                someUserprofile[0].Maritalstatus = input.Maritalstatus;
                someUserprofile[0].University1 = input.University1;
                someUserprofile[0].University2 = input.University2;
                someUserprofile[0].Linkedinurl = input.Linkedinurl;
                someUserprofile[0].Instagramurl = input.Instagramurl;
                someUserprofile[0].Vimeourl = input.Vimeourl;
                someUserprofile[0].Facebookurl = input.Facebookurl;
                someUserprofile[0].Googleurl = input.Googleurl;
                someUserprofile[0].Employeeid = input.Employeeid;
                someUserprofile[0].Postalzip = input.Postalzip;
                someUserprofile[0].Userid = input.Userid;
                someUserprofile[0].Activepictureurl = input.Activepictureurl;
                someUserprofile[0].Title2 = input.Title2;
                someUserprofile[0].Pronoun = input.Pronoun;
                someUserprofile[0].Title = input.Title;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateUserprofile")
        .WithOpenApi();

        group.MapPost("/", async (Userprofile input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                //input.Id = dice;
                context.Userprofiles.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateUserprofile")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Userprofiles.Add(std);
                Userprofile[] someUserprofiles = context.Userprofiles.Where(m => m.Id == id).ToArray();
                context.Userprofiles.Attach(someUserprofiles[0]);
                context.Userprofiles.Remove(someUserprofiles[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteUserprofile")
        .WithOpenApi();
    }
}

