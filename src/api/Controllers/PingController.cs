using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace NewRelicHoon.Controllers;

[ApiController]
public class PingController : ControllerBase
{
    [HttpGet("/ping")]
    [AllowAnonymous]
    public IActionResult Get()
    {
        var isHealthy = (DateTime.Now.Second % 2 == 0);

        return isHealthy
            ? Ok("pong")
            : throw new Exception("some sadness happend because your code is trash. Do better before ChatGPT replaces your ass.");
    }

    [HttpGet("/health")]
    [AllowAnonymous] // for POC this fine but for prod apps this should be `Authorize`
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
    public IActionResult GetHealth()
    {
        // https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-7.0
        // https://learn.microsoft.com/en-us/rest/api/cognitiveservices-textanalytics/3.1preview4/health-status/health-status?tabs=HTTP

        var isHealthy = (DateTime.Now.Second % 2 == 0);
        var healthResult = new HealthResult
        {
            TextAnalyticsError = new List<TextAnalyticsError>()
            {
                new TextAnalyticsError()
                {
                    ErrorCodeValue = 500,
                    InnerError = "Bork city",
                    Target = "Foo Service"
                },
                new TextAnalyticsError()
                {
                    ErrorCodeValue = 500,
                    InnerError = "Far too much rain",
                    Target = "Bar Service"
                },
            }
        };

        return isHealthy
            ? StatusCode(200)
            : StatusCode(500, healthResult);
    }
}