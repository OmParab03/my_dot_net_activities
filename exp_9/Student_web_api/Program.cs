var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //enable controllers 

// ✅ Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //Enable swagger 

var app = builder.Build();

// ✅ Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Connect controller to app

app.Run();
