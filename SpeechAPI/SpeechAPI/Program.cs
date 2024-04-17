using Microsoft.Extensions.Configuration;
using SpeechAPI.Interfaces;
using SpeechAPI.Repositories;
using SpeechAPI.Services;
using SpeechAPI.Interfaces;
using SpeechAPI.Repositories;
using SpeechAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ISpeechRepository, AzureSpeechRepository>();
builder.Services.AddScoped<TextToSpeechService>();
builder.Services.AddScoped<SpeechToTextService>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

