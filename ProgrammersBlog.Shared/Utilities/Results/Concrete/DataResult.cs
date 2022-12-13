using ProgrammersBlog.Shared.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            this.ResultStatus = resultStatus;
            this.Data = data;
        }

        public DataResult(ResultStatus resultStatus, T data, IEnumerable<ValidationError> validationErrors)
        {
            this.ResultStatus = resultStatus;
            this.Data = data;
            this.ValidationErrors = validationErrors;
        }

        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            this.ResultStatus = resultStatus;
            this.Message = message;
            this.Data = data;
        }

        public DataResult(ResultStatus resultStatus, string message, T data, IEnumerable<ValidationError> validationErrors)
        {
            this.ResultStatus = resultStatus;
            this.Message = message;
            this.Data = data;
            this.ValidationErrors = validationErrors;
        }

        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            this.ResultStatus = resultStatus;
            this.Message = message;
            this.Data = data;
            this.Exception = exception;
        }

        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception, IEnumerable<ValidationError> validationErrors)
        {
            this.ResultStatus = resultStatus;
            this.Message = message;
            this.Data = data;
            this.Exception = exception;
            this.ValidationErrors = validationErrors;
        }

        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
