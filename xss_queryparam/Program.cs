using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/home/{id}", async (HttpContext context, string id) =>
{
    // Get the filename and location based on the id parameter
    string filename = $"File{id}.txt";
    string location = "/path/to/files/";

    // Generate HTML response with filename and location
    string htmlResponse = $"<html><body><h1>File Information</h1><p>Filename: {filename}</p><p>Location: {location}</p></body></html>";

    // Set response content type to HTML
    context.Response.Headers.Add("Content-Type", "text/html");

    // Write HTML response to the client
    await context.Response.WriteAsync(htmlResponse);
});

app.Run();
