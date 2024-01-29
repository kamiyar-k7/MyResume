using Application.Services.Implements;
using Application.Services.Intefaces;
using Data.Dbcontext;
using Data.Repositories;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserInformationRepository ,  UserInformationRepository>();
builder.Services.AddScoped<IUserInformationService , UserInformationService>();

#region Dbcontext
builder.Services.AddDbContext<ResumeDbContext>(
    option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("ResumeDbContextConnectionString")));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
