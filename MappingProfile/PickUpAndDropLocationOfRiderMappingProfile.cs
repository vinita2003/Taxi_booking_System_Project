using AutoMapper;
using Taxi_Booking_System.DTO;
using Taxi_Booking_System.Models;
namespace Taxi_Booking_System.MappingProfile
{
    public class PickUpAndDropLocationOfRiderMappingProfile : Profile
    {
        public PickUpAndDropLocationOfRiderMappingProfile()
        {
            CreateMap<RideBooking, RideBookingPickUpAndDropLocationDTO>()
                .ForMember(dest => dest.PickUpLocationLatitude, opt => opt.MapFrom(src => src.PickUpLocationLatitude))
                .ForMember(dest => dest.PickUpLocationLongitude, opt => opt.MapFrom(src => src.PickUpLocationLongitude))
                .ForMember(dest => dest.DropLocationLatitude, opt => opt.MapFrom(src => src.DropLocationLatitude))
                .ForMember(dest => dest.DropLocationLongitude, opt => opt.MapFrom(src => src.DropLocationLongitude));


        }
    }
}

