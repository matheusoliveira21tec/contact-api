using contact_api.Models;
using contact_api.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.
builder.Services.Configure<PeopleDatabaseSettings>
    (builder.Configuration.GetSection("DevNetStoreDatabase"));

builder.Services.AddSingleton<PeopleServices>();

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
app.UseCors(C =>
{
    C.AllowAnyHeader();
    C.AllowAnyMethod();
    C.AllowAnyOrigin();
    
});
app.UseAuthorization();

app.MapControllers();

app.Run();
