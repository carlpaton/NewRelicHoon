namespace NewRelicHoon.Controllers;

public class HealthResult
{
    public List<TextAnalyticsError> TextAnalyticsError { get; set; }
}

public class TextAnalyticsError
{
    public int ErrorCodeValue { get; set; }
    public string InnerError { get; set; }
    public string Target { get; set; }
}