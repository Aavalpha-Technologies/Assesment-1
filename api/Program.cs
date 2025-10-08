using AvalphaTechnologies.CommissionCalculator.Services;

var builder = WebApplication.CreateBuilder(args);


// 1. Add CORS services to allow our React app to call the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        // IMPORTANT: Update this URL if your React app runs on a different port
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// 2. Register our custom service for Dependency Injection
builder.Services.AddScoped<ICommissionService, CommissionService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// --- Configure the HTTP request pipeline ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// redirect http requests to https: imp
// app.UseHttpsRedirection();

// 3. Use the CORS policy we defined
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();