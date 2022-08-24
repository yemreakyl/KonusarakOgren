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

});// bu satýrda ise APÝ nin kendi içindeki client ta cevap dönmesini engelleyip yadýðýmýz hata filtresinin onu baskýlamasýný ve bizim yazdýðýmýz CustomResponseDto nun dönmesini  istedik



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x =>
{ x.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection"), option =>
    {
        //option.MigrationsAssembly("NLayer.Repository");// Bu þekilde assemly ismimi belirtebilirim ancak assembly adým deðiþirse tekrar gelip uðraþmayayým diye aþaðýdaki gibi kod ile yolu belirtip otomatik almasýný saðlýyorum
        //
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);

    });// optiondan önceki kýsým Connection string tanýmlama daha sonraki kýsým ise AppDbContext classýmýn assembl name ini belirtme.

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
