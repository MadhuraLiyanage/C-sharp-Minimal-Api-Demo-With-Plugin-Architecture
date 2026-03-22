using Plugin.Framework;
using Trading.BusinessModels;
using Trading.SharesApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PluginManager>();
builder.Services.AddScoped<SharesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/shares", async (SharesModel share, SharesService service, HttpContext httpContext) =>
{
    return await service.CreateShare(share, httpContext);
});

app.Run();


