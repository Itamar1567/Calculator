var corsPolicy = "_myCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
options.AddPolicy(name: corsPolicy,
policy =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.WithOrigins("http://localhost:4200");
}));

var app = builder.Build();

app.UseCors(corsPolicy);
app.UseAuthentication();
app.UseAuthorization();


app.MapGet("/hello", () => "Hello World");
app.MapPost("/operations", (Operations request) =>
{
    var operations = new Operations();
    var results = operations.EnterInputToCalculate(request.input);
    Console.WriteLine(results);
    return Results.Ok(new { sum = results });
    


});

app.Run();

