using FluentValidation.AspNetCore;
using FunTranslation.Application;
using FunTranslation.Application.Extension;
using FunTranslation.Application.SystemModels;
using FunTranslation.Application.Validations;
using FunTranslation.Infrastructure;
using FunTranslation.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

SeriLogExtension.ConfigureLoggin();
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();//.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserLoginViewModelValidator>());
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication();
builder.Services.Configure<FunTranslationSystemModel>(builder.Configuration.GetSection("FunTranslationSystemModel"));
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
builder.Services.AddPersistenceServices(builder.Configuration.GetConnectionString("SqlConnection"));
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});
builder.Services.AddMvc();

var app = builder.Build();
app.UseExceptionHandler("/Home/Error");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.DatabaseInitialize();

app.Run();
