using Csla.Configuration;
using Outliner.Dal.EF.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCsla(o => o
    .AddAspNetCore()
    .DataPortal(dpo => dpo
        .AddServerSideDataPortal()
        .UseLocalProxy()));

// builder.Services.AddDalEfCore("");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();