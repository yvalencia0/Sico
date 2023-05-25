using AutoMapper;
using BackendSico;
using BackendSico.Context;
using BackendSico.Interfaces;
using BackendSico.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Se agrega el mapeo para transformar los modelos a los Dtos
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Repositorios
builder.Services.AddScoped<IPerson, PersonService>();
builder.Services.AddScoped<ITeacher, TeacherService>();
builder.Services.AddScoped<IStudent, StudentService>();
builder.Services.AddScoped<ICourse, CourseService>();
builder.Services.AddScoped<ICourseDetail, CourseDetailService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
