

using WebApi.Abstractions;
using WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IServiceCalculate, ServiceCalculate>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
        c.RoutePrefix = string.Empty;
    }
    );
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
