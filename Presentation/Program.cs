using Application.Services.Implements;
using Application.Services.Intefaces;
using Data.Dbcontext;
using Data.Repositories;
using Domain.IRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// user information
builder.Services.AddScoped<IUserInformationRepository, UserInformationRepository>();
builder.Services.AddScoped<IUserInformationService, UserInformationService>();

//my serviec
builder.Services.AddScoped<IMyserviceRepository, MyserviceRepository>();
builder.Services.AddScoped<IMyServicesService, MyServicesService>();

// my skill
builder.Services.AddScoped<IMySkillRepository, MySkillRepository>();
builder.Services.AddScoped<IMySkillService, MySkillService>();

//contact 
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

#region Dbcontext
builder.Services.AddDbContext<ResumeDbContext>(
    option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("ResumeDbContextConnectionString")));
#endregion

#region Cookies
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
         // Add Cookie settings
         .AddCookie(options =>
         {
             options.LoginPath = "/Account/Login";
             options.LogoutPath = "/Logout";
             options.ExpireTimeSpan = TimeSpan.FromDays(365);

         });
#endregion

#region WEB APP

builder.Services.AddProgressiveWebApp();
#endregion


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
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
           name: "Areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );

    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
