namespace TransDev.Invoicing.Application.Common.Abstracts;

public class ResponseBase
{
    public bool Success { get; set; }
    public string Error { get; set; }
    public string Message { get; set; }
}
