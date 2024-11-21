using FXT.Application.Services;
using FXT.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using FXT.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ����������� ��������� ���� ������
builder.Services.AddDbContext<FXTimeSeriesDbContext>(options =>
    options.UseInMemoryDatabase("FXTimeSeries"));

// ����������� ������������
builder.Services.AddScoped<ICurrencyRateRepository, CurrencyRateRepository>();

// ����������� �������� Application Layer
builder.Services.AddScoped<ICurrencyRateService, CurrencyRateService>();

// ����������� ������������
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
