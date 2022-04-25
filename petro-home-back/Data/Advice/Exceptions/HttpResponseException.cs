namespace petro_home_back.Data.Advice.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int code, object? value = null) => (StatusCode, Value) = (code, value);

        public int StatusCode { get; set; }
        public object? Value { get; set; }
    }
}
