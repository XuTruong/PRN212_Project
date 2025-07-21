using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTO
{
    public class ContractDisplayDto
    {
        public int ContractId { get; set; }

        public List<int> TenantIdRoomate { get; set; } = new();
        public string RoomName { get; set; }
        public string MainTenantName { get; set; }
        public string Roommates { get; set; } // Danh sách người ở ghép, phân cách bởi dấu phẩy
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public decimal? Deposit { get; set; }
        public string? Note { get; set; }
    }
}
