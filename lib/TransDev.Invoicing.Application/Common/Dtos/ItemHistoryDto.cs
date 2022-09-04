namespace TransDev.Invoicing.Application.Common.Dtos;

using TransDev.Invoicing.Domain.Enums;

public class ItemHistoryDto// : IMapFrom<ItemHistory>
{
    //void IMapFrom<ItemHistory>.Mapping(Profile profile)
    //{
    //    profile.CreateMap<ItemHistory, ItemDto>()
    //        .ForMember(dest => dest.Code, opt => opt.MapFrom(a => a.Parent.Code))
    //        .ForMember(dest => dest.Type, opt => opt.MapFrom(a => a.Parent.Type))
    //        .ReverseMap();
    //}

    public long AuditTrailId { get; set; }
    public long? UpdatedAuditTrailId { get; set; }
    public int Id { get; set; }
    public string Code { get; set; }
    public ItemType Type { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
