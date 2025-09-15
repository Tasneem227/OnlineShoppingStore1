using AutoMapper;
using OnlineShoppingStore.ViewModel.AdminViewModel;
using OnlineShoppingStore.ViewModel.LayoutViewModel;

namespace OnlineShoppingStore.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<CartItem, LayoutViewModel>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Product.Name))
                .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Product.Price))
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom(x => x.Product.ImageUrl))
                .ForMember(dest => dest.Quantity, src => src.MapFrom(x => x.Quantity));

            CreateMap<AddProductViewModel, Product>();

        }
    }
}
