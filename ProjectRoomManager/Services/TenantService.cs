using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.DTO;

namespace Services
{
    public class TenantService
    {
        private readonly TenantRepo tenantRepo;

        public TenantService()
        {
            tenantRepo = new TenantRepo();
        }

        public List<Tenant> GetAllTenants()
        {
            return tenantRepo.GetAllTenants();
        }

        public List<Tenant> GetActiveTenants()
        {
            return tenantRepo.GetActiveTenants();
        }

        public List<Tenant> GetInactiveTenants()
        {
            return tenantRepo.GetInactiveTenants();
        }

        public void UpdateTenant(Tenant tenantUpdate)
        {
            if (tenantUpdate == null)
                throw new ArgumentNullException(nameof(tenantUpdate));
            if (string.IsNullOrWhiteSpace(tenantUpdate.FullName))
                throw new ArgumentException("Full name is required.", nameof(tenantUpdate));
            if (string.IsNullOrWhiteSpace(tenantUpdate.PhoneNumber))
                throw new ArgumentException("Phone number is required.", nameof(tenantUpdate));
            tenantRepo.UpdateTenant(tenantUpdate);
        }

        public void CreateTenant(Tenant tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException(nameof(tenant));
            if (string.IsNullOrWhiteSpace(tenant.FullName))
                throw new ArgumentException("Full name is required.", nameof(tenant));
            if (string.IsNullOrWhiteSpace(tenant.PhoneNumber))
                throw new ArgumentException("Phone number is required.", nameof(tenant));
            tenantRepo.CreateTenant(tenant);
        }

        public void DeleteTenant(int tenantId)
        {
            if (tenantId <= 0)
                throw new ArgumentException("Invalid tenant ID.", nameof(tenantId));
            tenantRepo.DeleteTenant(tenantId);
        }

        public List<Tenant> SearchTenants(string keyword)
        {
            return tenantRepo.SearchTenants(keyword);
        }

        public List<TenantDisplayDto> GetTenantDisplayDtos()
        {
            return tenantRepo.GetTenantDto();
        }
    }
}
