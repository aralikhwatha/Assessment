namespace InvoiceTracker.Application.Domain.Base
{
    public class BaseResponseGeneric<T>
    {
        public bool Succcess { get; set; }
        public T? Payload { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ErrorDetail>? Errors { get; set; }
    }
}
