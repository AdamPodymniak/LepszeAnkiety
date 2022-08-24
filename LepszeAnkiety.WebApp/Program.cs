using LepszeAnkiety.Repository.Repositories;
using LepszeAnkiety.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddTransient<IFormService, FormService>();

//Repositories
builder.Services.AddTransient<IFieldTypeRepository, FieldTypeRepository>();
builder.Services.AddTransient<IFormRepository, FormRepository>();
builder.Services.AddTransient<IFormFieldRepository, FormFieldRepository>();
builder.Services.AddTransient<IFormResultRepository, FormResultRepository>();
builder.Services.AddTransient<IFormResultFieldRepository, FormResultFieldRepository>();

// Add services to the container
builder.Services.AddControllersWithViews();
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
