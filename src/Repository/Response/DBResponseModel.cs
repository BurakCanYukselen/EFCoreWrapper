using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreWrapper.Response
{
    public class DBResponseModel<T> : DBResponseModel
    {
        public T Data { get; set; }
        public DBResponseModel(T data)
        {
            Data = data;
        }
    }

    public class DBResponseModel
    {
        public bool IsSucces { get; set; }
        public string ErrorMessage { get; set; }
    }
}
