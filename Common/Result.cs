using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Result
    {
        public Result()
        {
        }

        public Result(bool success, string error)
        {
            IsSuccess = success;
            Message = error;
        }

        public Result(bool success, string error, string configInfo)
        {
            IsSuccess = success;
            Message = error;
            ConfigInfo = configInfo;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ConfigInfo { get; set; }

        public static Result Success()
        {
            return new Result(true, string.Empty);
        }

        public static Result Success(string configInfo)
        {
            return new Result(true, string.Empty, configInfo);
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result Fail(string message,string configInfo)
        {
            return new Result(false, string.Empty, configInfo);
        }
    }
}