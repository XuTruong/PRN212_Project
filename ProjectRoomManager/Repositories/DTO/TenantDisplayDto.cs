using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTO
{
    public class TenantDisplayDto
    {
        public int TenantId { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }  // CCCD
        public string PhoneNumber { get; set; }

        public string DisplayInfo => $"{FullName} - {IdNumber} - {PhoneNumber}";
    }
}
