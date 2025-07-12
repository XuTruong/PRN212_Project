using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

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

    }
}
