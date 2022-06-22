using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using MyWebApi.DbContexts;
using MyWebApi.Dtos;
using MyWebApi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mapper = new MapperConfiguration(ctg =>
{
    ctg.CreateMap<Department, DepartmentDto>();
    ctg.CreateMap<Employee, EmployeeDto>();
    ctg.CreateMap<EmployeeDto, Employee>();
    ctg.CreateMap<EmployeeDto, Person>();
}).CreateMapper();

builder.Services.AddSingleton<IMapper>(mapper);

builder.Services.AddControllers();

// Dodanie do kontenera dependency injector, potem mozna wstrzykiwac to w controllerze
builder.Services.AddDbContext<EmployeeDbContext>(options => 
    options.UseSqlite("Data Source = sialala.db3")
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Stworz baze jesli nie jest stworzona
using (var scoped = app.Services.CreateScope())
{
    var dbContext = scoped.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

app.Run();
