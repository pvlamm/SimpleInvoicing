namespace TransDev.Invoicing.Application.Items.Queries.GetItem;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using TransDev.Invoicing.Application.Common.Interfaces;

public class GetItemQueryValidator : AbstractValidator<GetItemQuery>
{
    private readonly IItemService _itemService;

    public GetItemQueryValidator(IItemService itemService)
    {
        _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));

        RuleFor(x => x.Id)
            .Must(_itemService.ItemExists)
            .WithMessage("Item does not exist");
    }
}
