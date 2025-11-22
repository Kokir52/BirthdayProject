using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RodjendaniProjekat.DB;
using RodjendaniProjekat.Handlers;
using RodjendaniProjekat.Handlers.addBirthday;
using RodjendaniProjekat.Handlers.edit;
using RodjendaniProjekat.Handlers.get;
using RodjendaniProjekat.Handlers.getAll;
using RodjendaniProjekat.Handlers.getMonth;
using RodjendaniProjekat.Handlers.getSorted;
using RodjendaniProjekat.Handlers.remove;
using RodjendaniProjekat.Mapper;
using RodjendaniProjekat.Middleware;
using RodjendaniProjekat.Models;
using RodjendaniProjekat.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<BirthdayDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IBirthdayService, BirthdayService>();

builder.Services.AddScoped<IHandler<addBirthdayRequest, addBirthdayResponse>, addBirthdayHandler>();
builder.Services.AddScoped<IHandler<getAllRequest,  getAllResponse>, getAllHandler>();  
builder.Services.AddScoped<IHandler<getRequest, getResponse>, getHandler>();
builder.Services.AddScoped<IHandler<RemoveRequest, RemoveResponse>, RemoveHandler>();
builder.Services.AddScoped<IHandler<editRequest, editResponse>, editHandler>();
builder.Services.AddScoped<IHandler<GetSortedRequest, GetSortedResponse>, GetSortedHandler>();
builder.Services.AddScoped<IHandler<GetMonthRequest, GetMonthResponse>, GetMonthHandler>();
builder.Services.AddAutoMapper(typeof(BirthdayMapperProfile));

var app = builder.Build();
app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();



app.Run();





