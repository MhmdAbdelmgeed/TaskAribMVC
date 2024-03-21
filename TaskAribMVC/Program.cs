using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskAribMVC.Business.BusinessService;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO.Mapping;
using TaskAribMVC.GenericRepository;
using TaskAribMVC.Models;
using TaskAribMVC.Shared.ServiceRegister;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
})
.AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Services 


#region Using Scrutor To Scan Service

builder.Services.Scan(scan => scan
    .FromAssemblyDependencies(Assembly.GetExecutingAssembly())
    .AddClasses(classes => classes.AssignableTo(typeof(ITransientService)))
    .AsImplementedInterfaces()
    .WithTransientLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyDependencies(Assembly.GetExecutingAssembly())
    .AddClasses(classes => classes.AssignableTo(typeof(ISingletonService)))
    .AsImplementedInterfaces()
    .WithSingletonLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyDependencies(Assembly.GetExecutingAssembly())
    .AddClasses(classes => classes.AssignableTo(typeof(IScopedService)))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

#endregion
builder.Services.AddAutoMapper(typeof(MappersProfile));
builder.Services.AddTransient<IUnitOfWork<ApplicationUser>, UnitOfWork<ApplicationDbContext, ApplicationUser>>();

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

//app.MapControllerRoute(
//    name: "login",
//    pattern: "",
//    defaults: new { controller = "Login", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
