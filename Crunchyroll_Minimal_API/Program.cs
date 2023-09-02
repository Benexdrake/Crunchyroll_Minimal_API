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

app.MapGet("/crunchyroll", (CrunchyrollDBContext context) =>
{
    return context.Animes.Find(_ => true).ToList();
});

app.MapGet("/crunchyroll/id", (CrunchyrollDBContext context, string id) =>
{
    var filter = Builders<Anime>.Filter.Eq(x => x._id, id);

    return context.Animes.Find(filter).FirstOrDefault();
});

// By ID

app.Run();

