namespace TransDev.Invoicing.Application.Common.Abstracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class ResponseBase
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
