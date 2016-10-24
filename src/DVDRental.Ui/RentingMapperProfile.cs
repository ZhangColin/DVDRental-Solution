using AutoMapper;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Catalogue.Catalogue;
using DVDRental.Public.ApplicationService.ApplicationViews;
using DVDRental.Subscription.RentalRequests;

namespace DVDRental.Ui
{
    public class RentingMapperProfile: Profile
    {
        public override string ProfileName { get { return "RentingMapperProfile"; } }

        public RentingMapperProfile(IRepository<Film> filmRepository)
        {
            CreateMap<Film, FilmView>()
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>src.Title))
                .ForMember(dest=>dest.IsCurrentlyOnLoan, opt=>opt.UseValue(false))
                .ForMember(dest=>dest.IsOnRentalList, opt=>opt.UseValue(false));

            CreateMap<RentalRequest, RentalRequestView>()
                .ForMember(dest => dest.CanBeRemovedFromList, opt => opt.MapFrom(src => src.CanBeRemovedFromList))
                .ForMember(dest => dest.SubscriptionIdString, opt => opt.MapFrom(src => src.SubscriptionId.ToString()))
                .ForMember(dest => dest.FilmTitle, opt => opt.MapFrom(src => filmRepository.Get(src.FilmId).Title));
        }
    }
}