using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    ////context.Response.StatusCode = 400; // Incorrect or invalid code
    //if (context.Request.Method == "GET")
    //{
    //    //if (context.Request.Query.ContainsKey("id"))
    //    //{
    //    //    string id = context.Request.Query["id"];
    //    //    await context.Response.WriteAsync($"<h1>The id is: {id}</h1>");
    //    //};

    //    //context.Response.Headers["content-type"] = "text/html";
    //    //if (context.Request.Headers.ContainsKey("Test"))
    //    //{
    //    //    string userAgent = context.Request.Headers["Test"];
    //    //    await context.Response.WriteAsync($"<h1>{userAgent}</h1>");

    //}

    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }

});

app.Run();
