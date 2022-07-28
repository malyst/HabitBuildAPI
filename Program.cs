using IBM.EntityFrameworkCore;
using WebApplication4;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = "Server=85e59568-ee57-4e7f-ba03-89639d10b0f5.bs2ipa7w0uv9tsomi9ig.databases.appdomain.cloud:30934;Database=bludb;UID=94fd4ec9;PWD=QHGDGlD89kvrVT7A;security=SSL";
builder.Services.AddDbContext<Context>(options => options.UseDb2(connection, p => p.SetServerInfo(IBMDBServerType.LUW)));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
