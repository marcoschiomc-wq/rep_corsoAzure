var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterHttpServices();
builder.Services.RegisterServices();
var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseExceptionHandler();
}

app.RegisterEP();

app.Run();

