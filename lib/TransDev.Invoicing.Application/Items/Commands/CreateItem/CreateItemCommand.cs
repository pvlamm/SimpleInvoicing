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

namespace TransDev.Invoicing.Application.Items.Commands
{
    public class CreateItemCommand : IRequest<CreateItemResponse>
    {
        public ItemDto Item { get; set; }
    }

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResponse>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateItemResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var itemHistory = _mapper.Map<ItemHistory>(request.Item);

            try
            {
                await _itemService.SaveChangesToItemSaveAsync(itemHistory);
                return new CreateItemResponse
                {
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new CreateItemResponse
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }
    }
}
