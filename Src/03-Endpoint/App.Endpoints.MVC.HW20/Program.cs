using App.Domain.Core.Cars.AppService;
using App.Domain.Core.Cars.Data;
using App.Domain.Core.Cars.Service;
using App.Domain.Core.Configurations;
using App.Domain.Core.Log.AppService;
using App.Domain.Core.Log.Data;
using App.Domain.Core.Log.Service;
using App.Domain.Core.Operators.AppService;
using App.Domain.Core.Operators.Data;
using App.Domain.Core.Operators.Service;
using App.Domain.Core.Request.AppService;
using App.Domain.Core.Request.Data;
using App.Domain.Core.Request.Service;
using App.Domain.Services.AppService.CarAppSer;
using App.Domain.Services.AppService.CarModelAppSer;
using App.Domain.Services.AppService.InspectionLogAppSer;
using App.Domain.Services.AppService.InspectionReqAppSer;
using App.Domain.Services.AppService.OperatorAppSer;
using App.Domain.Services.Service.CarModelSer;
using App.Domain.Services.Service.CarSer;
using App.Domain.Services.Service.InspectionLogSer;
using App.Domain.Services.Service.InspectionReqSer;
using App.Domain.Services.Service.OperatorSer;
using App.Infrastructure.Db.SqlServer.Ef;
using App.Infrastructure.DbAccess.Repository.Ef.CarModelRepo;
using App.Infrastructure.DbAccess.Repository.Ef.CarRepo;
using App.Infrastructure.DbAccess.Repository.Ef.InspectionLogRepo;
using App.Infrastructure.DbAccess.Repository.Ef.InspectionRequestRepo;
using App.Infrastructure.DbAccess.Repository.Ef.OperatorRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<IInspectionRequestRepository, InspectionRequestRepository>();
builder.Services.AddScoped<IInspectionLogRepository, InspectionLogRepository>();
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();


builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarModelService, CarModelService>();
builder.Services.AddScoped<IInspectionRequestService, InspectionRequestService>();
builder.Services.AddScoped<IInspectionLogService, InspectionLogService>();
builder.Services.AddScoped<IOperatorService, OperatorService>();


builder.Services.AddScoped<ICarAppService, CarAppService>();
builder.Services.AddScoped<ICarModelAppService, CarModelAppService>();
builder.Services.AddScoped<IInspectionRequestAppService, InspectionRequestAppService>();
builder.Services.AddScoped<IInspectionLogAppService, InspectionLogAppService>();
builder.Services.AddScoped<IOperatorAppService, OperatorAppService>();

// Add services to the container.
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
