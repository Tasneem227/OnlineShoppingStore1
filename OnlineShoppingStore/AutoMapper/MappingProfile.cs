using AutoMapper;
using HospitalMS.ViewModel;
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
            CreateMap<Product, EditProductViewModel>()
                .ForMember(dest => dest.CurrentImgUrl, src => src.MapFrom(x => x.ImageUrl));
            CreateMap<EditProductViewModel, Product>()
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom(x => x.NewImageUrl ?? x.CurrentImgUrl));

            CreateMap<RegisterViewModel, Customer>()
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(x => x.Phone))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(x => x.FName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(x => x.LName))
                .ForMember(dest => dest.Image, src => src.MapFrom(x => x.Image))
                ;
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password))
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(x => x.Phone))
                .ForMember(dest => dest.ProfilePicture, src => src.MapFrom(x => x.Image))
                .ForMember(dest => dest.UserName, src => src.MapFrom(x => x.UserName));
        }
    }
}
