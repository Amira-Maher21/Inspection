using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;

namespace Inspection.Application.Mapping.EquipmentManagement.Equipments
{
    // public class EquipmentMappingProfile : Profile
    //{
    //    //    public EquipmentMappingProfile()
    //    //    {
    //    //        //CreateMap<Equipment, EquipmentDto>();
    //    //        // CreateMap<CreateEquipmentDto, Equipment>();
    //    //        //CreateMap<UpdateEquipmentDto, Equipment>();


    //    //        CreateMap<Equipment, EquipmentDto>()
    //    //.ForMember(dest => dest.MaintenanceIntervalDays, opt => opt.MapFrom(src => src.MaintenanceInterval.HasValue ? (int?)src.MaintenanceInterval.Value.TotalDays : null))
    //    //.ForMember(dest => dest.IsCalibrated, opt => opt.MapFrom(src => src.NextCalibrationDueDate == null || src.NextCalibrationDueDate > DateTime.UtcNow));

    //    //        CreateMap<CreateEquipmentDto, Equipment>()
    //    //            .ForMember(dest => dest.MaintenanceInterval, opt => opt.MapFrom(src => src.MaintenanceIntervalDays.HasValue ? TimeSpan.FromDays(src.MaintenanceIntervalDays.Value) : (TimeSpan?)null));

    //    //        CreateMap<UpdateEquipmentDto, Equipment>()
    //    //            .ForMember(dest => dest.MaintenanceInterval, opt => opt.MapFrom(src => src.MaintenanceIntervalDays.HasValue ? TimeSpan.FromDays(src.MaintenanceIntervalDays.Value) : (TimeSpan?)null));
    //    //    }
    //    public EquipmentMappingProfile()
    //    {
    //        // Equipment → EquipmentDto
    //        CreateMap<Equipment, EquipmentDto>().ReverseMap();
    //        CreateMap<EquipmentDto, EquipmentLookupDefaultDto>()
    //        .AfterMap((src, dist) =>
    //            {
    //                dist.seriesEquipmentNo = src.series + src.EquipmentNo;
    //            });



    //        // Create DTO → Equipment
    //        CreateMap<CreateEquipmentDto, Equipment>().ReverseMap();
    //        // Id بيتولد تلقائيًا

    //        // Update DTO → Equipment
    //        CreateMap<UpdateEquipmentDto, Equipment>().ReverseMap();
    //        CreateMap<EquipmentDtoByInclude, Equipment>().ReverseMap();
    //        CreateMap<EquipmentDtoByInclude, EquipmentDto>().ReverseMap();
    //        CreateMap<EquipmentDto, Equipment>().ReverseMap();
    //        CreateMap<EquipmentDtoByInclude, EquipmentLookupDefaultDto>();

    //    }
    //}


    namespace Inspection.Application.Mapping.EquipmentManagement.Equipments
    {
        public class EquipmentMappingProfile : Profile
        {
            public EquipmentMappingProfile()
            {
                #region Equipment ↔ EquipmentDto

                CreateMap<Equipment, EquipmentDto>()
                    .ReverseMap();

                #endregion

                #region Create / Update

                CreateMap<CreateEquipmentDto, Equipment>().ReverseMap();
                CreateMap<UpdateEquipmentDto, Equipment>().ReverseMap();

                #endregion

                #region EquipmentFullDto

                CreateMap<Equipment, EquipmentFullDto>()
                    .ForMember(dest => dest.Details,
                        opt => opt.MapFrom(src =>
                            src.EquipmentsMoreInformationDetail != null
                                ? src.EquipmentsMoreInformationDetail
                                    .Where(d => !string.IsNullOrWhiteSpace(d.KeyValue))
                                : null
                        ));

                #endregion

                #region Equipment Details

                CreateMap<EquipmentsMoreInformationDetail, EquipmentDetailDto>()
                    .ReverseMap();

                #endregion

                #region Lookup

                CreateMap<EquipmentDto, EquipmentLookupDefaultDto>()
                    .AfterMap((src, dest) =>
                    {
                        dest.seriesEquipmentNo = src.SeriesId + src.EquipmentNo;
                    });

                #endregion
            }
        }
    }
}
