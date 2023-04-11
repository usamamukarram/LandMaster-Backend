using AutoMapper;
using Deals.Dto.Buyyer;
using Deals.Dto.Landlord;
using Deals.Dto.PlotSize;
using Deals.Dto.Role;
using Deals.Dto.Seller;
using Deals.Dto.Society;
using Deals.Dto.SocietyBlocksDto;
using Deals.Dto.Tenant;
using Deals.Dto.User;
using Deals.Models;

namespace Deals.AutoMapper
{
    public class AutoMapper :Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Roles, RoleDto>();
            CreateMap<Society, SocietyDto>();
            CreateMap<SocietyBlocks, SocietyBlocksDto>();
            CreateMap<Seller, GetSellerDto>();
            CreateMap<PlotSize, AddPlotSizeDto>();
            CreateMap<Buyyer, GetBuyyerDto>();
            CreateMap<Landlord, GetLandlordDto>();
            CreateMap<Tenant, GetTenantDto>();
           
        }
    }
}
