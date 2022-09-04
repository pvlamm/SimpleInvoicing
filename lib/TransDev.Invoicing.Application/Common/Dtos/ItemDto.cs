namespace TransDev.Invoicing.Application.Common.Dtos;

using AutoMapper;

using TransDev.Invoicing.Application.Common.Mappings;
using TransDev.Invoicing.Domain.Entities;
using TransDev.Invoicing.Domain.Enums;

/*
Missing type map configuration or unsupported mapping.
Mapping types:
    ItemHistory -> ItemDto
    TransDev.Invoicing.Domain.Entities.ItemHistory -> TransDev.Invoicing.Application.Common.Dtos.ItemDto
 */
public class ItemDto : IMapFrom<ItemHistory>
{
    void IMapFrom<ItemHistory>.Mapping(Profile profile)
    {
        profile.CreateMap<ItemHistory, ItemDto>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(a => a.Parent.Code))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(a => a.Parent.Type))
            .ReverseMap();
    }

    public long Id { get; set; }
    public string Code { get; set; }
    public ItemType Type { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
