using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Abstracts;
using TransDev.Invoicing.Application.Common.Dtos;

namespace TransDev.Invoicing.Application.Items.Queries.GetActiveItems
{
    public class GetActiveItemsResponse : ResponseBase
    {
        public ItemDto[] Items { get; set; }
    }
}
