using AspNetCore.ReCaptcha;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add environment variables
builder.Configuration.AddEnvironmentVariables(prefix: "IYARLES");

// Add services to the container.
services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));
services.AddMvc();
services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=About}");

app.Run();
