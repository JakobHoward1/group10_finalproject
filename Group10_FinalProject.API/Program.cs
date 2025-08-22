using Group10_FinalProject.API.Data;
using Group10_FinalProject.API.Models;
using Group10_FinalProject.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Apply migrations automatically at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

#region Menu Endpoints
app.MapGet("/api/menu", async (IMenuService service) =>
    await service.GetAllAsync());

app.MapGet("/api/menu/{id:guid}", async (IMenuService service, Guid id) =>
{
    var item = await service.GetByIdAsync(id);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/api/menu", async (IMenuService service, [FromBody] MenuItem item) =>
{
    await service.AddAsync(item);
    return Results.Created($"/api/menu/{item.Id}", item);
});

app.MapPut("/api/menu/{id:guid}", async (IMenuService service, Guid id, [FromBody] MenuItem item) =>
{
    if (id != item.Id) return Results.BadRequest();
    await service.UpdateAsync(item);
    return Results.Ok(item);
});

app.MapDelete("/api/menu/{id:guid}", async (IMenuService service, Guid id) =>
{
    await service.DeleteAsync(id);
    return Results.NoContent();
});
#endregion

#region Customer Endpoints
app.MapGet("/api/customers", async (ICustomerService service) =>
    await service.GetAllAsync());

app.MapGet("/api/customers/{id:guid}", async (ICustomerService service, Guid id) =>
{
    var customer = await service.GetByIdAsync(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.MapGet("/api/customers/reviews", async (ICustomerService service) =>
    await service.GetReviewsAsync());

app.MapPost("/api/customers/reviews", async (ICustomerService service, [FromBody] Customer customer) =>
{
    var created = await service.AddAsync(customer);
    return Results.Created($"/api/customers/{created.Id}", created);
});

app.MapPut("/api/customers/{id:guid}", async (ICustomerService service, Guid id, [FromBody] Customer customer) =>
{
    if (id != customer.Id) return Results.BadRequest();
    var updated = await service.UpdateAsync(customer);
    return Results.Ok(updated);
});

app.MapDelete("/api/customers/{id:guid}", async (ICustomerService service, Guid id) =>
{
    await service.DeleteAsync(id);
    return Results.NoContent();
});
#endregion

app.Run();
