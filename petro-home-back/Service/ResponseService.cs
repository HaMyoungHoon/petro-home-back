using petro_home_back.Model.Response;

namespace petro_home_back.Service
{
    public class ResponseService
    {
        public CommonResult GetSuccessResult()
        {
            return new CommonResult()
            {
                Success = true,
                Code = 0,
                Msg = "성공",
            };
        }
        public SingleResult GetSingleResult(object data)
        {
            SingleResult ret = new();
            SetSuccessResult(ret);
            ret.Data = data;
            return ret;
        }
        public ListResult GetListResult(object data)
        {
            ListResult ret = new();
            SetSuccessResult(ret);
            ret.List = data;
            return ret;
        }

        public CommonResult GetFailResult(int code, string msg)
        {
            return new CommonResult()
            {
                Success = false,
                Code = code,
                Msg = msg,
            };
        }

        private void SetSuccessResult(CommonResult data)
        {
            data.Success = true;
            data.Code = 0;
            data.Msg = "성공";
        }
    }
}
