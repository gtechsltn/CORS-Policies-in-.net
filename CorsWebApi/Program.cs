var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();


// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://trusteddomain.com") // Replace with your allowed domain
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("AllowSubdomains", policy =>
    {
        policy.WithOrigins("https://*.trusteddomain.com") // Allow subdomains
              .SetIsOriginAllowedToAllowWildcardSubdomains()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

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
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
// Use the CORS policies
app.UseCors("AllowSpecificOrigin"); // Use the desired policy here

app.UseAuthorization();

app.MapControllers();

app.Run();

