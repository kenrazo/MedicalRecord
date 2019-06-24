using AutoMapper;
using MedicalRecord.Common.Dto;
using MedicalRecord.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRecord.Business.AutoMapper
{
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            CreateMap<IEnumerable<PatientsDto>, IEnumerable<Patient>>();

            CreateMap<PatientsDto, Patient>();

         //   CreateMap<IEnumerable<Patient>, IEnumerable<PatientsDto>>();
        }
    }
}
