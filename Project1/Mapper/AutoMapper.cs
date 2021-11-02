using System;
using AutoMapper;
using EF = Project1.Models;
using DTO = Project1.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Mapper
{
    public class ModelToDTO : Profile
    {
        public ModelToDTO()
        {
            CreateMap<EF.Patient, DTO.PatientDTO>().ReverseMap();

            CreateMap<EF.MedicalStaff, DTO.MedicalStaffDTO>().ReverseMap();
            CreateMap<EF.Report, DTO.ReportDTO>().ReverseMap();
            CreateMap<EF.Admission, DTO.AdmissionDTO>().ReverseMap();

            //CreateMap<EF.SearchQuery, DTO.SearchQuery>().ReverseMap();

            CreateMap<EF.Admission, DTO.AdmissionDetailsDTO>()
                .ForMember(dest => dest.StaffSurname, opt => opt.MapFrom(src => src.Staff.Surname))
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.Name))
                .ForMember(dest => dest.StaffCode, opt => opt.MapFrom(src => src.Staff.Code))
                .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.Patient.NameSurname));

            CreateMap<DTO.AdmissionToCreateDTO, EF.Admission>()
                .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.StaffId))
                .ForMember(dest => dest.IsEmergency, opt => opt.MapFrom(src => src.IsEmergency))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId));

            CreateMap<DTO.AdmissionDTO, EF.Admission>()
                .ForMember(dest => dest.DateAndTime, opt => opt.MapFrom(src => DateTime.Parse(src.DateAndTime)));
            CreateMap<EF.Admission, DTO.AdmissionDTO>()
               .ForMember(dest => dest.DateAndTime, opt => opt.MapFrom(src => src.DateAndTime.ToString("MM-dd-yyyy")));


            CreateMap<DTO.AdmissionToCreateDTO, EF.Report>()
                .ForMember(dest => dest.DateAndTime, opt => opt.MapFrom(src => DateTime.Parse(src.DateAndTimeForReport)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
    