using Microsoft.EntityFrameworkCore;
using NegocioInversiones.Data;
using NegocioInversiones.Interfaces;
using NegocioInversiones.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SqlServerContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLSERVERCONNECTION"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<ILoanRequestService,LoanRequestService>();
builder.Services.AddScoped<ILoanService, LoanService>();


builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
