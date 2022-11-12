var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.SwaggerDoc("test_jenkinsci", new()
{

    Title = "使用Jenkins + Docker + Asp.net Core 实现部署",
    Description = "Console.WriteLine(\"🥒\")",

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.DocumentTitle = "使用Jenkins + Docker + Asp.net Core 实现部署";
    o.SwaggerEndpoint($"/swagger/test_jenkinsci/swagger.json", "test_jenkinsci");
});
app.UseAuthorization();


//   
app.MapControllers();

app.Run();
