using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Repositories.OrderRepositories;
using TheBigStore.Repository.Repositories.UserRepositories;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.MappingServices;
using TheBigStore.Service.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<MappingService, MappingService>();

// Customer services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Role services
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

// Item services
builder.Services.AddScoped<IItemRepository, ItemRepository>();
//builder.Services.AddScoped<IItemService, ItemService>();

// Order services
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IOrderService, OrderService>();

// User services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Address services
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
//builder.Services.AddScoped<IAddressService, AddressService>();

// Category services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();

// ItemOrder services
builder.Services.AddScoped<IItemOrderRepository, ItemOrderRepository>();
//builder.Services.AddScoped<IItemOrderService, ItemOrderService>();


// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TheBigStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging())
    .AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(30); }).AddMemoryCache();



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