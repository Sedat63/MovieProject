using MovieProject.Persistance.Context;
using MovieProject.WebApi.Extensios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovieContext>();

builder.Services.AddApplicationServices()
                .AddIdentityServices()
                .AddMediatorServices()
                .AddSwaggerServices();

//Bu kýsým swagger için
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

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

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});

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