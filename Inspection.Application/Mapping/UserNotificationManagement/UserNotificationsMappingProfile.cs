using AutoMapper;
using Inspection.Application.Contracts.Dto.UserNotificationManagement;
using Inspection.Domain.Models.UserNotificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.UserNotificationManagement
{
    internal class UserNotificationsMappingProfile : Profile
    {
        public UserNotificationsMappingProfile()
        {
            this.CreateMap<User_Notification, UserNotificationsInsertDto>().ReverseMap();

            this.CreateMap<User_Notification, UserNotificationsUpdateDto>().ReverseMap();
        }
    }
}
