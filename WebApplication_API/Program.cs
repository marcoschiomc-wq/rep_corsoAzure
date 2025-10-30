var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterHttpServices();
builder.Services.RegisterServices(builder.Configuration);
var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseExceptionHandler();
}

// seconda modifica di push
//prova push

app.RegisterEP();

app.Run();

