using Marebor.Voting.Core;
using Marebor.Voting.Core.Infrastructure;
using Marebor.Voting.Notifications;
using Marebor.Voting.Notifications.Messaging;
using Marebor.Voting.ReadModel;
using Marebor.Voting.ReadModel.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddCoreServices()
    .AddCoreInfrastructureServices()
    .AddReadModelServices()
    .AddReadModelInfrastructureServices()
    .AddNotificationsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationsHub>("/notifications");

app.Run();
