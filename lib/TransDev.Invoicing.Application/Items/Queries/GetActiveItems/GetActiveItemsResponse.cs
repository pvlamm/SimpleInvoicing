using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Abstracts;
using TransDev.Invoicing.Application.Common.Dtos;

namespace TransDev.Invoicing.Application.Items.Queries
{
    public class GetActiveItemsResponse : ResponseBase
    {
        [JsonRequired()]
        public ItemDto[] Items { get; set; }
    }
}
