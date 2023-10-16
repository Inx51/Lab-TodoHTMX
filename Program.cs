var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDefaultFiles(new DefaultFilesOptions {
    DefaultFileNames = new List<string> { "index.html" }
});
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
