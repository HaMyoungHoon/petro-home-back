namespace petro_home_back.Model.Response
{
    public class CommonResult : ICommonResult
    {
        public CommonResult(bool success, int code, string msg) => (Success, Code, Msg) = (success, code, msg);
        public CommonResult(int code, string msg) => (Success, Code, Msg) = (false, code, msg);
        public CommonResult(string msg) => (Success, Code, Msg) = (false, 0, msg);
        public CommonResult() => (Success, Code, Msg) = (false, 0, "");
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
