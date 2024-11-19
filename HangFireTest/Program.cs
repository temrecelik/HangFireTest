using Hangfire;
using HangFireTest.Background;
using HangFireTest.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
}
);

builder.Services.AddHangfire(options =>
{
    options.UseSqlServerStorage(builder.Configuration.GetConnectionString("SqlServer"));
});



builder.Services.AddHangfireServer();

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
app.UseHangfireDashboard();


RecurringJob.AddOrUpdate("test-job40", () => BackGService.Test(), "*/1 * * * *" , new RecurringJobOptions
{
    TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")
});
RecurringJob.AddOrUpdate("test-job80", () => BackGService.Test(), "*/1 * * * *", new RecurringJobOptions
{
    TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")
});

app.UseAuthorization();

app.MapControllers();

app.Run();
