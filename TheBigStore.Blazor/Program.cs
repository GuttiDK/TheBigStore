using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TheBigStore.Blazor;
using TheBigStore.Blazor.Service.Interfaces;
using TheBigStore.Blazor.Service.Services;
using TheBigStore.Blazor.Utility;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289") });

builder.Services.AddBlazoredSessionStorageAsSingleton();
builder.Services.AddRadzenComponents();

#region IndexedDb
builder.Services.AddScoped<IndexedDbAccessor>();
builder.Services.AddScoped<CookieAccessor>();
builder.Services.AddScoped<LocalStorage>();

var host = builder.Build();
using var scope = host.Services.CreateScope();
await using var indexedDB = scope.ServiceProvider.GetService<IndexedDbAccessor>();

if (indexedDB is not null)
{
    await indexedDB.InitializeAsync();
}
#endregion

#region DI Container

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IItemOrderService, ItemOrderService>();

// Radzen Services
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();

#endregion

await builder.Build().RunAsync();
