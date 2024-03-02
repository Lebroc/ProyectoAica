using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoAica.Db;
using ProyectoAica.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => 
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

//app.MapE();
app.MapDeleteEndpoint();
app.MapUploadFile();
app.MapOpenFolderEndpoint();
app.MapDownloadEndpoint();
app.MapMoveEndpoint();
    
app.Run();
