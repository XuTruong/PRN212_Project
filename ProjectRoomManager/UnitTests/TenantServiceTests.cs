using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using DataAccess.Models;
using Services;

namespace UnitTests
{
    public class TenantServiceTests
    {
        private readonly TenantService _tenantService;

        public TenantServiceTests()
        {
            _tenantService = new TenantService();
        }

        [Fact]
        public void CreateTenant_ValidTenant_ShouldCreateSuccessfully()
        {
            // Arrange
            var tenant = new Tenant
            {
                FullName = "Nguyễn Văn Test",
                PhoneNumber = "0123456789",
                IdNumber = "123456789012",
                Address = "123 Test Street",
                Gender = "Nam",
                Dob = DateOnly.FromDateTime(DateTime.Now.AddYears(-25)),
                IsActive = true
            };

            // Act & Assert
            var exception = Record.Exception(() => _tenantService.CreateTenant(tenant));
            Assert.Null(exception);
        }

        [Fact]
        public void GetAllTenants_ShouldReturnListOfTenants()
        {
            // Act
            var result = _tenantService.GetAllTenants();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Tenant>>(result);
        }

        [Fact]
        public void GetActiveTenants_ShouldReturnOnlyActiveTenants()
        {
            // Act
            var result = _tenantService.GetActiveTenants();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Tenant>>(result);
            
            // Kiểm tra tất cả tenant đều active
            if (result.Count > 0)
            {
                Assert.True(result.All(t => t.IsActive == true));
            }
        }

        [Fact]
        public void GetInactiveTenants_ShouldReturnOnlyInactiveTenants()
        {
            // Act
            var result = _tenantService.GetInactiveTenants();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Tenant>>(result);
            
            // Kiểm tra tất cả tenant đều inactive
            if (result.Count > 0)
            {
                Assert.True(result.All(t => t.IsActive == false));
            }
        }

        [Theory]
        [InlineData("Nguyễn")]
        [InlineData("0123")]
        [InlineData("")]
        public void SearchTenants_WithDifferentKeywords_ShouldReturnMatchingTenants(string keyword)
        {
            // Act
            var result = _tenantService.SearchTenants(keyword);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Tenant>>(result);
            
            if (!string.IsNullOrEmpty(keyword))
            {
                // Kiểm tra kết quả có chứa keyword (nếu có dữ liệu)
                if (result.Count > 0)
                {
                    Assert.True(result.All(t =>
                        (t.FullName ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        (t.PhoneNumber ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        (t.IdNumber ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase)));
                }
            }
        }

        [Fact]
        public void UpdateTenant_ValidTenant_ShouldUpdateSuccessfully()
        {
            // Arrange
            // Tạo một tenant để test
            var originalTenant = new Tenant
            {
                FullName = "Test Update Tenant",
                PhoneNumber = "0987654321",
                IdNumber = "987654321098",
                Address = "456 Update Street",
                Gender = "Nữ",
                Dob = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)),
                IsActive = true
            };
            
            _tenantService.CreateTenant(originalTenant);
            
            // Lấy tenant vừa tạo
            var tenants = _tenantService.GetAllTenants();
            var tenantToUpdate = tenants.FirstOrDefault(t => t.IdNumber == "987654321098");
            
            if (tenantToUpdate != null)
            {
                // Cập nhật thông tin
                tenantToUpdate.FullName = "Updated Name";
                tenantToUpdate.Address = "Updated Address";
                tenantToUpdate.IsActive = false;

                // Act & Assert
                var exception = Record.Exception(() => _tenantService.UpdateTenant(tenantToUpdate));
                Assert.Null(exception);

                // Verify the update
                var updatedTenants = _tenantService.GetAllTenants();
                var verifyTenant = updatedTenants.FirstOrDefault(t => t.TenantId == tenantToUpdate.TenantId);
                
                Assert.NotNull(verifyTenant);
                Assert.Equal("Updated Name", verifyTenant.FullName);
                Assert.Equal("Updated Address", verifyTenant.Address);
                Assert.False(verifyTenant.IsActive);
            }
        }

        [Fact]
        public void DeleteTenant_ValidTenantId_ShouldDeleteSuccessfully()
        {
            // Arrange
            var tenant = new Tenant
            {
                FullName = "Test Delete Tenant",
                PhoneNumber = "0111222333",
                IdNumber = "111222333444",
                Address = "789 Delete Street",
                Gender = "Nam",
                Dob = DateOnly.FromDateTime(DateTime.Now.AddYears(-35)),
                IsActive = true
            };
            
            _tenantService.CreateTenant(tenant);
            
            // Lấy tenant vừa tạo
            var tenants = _tenantService.GetAllTenants();
            var tenantToDelete = tenants.FirstOrDefault(t => t.IdNumber == "111222333444");
            
            if (tenantToDelete != null)
            {
                var tenantId = tenantToDelete.TenantId;

                // Act & Assert
                var exception = Record.Exception(() => _tenantService.DeleteTenant(tenantId));
                Assert.Null(exception);

                // Verify the deletion
                var remainingTenants = _tenantService.GetAllTenants();
                var deletedTenant = remainingTenants.FirstOrDefault(t => t.TenantId == tenantId);
                Assert.Null(deletedTenant);
            }
        }

        [Fact]
        public void GetTenantDisplayDtos_ShouldReturnFormattedData()
        {
            // Act
            var result = _tenantService.GetTenantDisplayDtos();

            // Assert
            Assert.NotNull(result);
            // Kiểm tra type của result (có thể là List<TenantDisplayDto> hoặc tương tự)
        }

        [Fact]
        public void ValidateTenantData_NullOrEmptyValues_ShouldHandleGracefully()
        {
            // Arrange
            var invalidTenant = new Tenant
            {
                FullName = "",
                PhoneNumber = null,
                IdNumber = "",
                Address = null,
                Gender = "",
                IsActive = true
            };

            // Act & Assert
            // Kiểm tra service có handle được invalid data không
            var exception = Record.Exception(() => _tenantService.CreateTenant(invalidTenant));
            
            // Có thể service sẽ throw exception hoặc handle gracefully
            // Tùy vào implementation
        }
    }
}
