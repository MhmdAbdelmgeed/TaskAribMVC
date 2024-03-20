using System.Reflection;
using TaskAribMVC.Shared.ServiceRegister;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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
