namespace petro_home_back.Model.Response
{
    public interface ICommonResult
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
