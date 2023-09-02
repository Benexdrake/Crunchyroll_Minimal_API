using MongoDB.Driver;
using Server.Data;
using Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MongoClient>(new MongoClient(builder.Configuration["MongoDb:IP"]));
builder.Services.AddScoped<CrunchyrollDBContext>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(o =>
{
    o.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyOrigin();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/crunchyroll", (CrunchyrollDBContext ctx) => ctx.Animes.AsQueryable().ToList()); 

app.MapGet("/crunchyroll/id", (CrunchyrollDBContext ctx, string id) => ctx.Animes.AsQueryable().FirstOrDefault(x => x._id.Equals(id)));

// By ID

app.Run();

