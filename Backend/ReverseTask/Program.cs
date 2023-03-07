using Microsoft.EntityFrameworkCore;
using ReverseTask;
using ReverseTask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ApiMappingProfile).Assembly);
builder.Services.AddScoped<ConcentrationService>();
builder.Services.AddDbContext<ReverseTaskDbContext>(options =>
{
    options.UseMySql("server=94.228.124.31;user=test;password=test;database=menagerie;",
        new MySqlServerVersion(new Version(8, 0, 11)));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();