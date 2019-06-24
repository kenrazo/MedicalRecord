using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalRecord.Common.Dto
{
    public class PatientsDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }
    //    [Required]
        [MaxLength(20)]
        public string Lastname { get; set; }
    }
}
