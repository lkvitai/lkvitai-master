using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => Results.Ok(new { status = "ok", service = "lkvitai-warehouse-service"}));
app.MapGet("/_info", () => Results.Ok(new { name="lkvitai-warehouse-service", version=app.Environment.ApplicationName }));

app.Run();
