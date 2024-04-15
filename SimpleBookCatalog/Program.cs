using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Components;
using SimpleBookCatalog.Infrastructure.Context;
using SimpleBookCatalog.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Razor Components and Interactive Server Components services.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add DbContextFactory for SimpleBookCatalogDbContext.
builder.Services.AddDbContextFactory<SimpleBookCatalogDbContext>(options =>
{
    // Configure DbContext to use SQL Server with the connection string from appsettings.json.
    options.UseSqlServer(builder.Configuration.GetConnectionString("SimpleBookCatalogConnection"));
});

// Add scoped lifetime service for IBookRepository with BookRepository implementation.
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Check if the environment is not development.
if (!app.Environment.IsDevelopment())
{
    // Use ExceptionHandler middleware to handle errors and redirect to the Error page.
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // Enable HTTP Strict Transport Security (HSTS).
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enable serving static files (e.g., CSS, JavaScript).
app.UseStaticFiles();

// Add anti-forgery middleware to prevent cross-site request forgery (CSRF) attacks.
app.UseAntiforgery();

// Map Razor Components to the root path and add Interactive Server Render Mode.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Run the application.
app.Run();
