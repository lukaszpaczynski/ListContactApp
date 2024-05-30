var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddMvcServices();

var app = builder.Build();

app.UseMvcServices();
app.Run();
