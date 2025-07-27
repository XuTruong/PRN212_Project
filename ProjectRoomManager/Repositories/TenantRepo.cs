using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repositories.DTO;

namespace Repositories
{
    public class TenantRepo
    {
        RoomManagerContext _context;

        public TenantRepo()
        {
            _context = new RoomManagerContext();
        }

        // CRUD
        public List<Tenant> GetAllTenants()
        {
            return _context.Tenants.ToList();
        }

        public Tenant GetTenantById(int tenantId)
        {
            return _context.Tenants.FirstOrDefault(t => t.TenantId == tenantId);
        }

        public void CreateTenant(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            _context.SaveChanges();
        }

        public void UpdateTenant(Tenant tenantUpdate)
        {
            _context.Tenants.Update(tenantUpdate);
            _context.SaveChanges();
        }

        public void DeleteTenant(int tenantId)
        {
            var tenant = _context.Tenants.FirstOrDefault(t => t.TenantId == tenantId);
            if (tenant == null)
                throw new Exception("Tenant not found.");
            tenant.IsActive = false; // Soft delete
            _context.SaveChanges();
        }

        public List<Tenant> GetActiveTenants()
        {
            return _context.Tenants
                           .Where(t => t.IsActive == true)
                           .ToList();
        }

        public List<Tenant> GetInactiveTenants()
        {
            return _context.Tenants
                           .Where(t => t.IsActive == false)
                           .ToList();
        }

        public List<Tenant> SearchTenants(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllTenants();
            }

            var lowerKeyword = keyword.ToLower();

            return _context.Tenants
                .Where(t => t.FullName.ToLower().Contains(lowerKeyword) ||
                            t.PhoneNumber.Contains(lowerKeyword) ||
                            t.IdNumber.Contains(lowerKeyword))
                .ToList();
        }


        public List<TenantDisplayDto> GetTenantDto()
        {
            // Chỉ lấy TenantId từ các hợp đồng còn hiệu lực
            var tenantIdsInActiveContracts = _context.Contracts
                .Where(c => c.IsActive == true)
                .Select(c => c.TenantId)
                .ToList();

            // Lấy danh sách người ở ghép hiện tại (có thể thêm điều kiện nếu cần)
            var roomTenantIds = _context.RoomTenants
                .Select(rt => rt.TenantId)
                .ToList();

            return _context.Tenants
                .Where(t => t.IsActive == true
                    && !tenantIdsInActiveContracts.Contains(t.TenantId)
                    && !roomTenantIds.Contains(t.TenantId))
                .Select(t => new TenantDisplayDto
                {
                    TenantId = t.TenantId,
                    FullName = t.FullName,
                    IdNumber = t.IdNumber,
                    PhoneNumber = t.PhoneNumber
                })
                .ToList();
        }
    }
}
