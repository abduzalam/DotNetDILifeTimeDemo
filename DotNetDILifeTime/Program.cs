using DotNetDILifeTime.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registering Custom Classes 
// The Transient services always create a new instance, every time we request for it
builder.Services.AddTransient<ITransientService,SomeService>();

// The Services with scoped lifetime are created only once per each request (scope).
// I.e. It creates a new instance per request and reuses that instance within that request.
builder.Services.AddScoped<IScopedService, SomeService>();

// The Singleton scope creates a single instance of the service when the request for it comes for the first time.
// After that for every subsequent request, it will use the same instance.
// The new request does not create the new instance of the service but reuses the existing instance.
builder.Services.AddSingleton<ISingletonService, SomeService>();

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
