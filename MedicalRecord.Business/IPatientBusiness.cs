using MedicalRecord.Common;
using MedicalRecord.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecord.Business
{
    public interface IPatientBusiness
    {
        Task<IEnumerable<PatientsDto>> Get();

        Task<PatientsDto> GetById(int id);

        Task<Result> Insert(PatientsDto patient);

        Task<Result> Update(PatientsDto patient);

        Task<Result> Delete(PatientsDto patient);

        Task<bool> CheckIfExist(int id);

        Result DeletePatient(int id);

    }
}
