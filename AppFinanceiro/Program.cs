using Financ.API.Helpers;
using Financ.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<FinancContext>(opt => 
//    opt.UseSqlServer(
//        builder.Configuration.GetConnectionString("FinancContext"), 
//        b => b.MigrationsAssembly("Financ.API")));
builder.Services
    .AddDatabase(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services
    .AddControllers();
builder.Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services
    .AddServices();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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
