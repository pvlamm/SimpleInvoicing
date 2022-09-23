namespace TransDev.Invoicing.Application.Items.Queries;

using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class GetItemHistoryQuery : IRequest<GetItemHistoryResponse>
{
    public string Code { get; set; }
    public int? Id { get; set; }
}

public class GetItemHistoryHandler : IRequestHandler<GetItemHistoryQuery, GetItemHistoryResponse>
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public GetItemHistoryHandler(IItemService itemService, IMapper mapper)
    {
        _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetItemHistoryResponse> Handle(GetItemHistoryQuery request, CancellationToken cancellationToken)
    {
        var itemHistory = new List<ItemHistory>();
        if (request.Id.HasValue)
            itemHistory = (await _itemService.GetItemHistoryByItemIdAsync(request.Id.Value)).ToList();
        else
            itemHistory = (await _itemService.GetItemHistoryByCodeAsync(request.Code)).ToList();

        var itemHistoryArray = _mapper.Map<ItemHistoryDto[]>(itemHistory);
        return new GetItemHistoryResponse
        {
            Items = itemHistoryArray,
            Success = true
        };
    }
}
