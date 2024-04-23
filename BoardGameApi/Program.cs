// using BoardGameApi.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cfg =>
    {
        cfg.AllowAnyMethod();
        cfg.WithOrigins(builder.Configuration["AllowedOrigins"]);
        cfg.AllowAnyHeader();
    });

    options.AddPolicy("AnyOrigin", cfg =>
    {
        cfg.AllowAnyOrigin();
        cfg.AllowAnyMethod();
        cfg.AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Configuration.GetValue<bool>("UseSwagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if(app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");


app.UseHttpsRedirection();
app.UseCors();

app.MapGet("/error", 
[ResponseCache(NoStore = true)]
[EnableCors("AnyOrigin")] () => Results.Problem());

app.MapGet("/error/test", 
[ResponseCache(NoStore = true)]
[EnableCors("AnyOrigin")] () => {throw new Exception("error...");});

app.MapGet("/cod/test" ,
[EnableCors("AnyOrigin")]
[ResponseCache(NoStore = true)]
() => Results.Text(
    "<script>"
    + "window.alert('Your client supports Javascript"
    + "\\r\\n\\r\\n"
    + $"Server Time(UTC): {DateTime.UtcNow.ToString("o")}"
    + "\\r\\n"
    + "Client Time (UTC): ' + new Date().toISOString());"
    + "</script>"
    +"<noscript>Your client does not support JavaScript</noscript>",
"text/html"
    ));

// app.MapGet("/cod/test",
// [EnableCors("AnyOrigin")]
// [ResponseCache(NoStore = true)] () =>
// Results.Text("<script>" +
// "window.alert('Your client supports JavaScript!" +
// "\\r\\n\\r\\n" +
// $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
// "\\r\\n" +
// "Client time (UTC): ' + new Date().toISOString());" +
// "</script>" +
// "<noscript>Your client does not support JavaScript</noscript>",
// "text/html"));

app.MapControllers();

app.Run();