using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransDev.Invoicing.Domain.Entities
{
    public class AuditTrail
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
    }
}
