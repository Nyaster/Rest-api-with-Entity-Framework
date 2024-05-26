using Rest_Api_DBfirst.Context;
using Rest_Api_DBfirst.Middlewares;
using Rest_Api_DBfirst.Repositories;
using Rest_Api_DBfirst.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration =
    new ConfigurationBuilder().AddJsonFile("secrets.json", optional: true, reloadOnChange: true).Build();
builder.Configuration.AddConfiguration(configuration);
builder.Services.AddControllers().AddXmlSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TripRepository, TripRepository>();
builder.Services.AddScoped<TripService, TripService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ApbdContext>();
builder.Services.AddTransient<ErrorHandlingMiddleWare>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleWare>();
app.UseAuthorization();

app.MapControllers();

app.Run();