using AutoMapper;
using BookManagment.Application.Common.Logging;
using BookManagment.Application.Common.Mapping;
using BookManagment.Application.Interfaces;
using BookManagment.Application.Interfaces.Context;
using BookManagment.Application.Services.Log.Query;
using BookManagment.Application.Services.People.Command;
using BookManagment.Application.Services.People.Command.InsertPeople;
using BookManagment.Application.Services.People.Query;
using BookManagment.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

string conectionString = @"Data Source=.; Initial Catalog=BookManagment; Integrated Security=True;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BookDBContext>(option => option.UseSqlServer(conectionString));

var mapperConf = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
IMapper mapper = mapperConf.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();
// Add services to the container.
builder.Services.AddScoped<IBookDBContext, BookDBContext>();
builder.Services.AddScoped<IRequestHandler<PeopleItemCommand, int>, InsertPeopleCommand>();
builder.Services.AddScoped<IRequestHandler<int, bool>, DeletePeopleCommand>();
builder.Services.AddScoped<IRequestHandler<GetAllPeopleItem>, GetAllPeopleQuery>();
builder.Services.AddScoped<IRequestHandler<GetAllLogQueryItem>, GetAllLogQuery>();


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
app.UseMiddleware<RequestResponseLogging>();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
