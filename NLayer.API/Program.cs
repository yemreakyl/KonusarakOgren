using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayer.API.Modules;
using NLayer.Core;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;
using NLayer.Repository;
using NLayer.Repository.Repository;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<ApiBehaviorOptions>(options =>
{ 
    options.SuppressModelStateInvalidFilter = true;

});// bu sat�rda ise AP� nin kendi i�indeki client ta cevap d�nmesini engelleyip yad���m�z hata filtresinin onu bask�lamas�n� ve bizim yazd���m�z CustomResponseDto nun d�nmesini  istedik



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x =>
{ x.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection"), option =>
    {
        //option.MigrationsAssembly("NLayer.Repository");// Bu �ekilde assemly ismimi belirtebilirim ancak assembly ad�m de�i�irse tekrar gelip u�ra�mayay�m diye a�a��daki gibi kod ile yolu belirtip otomatik almas�n� sa�l�yorum
        //
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);

    });// optiondan �nceki k�s�m Connection string tan�mlama daha sonraki k�s�m ise AppDbContext class�m�n assembl name ini belirtme.

});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(x => x.RegisterModule(new ReposServiceModule()));
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
