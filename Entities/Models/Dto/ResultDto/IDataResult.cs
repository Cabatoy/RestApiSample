using System.Net;

namespace EntitiesAndCore.Models.Dto.ResultDto
{
    public interface IResult
    {
        HttpStatusCode Success { get; }
        string Message { get; }
    }

    public interface IDataResult<out T> :IResult
    {
        T Data { get; }
    }

    public class DataResult<T> :Result, IDataResult<T>
    {
        // base ile result class ina success ve message gonderiyor.
        public DataResult(T data,HttpStatusCode success,string message) : base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,HttpStatusCode success) : base(success)
        {
            Data = data;
        }
        public DataResult(string message) : base(message)
        {
            Message = message;
        }
        public T Data { get; }
    }
    public class Result :IResult
    {
        //this ile cagrialn constracter diger tek parametre alan methodu da build eder
        public Result(HttpStatusCode success,string message) : this(success)
        {
            Message = message;
            //Success=success;
        }

        public Result(HttpStatusCode success)
        {
            Success = success;
        }

        public Result(string message)
        {
            Message = message;
        }

        public HttpStatusCode Success { get; set; }

        public string Message { get; set; }
    }

    public class ErrorResult :Result
    {
        public ErrorResult(string message) : base(success: HttpStatusCode.BadRequest,message)
        {

        }
        public ErrorResult() : base(success: HttpStatusCode.BadRequest)
        {

        }
    }
    public class SuccessResult :Result
    {

        public SuccessResult(string message) : base(success: HttpStatusCode.OK,message)
        {

        }
        public SuccessResult() : base(success: HttpStatusCode.OK)
        {

        }

    }
}
