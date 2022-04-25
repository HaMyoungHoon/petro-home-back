﻿using petro_home_back.Model.Response;

namespace petro_home_back.Data.Advice.Exceptions
{
    public class UserNotFoundException : Exception, ICommonResult
    {
        public UserNotFoundException(int code = 0, string msg = "") => (Success, Code, Msg) = (false, code, msg);

        public bool Success { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
