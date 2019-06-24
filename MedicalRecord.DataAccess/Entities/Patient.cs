using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.DataAccess.Entities
{
    [Table("[Patient]")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender { get; set; }

    }
}
