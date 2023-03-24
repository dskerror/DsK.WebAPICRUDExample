using DsK.Application.Extensions;
using DsK.DAL.Extensions;
using DsK.DAL.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DsKDbContext>();
builder.Services.AddApplicationLayer();
builder.Services.AddRepositories();
builder.Services.AddInfrastructureMappings();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
