using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;

namespace LogModule.Model
{
    public class ExceptionLog : BaseModel
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
