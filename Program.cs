using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

using HomeMaintenance.Models;
using HomeMaintenance.Repositories;
using HomeMaintenance.DTOs;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<TaskExecutionHistory>("TaskExecutionHistory");
modelBuilder.EntitySet<HomeMaintenance.DTOs.MaintenanceCycleTaskDTO>("MaintenanceCycleTask");

// Add services to the container.

// enable OData query capabilities - $select, $filter, $orderby, $expand, count, $top and $skip
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata", modelBuilder.GetEdmModel()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EntityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddScoped<IMaintenanceCycleRepository, MaintenanceCycleRepository>();

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// match incoming HTTP requests and dispatching them to endpoints
app.UseODataRouteDebug();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
