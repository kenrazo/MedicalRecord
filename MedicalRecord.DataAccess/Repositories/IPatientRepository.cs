using MedicalRecord.Common;
using MedicalRecord.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecord.DataAccess.Repositories
{
    public interface IPatientRepository : IGenericBase<Patient>
    {
        Task<bool> CheckIfExist(int id);

        Result DeletePatient(int id);
    }
}
