using SlotCasino.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Supabase Client (HTTPS - no IPv6 issues)
var supabaseUrl = builder.Configuration["Supabase:Url"] ?? throw new InvalidOperationException("Supabase:Url is not configured");
var supabaseKey = builder.Configuration["Supabase:Key"] ?? throw new InvalidOperationException("Supabase:Key is not configured");

builder.Services.AddSingleton(provider =>
{
    var client = new Supabase.Client(supabaseUrl, supabaseKey, new Supabase.SupabaseOptions
    {
        AutoRefreshToken = true,
        AutoConnectRealtime = false
    });
    client.InitializeAsync().Wait();
    return client;
});

// Register application services
builder.Services.AddScoped<IServicioBilletera, ServicioBilletera>();
builder.Services.AddScoped<IMotorJuego, MotorJuego>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
