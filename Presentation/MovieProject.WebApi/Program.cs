

using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieProject.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using MovieProject.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using MovieProject.Persistance.Context;
using MovieProject.Persistance.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovieContext>();

//Category
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

//Movie
builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();

builder.Services.AddScoped<CreateUserRegisterCommandHandler>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));



//Bu kýsým swagger için
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api v1");
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*
GetExecutingAssembly suanda calisan derlemeyi temsil eder hocam Mediatr bu reflection ile derlemedeki tüm tipleri tarar ve IrequestHandler lari implemente eden tüm handlerlarý kendisi kaydeder. ama onion mimaride handlerin oldugu katmanýn assembly referansýna ihtiyaç var ondan dolayý hata alýyoruz. 

Ben daha esnek ve baðýmsýz olmasý için gerekli katmanda AssemblyReference sýnýfý oluþturup
Assembly assembly = typeof(Assembly).Assembly;
þeklinde direk atýyorum ve direk assembyl burdan kullanabiliyorum.
*/