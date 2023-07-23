namespace TransDev.Invoicing.Application.Items.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class GetItemQuery : IRequest<ItemDto>
{
    public int Id { get; set; }
}

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDto>
{
    private readonly IItemService _itemService;

    public GetItemQueryHandler(IItemService itemService)
    {
        _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
    }

    public async Task<ItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemService.GetItemByIdAsync(request.Id, cancellationToken);
        var itemDto = new ItemDto(item);
        return itemDto;
    }
}
