using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.SerResult
{
    public class ServiceResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public ServiceResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
