using AutoMapper;
using MedicalRecord.Business.Factories;
using MedicalRecord.Common;
using MedicalRecord.Common.Dto;
using MedicalRecord.DataAccess;
using MedicalRecord.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecord.Business
{
    public class PatientBusiness : IPatientBusiness
    {
        private IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPaymentTypeFactory _paymentTypeFactory;
        public PatientBusiness(IDbContext dbContext, IMapper mapper, IPaymentTypeFactory paymentTypeFactory)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _paymentTypeFactory = paymentTypeFactory;
        }

        public async Task<IEnumerable<PatientsDto>> Get()
        {
            var patients = await _dbContext.PatientRepository.All();
            //  var result = new List<PatientsDto>();
            var result = _mapper.Map<IEnumerable<PatientsDto>>(patients);
            

            return result;
        }

        public async Task<PatientsDto> GetById(int id)
        {
            var patient = await _dbContext.PatientRepository.ById(id);
            var result = _mapper.Map<PatientsDto>(patient);
            var paymentType = GetPaymentType(patient);
            return result;
        }

        private string GetPaymentType(Patient patient)
        {
            var paymentFactory = _paymentTypeFactory.GetPaymentType(patient.PaymentTypeId);
            return  paymentFactory.PaymentType();
        }

        public async Task<Result> Insert(PatientsDto patient)
        {
            var data = _mapper.Map<Patient>(patient);
            var result = await _dbContext.PatientRepository.Insert(data);
            return result;
        }

        public async Task<Result> Update(PatientsDto patient)
        {
            var data = _mapper.Map<Patient>(patient);
            var result = await _dbContext.PatientRepository.Update(data);
            return result;
        }
        
        public async Task<Result> Delete(PatientsDto patient)
        {
            var data = _mapper.Map<Patient>(patient);
            var result = await _dbContext.PatientRepository.Delete(data);
            return result;
        }

        public async Task<bool> CheckIfExist(int id)
        {
            return await _dbContext.PatientRepository.CheckIfExist(id);
        }

        public Result DeletePatient(int id)
        {
            return  _dbContext.PatientRepository.DeletePatient(id);
        }
    }
}
