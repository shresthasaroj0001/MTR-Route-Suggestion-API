using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_Core.Model
{
    public class GenericResponseObject<T> where T : class
    {
        public T Data { get; set; }
        public int ErrorCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int PageSize { get; set; }
    }
}
