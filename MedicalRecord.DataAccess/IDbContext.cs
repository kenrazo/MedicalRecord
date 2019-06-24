using MedicalRecord.DataAccess.Entities;
using MedicalRecord.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.DataAccess
{
    public interface IDbContext
    {
        IPatientRepository PatientRepository { get; set; }
    }
}
