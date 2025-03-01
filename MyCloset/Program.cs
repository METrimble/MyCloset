using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using MyCloset.Data;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

/************************************
 * Documentation:
 * https://learn.microsoft.com/en-us/azure/azure-sql/database/azure-sql-dotnet-entity-framework-core-quickstart?view=azuresql&tabs=visual-studio%2Cservice-connector%2Cportal
************************************/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var Connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    // Set the Azure SQL Database connection string
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    Connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    // Uses Environment variable set in the Azure App Service
    Connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

// Use the connection string to register the EF Core DbContext class
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(Connection));

// Connect to Azure Blob Storage Account using default azure credential
builder.Services.AddAzureClients(clientBuilder =>
{
	clientBuilder.AddBlobServiceClient(
		new Uri("https://mycloset.blob.core.windows.net"));
	clientBuilder.UseCredential(new DefaultAzureCredential());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
