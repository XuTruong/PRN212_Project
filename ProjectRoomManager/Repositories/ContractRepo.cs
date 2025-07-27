using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DTO;

namespace Repositories
{
    public class ContractRepo
    {
        RoomManagerContext _context;
        RoomRepo _roomRepo;

        public ContractRepo()
        {
            _context = new RoomManagerContext();
            _roomRepo = new RoomRepo();
        }

        public List<ContractDisplayDto> GetAllContracts()
        {

            var contracts = _context.Contracts
                .Include(c => c.Room)
                .Include(c => c.Tenant)
                .Include(c => c.RoomTenants)
                    .ThenInclude(rt => rt.Tenant)
                .ToList(); // Thực hiện truy vấn trước

            // ✅ Dựng DTO bằng C#
            var result = contracts.Select(c => new ContractDisplayDto
            {
                ContractId = c.ContractId,
                RoomName = c.Room?.RoomName,
                MainTenantName = c.Tenant?.FullName + " - " + c.Tenant?.IdNumber,
                Roommates = string.Join("\n",
        c.RoomTenants
            .Where(rt => rt.TenantId != c.TenantId)
            .Select(rt => rt.Tenant?.FullName + " - " + rt.Tenant?.IdNumber)
            .Where(name => !string.IsNullOrEmpty(name))
    ),

                //  Thêm dòng này để lấy danh sách ID người ở ghép
                TenantIdRoomate = c.RoomTenants
    .Where(rt => rt.TenantId.HasValue && rt.TenantId != c.TenantId)
    .Select(rt => rt.TenantId!.Value)
    .ToList(),

                StartDate = c.StartDate ?? default,
                EndDate = c.EndDate ?? default,
                Deposit = c.Deposit ?? 0,
                Note = c.Note ?? ""
            }).ToList();

            return result;
        }

        public List<ContractDisplayDto> GetAllActiveContracts()
        {
            var contracts = _context.Contracts
                .Include(c => c.Room)
                .Include(c => c.Tenant)
                .Include(c => c.RoomTenants)
                    .ThenInclude(rt => rt.Tenant)
                .Where(c => c.IsActive == true)
                .ToList(); // Thực hiện truy vấn trước

            // ✅ Dựng DTO bằng C#
            var result = contracts.Select(c => new ContractDisplayDto
            {
                ContractId = c.ContractId,
                RoomName = c.Room?.RoomName,
                MainTenantName = c.Tenant?.FullName + " - " + c.Tenant?.IdNumber,
                Roommates = string.Join("\n",
                    c.RoomTenants
                        .Where(rt => rt.TenantId != c.TenantId)
                        .Select(rt => rt.Tenant?.FullName + " - " + rt.Tenant?.IdNumber)
                        .Where(name => !string.IsNullOrEmpty(name))
                ),
                TenantIdRoomate = c.RoomTenants
    .Where(rt => rt.TenantId.HasValue && rt.TenantId != c.TenantId)
    .Select(rt => rt.TenantId!.Value)
    .ToList(),
                StartDate = c.StartDate ?? default,
                EndDate = c.EndDate ?? default,
                Deposit = c.Deposit ?? 0,
                Note = c.Note ?? ""
            }).ToList();

            return result;
        }

        public List<ContractDisplayDto> GetAllExpiredContracts()
        {
            var contracts = _context.Contracts
                .Include(c => c.Room)
                .Include(c => c.Tenant)
                .Include(c => c.RoomTenants)
                    .ThenInclude(rt => rt.Tenant)
                .Where(c => c.IsActive == false)
                .ToList(); // Thực hiện truy vấn trước

            // ✅ Dựng DTO bằng C#
            var result = contracts.Select(c => new ContractDisplayDto
            {
                ContractId = c.ContractId,
                RoomName = c.Room?.RoomName,
                MainTenantName = c.Tenant?.FullName + " - " + c.Tenant?.IdNumber,
                Roommates = string.Join("\n",
                    c.RoomTenants
                        .Where(rt => rt.TenantId != c.TenantId)
                        .Select(rt => rt.Tenant?.FullName + " - " + rt.Tenant?.IdNumber)
                        .Where(name => !string.IsNullOrEmpty(name))
                ),
                TenantIdRoomate = c.RoomTenants
    .Where(rt => rt.TenantId.HasValue && rt.TenantId != c.TenantId)
    .Select(rt => rt.TenantId!.Value)
    .ToList(),
                StartDate = c.StartDate ?? default,
                EndDate = c.EndDate ?? default,
                Deposit = c.Deposit ?? 0,
                Note = c.Note ?? ""
            }).ToList();

            return result;
        }

        public List<ContractDisplayDto> SearchContract(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllContracts();
            }

            var lowerKeyword = keyword.ToLower();

            var contracts = _context.Contracts
                .Include(c => c.Room)
                .Include(c => c.Tenant)
                .Include(c => c.RoomTenants)
                    .ThenInclude(rt => rt.Tenant)
                .Where(c =>
                    (c.Room.RoomName != null && c.Room.RoomName.ToLower().Contains(lowerKeyword)) ||
                    (c.Tenant.FullName != null && c.Tenant.FullName.ToLower().Contains(lowerKeyword)) ||
                    (c.Tenant.IdNumber != null && c.Tenant.IdNumber.Contains(lowerKeyword)) ||
                    c.RoomTenants.Any(rt =>
                        (rt.Tenant.FullName != null && rt.Tenant.FullName.ToLower().Contains(lowerKeyword)) ||
                        (rt.Tenant.IdNumber != null && rt.Tenant.IdNumber.Contains(lowerKeyword))
                    )
                )
                .ToList();

            var result = contracts.Select(c => new ContractDisplayDto
            {
                ContractId = c.ContractId,
                RoomName = c.Room?.RoomName,
                MainTenantName = c.Tenant?.FullName + " - " + c.Tenant?.IdNumber,
                Roommates = string.Join("\n",
                    c.RoomTenants
                        .Where(rt => rt.TenantId != c.TenantId)
                        .Select(rt => rt.Tenant?.FullName + " - " + rt.Tenant?.IdNumber)
                        .Where(name => !string.IsNullOrEmpty(name))
                ),
                TenantIdRoomate = c.RoomTenants
                    .Where(rt => rt.TenantId.HasValue && rt.TenantId != c.TenantId)
                    .Select(rt => rt.TenantId!.Value)
                    .ToList(),
                StartDate = c.StartDate ?? default,
                EndDate = c.EndDate ?? default,
                Deposit = c.Deposit ?? 0,
                Note = c.Note ?? ""
            }).ToList();

            return result;
        }

        public void createContract(Contract contract, int roomId)
        {
            _context.Contracts.Add(contract);
            _roomRepo.UpdateAfterHaveContract(roomId);
            _context.SaveChanges();
        }

        public void AddRoomTenant(RoomTenant roomTenant)
        {
            _context.RoomTenants.Add(roomTenant);
            _context.SaveChanges();
        }

        public void RemoveRoomate(List<int> tenantId)
        {
            foreach (var tenant in tenantId)
            {
                var RoomTenant = _context.RoomTenants.FirstOrDefault(rt => rt.TenantId == tenant);

                _context.RoomTenants.Remove(RoomTenant);
                _context.SaveChanges();
            }

        }

        public void EndContract(int contractId, string roomName)
        {
            var contract = _context.Contracts.FirstOrDefault(c => c.ContractId == contractId);
            contract.IsActive = false;
            var room = _context.Rooms.FirstOrDefault(r => r.RoomName.Equals(roomName));
            room.Status = "Trống";
            _context.SaveChanges();
        }

        public int ChangeRoomIdToContractId(int roomId)
        {
            var contarct = _context.Contracts.FirstOrDefault(c => c.TenantId == roomId);
            return contarct.ContractId;
        }
    }
}
