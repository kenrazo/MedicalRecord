using MedicalRecord.DataAccess.Entities;
using MedicalRecord.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.DataAccess
{
    public class DbContext : IDbContext
    {
        public IPatientRepository PatientRepository { get; set; }

        public DbContext(IPatientRepository patientRepository)
        {
            PatientRepository = patientRepository;
        }
    }
}
