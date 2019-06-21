using System;
using System.Collections.Generic;
using System.Text;

namespace ODDESTODDS.Application.DtoModels
{
    public class Response<T> where T : class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

    }
}
