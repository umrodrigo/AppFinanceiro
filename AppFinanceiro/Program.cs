using Financ.API.Helpers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddCustomCors(builder.Configuration, builder.Environment);

builder.Services
    .AddDatabase(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services
    .AddServices();
builder.Services
    .AddCustomOptions(builder.Configuration);
builder.Services
    .AddControllers()
    .AddJsonOptions(conf =>
    {
        conf.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        conf.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        conf.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        conf.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    });
builder.Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseHsts();
app.UseRouting();
app.UseCors("cors");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
