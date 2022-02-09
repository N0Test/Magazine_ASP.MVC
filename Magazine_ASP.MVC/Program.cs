using Azure.Storage.Blobs;
using Magazine_ASP.MVC.DAL;
using Magazine_ASP.MVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString)
);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IHomePageNewsService, NewsService>();

var blobConnectionString = builder.Configuration.GetConnectionString("BlobStorageConnection");
builder.Services.AddSingleton(x => new BlobServiceClient(blobConnectionString));
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageDALService, ImageDALService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
