using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using Enterprise.Models;
namespace somecontrollers.Controllers;

public static class UserEndpoints
{

    public static async void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Users").WithTags(nameof(User));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Users.ToList();
            }

        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Users.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetUserById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, User input) =>
        {
            using (var context = new CeContext())
            {
                User[] someUser = context.Users.Where(m => m.Id == id).ToArray();
                context.Users.Attach(someUser[0]);
                someUser[0].Lastname = input.Lastname;
                someUser[0].Firstname = input.Firstname;
                someUser[0].Username = input.Username;
                someUser[0].Email = input.Email;
                someUser[0].Employee = input.Employee;
                someUser[0].Employeeid = input.Employeeid;
                someUser[0].Microsoftid = input.Microsoftid;
                someUser[0].Ncrid = input.Ncrid;
                someUser[0].Oracleid = input.Oracleid;
                someUser[0].Azureid = input.Azureid;
                someUser[0].Plainpassword = input.Plainpassword;
                someUser[0].Hashedpassword = input.Hashedpassword;
                someUser[0].Passwordtype = input.Passwordtype;
                someUser[0].Jid = input.Jid;
                someUser[0].Profileurl = input.Profileurl;
                someUser[0].Role = input.Role;
                someUser[0].Fullname = input.Fullname;
                someUser[0].ResetToken = input.ResetToken;
                someUser[0].ResetTokenExpiration = input.ResetTokenExpiration;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateUser")
        .WithOpenApi();

        group.MapPost("/", async (User input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                input.Id = dice;
                context.Users.Add(input);
                await context.SaveChangesAsync();
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateUser")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Users.Add(std);
                User[] someUsers = context.Users.Where(m => m.Id == id).ToArray();
                context.Users.Attach(someUsers[0]);
                context.Users.Remove(someUsers[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteUser")
        .WithOpenApi();

        group.MapGet("/userjoin", () =>
        {
            using (var context = new CeContext())
            {
                var result = context.Users
                    .Join(
                        context.Userprofiles,
                        user => user.Id,
                        profile => profile.Userid,
                        (user, profile) => new
                        {
                            UserId = user.Id,
                            Username = user.Username,
                            Fullname = user.Fullname,
                            Email = user.Email,
                            Role = user.Role,
                            ProfileUrl = user.Profileurl,
                            
                            // UserProfile data
                            Address1 = profile.Address1,
                            Address2 = profile.Address2,
                            City = profile.City,
                            StateRegion = profile.Stateregion,
                            Country = profile.Country,
                            Phone = profile.Phone,
                            Cellphone = profile.Cellphone,
                            MaritalStatus = profile.Maritalstatus,
                            University1 = profile.University1,
                            LinkedinUrl = profile.Linkedinurl,
                            InstagramUrl = profile.Instagramurl,
                            FacebookUrl = profile.Facebookurl,
                            GoogleUrl = profile.Googleurl,
                            Title = profile.Title,
                            Pronoun = profile.Pronoun,
                            ActivePictureUrl = profile.Activepictureurl,
                            PostalZip = profile.Postalzip
                        }
                    )
                    .ToList();

                return result;
            }
        })
        .WithName("GetUserJoin")
        .WithOpenApi();

    }
}

