using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TheBigStore.Repository;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces;
using TheBigStore.Repository.Repositories;
using TheBigStore.Service.Interfaces;
using TheBigStore.Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<MappingService, MappingService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TheBigStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();