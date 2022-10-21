using ProjectManagement.Application.Extensions;
using ProjectManagement.Infrastructure.GlobalExceptionHandling;
using ProjectManagement.Persistence.PersistenceExtensions;
using ProjectManagement.WebAPI.PresentationExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddPresentationExtension(builder.Configuration);
builder.Services.AddPersistenceExtension();
builder.Services.AddApplicationExtension();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();



app.Run();
