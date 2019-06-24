using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Common
{
    public class Result
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
