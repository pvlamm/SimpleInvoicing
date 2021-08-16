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

namespace TransDev.Invoicing.Application.Items.Queries
{
    public class GetActiveItemsQuery : IRequest<GetActiveItemsResponse>
    {
        public string SearchQuery { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }

    public class GetActiveItemsQueryHandler : IRequestHandler<GetActiveItemsQuery, GetActiveItemsResponse>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public GetActiveItemsQueryHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetActiveItemsResponse> Handle(GetActiveItemsQuery request, CancellationToken token)
        {
            var items = await _itemService.ItemLookup(request.SearchQuery, request.PageSize, request.Page);
            var dtos = _mapper.Map<ItemDto[]>(items);

            return new GetActiveItemsResponse
            {
                IsSuccess = true,
                Message = string.Empty,
                Items = dtos
            };
        }
    }
}
