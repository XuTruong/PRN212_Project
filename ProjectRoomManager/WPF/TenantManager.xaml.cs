using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess.Models;
using Repositories;
using Services;
using static System.Windows.Forms.MonthCalendar;

namespace WPF
{
    /// <summary>
    /// Interaction logic for TenantManager.xaml
    /// </summary>
    public partial class TenantManager : Window
    {
        TenantService tenantService;

        public TenantManager()
        {
            InitializeComponent();
            tenantService = new TenantService();
            dgTenants.ItemsSource = tenantService.GetAllTenants();
        }

        private void dgTenants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTenants.SelectedItem is Tenant selected)
            {
                txtFullName.Text = selected.FullName;
                txtPhone.Text = selected.PhoneNumber;
                txtIdNumber.Text = selected.IdNumber;
                txtAddress.Text = selected.Address;

                dpDob.SelectedDate = selected.Dob.HasValue
                    ? selected.Dob.Value.ToDateTime(TimeOnly.MinValue)
                    : null;



                // Set Gender
                cmbGender.SelectedItem = cmbGender.Items.Cast<ComboBoxItem>()
                    .FirstOrDefault(i => i.Content.ToString().Trim() == selected.Gender);

                // Set IsActive checkbox
                chkIsActive.IsChecked = selected.IsActive;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var result = tenantService.GetAllTenants()
                          .Where(t => t.FullName.ToLower().Contains(keyword)
                                   || t.PhoneNumber.Contains(keyword)
                                   || t.IdNumber.Contains(keyword))
                          .ToList();
            dgTenants.ItemsSource = result;
        }

        private void btnActiveOnly_Click(object sender, RoutedEventArgs e)
        {
            dgTenants.ItemsSource = tenantService.GetActiveTenants();
        }

        private void btnInactiveOnly_Click(object sender, RoutedEventArgs e)
        {
            dgTenants.ItemsSource = tenantService.GetInactiveTenants();
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            dgTenants.ItemsSource = tenantService.GetAllTenants();
        }

        private void ClearInputs()
        {
            txtFullName.Clear();
            cmbGender.SelectedItem = null;
            txtPhone.Clear();
            txtIdNumber.Clear();
            txtAddress.Clear();
            dpDob.SelectedDate = null;
            chkIsActive.IsChecked = false;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtIdNumber.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                cmbGender.SelectedItem == null ||
                dpDob.SelectedDate == null ||
                chkIsActive == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            if (!IsValidFullName(txtFullName.Text))
            {
                MessageBox.Show("Full name should only contain letters and spaces.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtPhone.Text))
            {
                MessageBox.Show("Phone number must contain digits only.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtIdNumber.Text))
            {
                MessageBox.Show("ID Number (CCCD) must contain digits only.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dgTenants.SelectedItem is Tenant selected)
            {
                // Cập nhật dữ liệu từ form vào object selected
                selected.FullName = txtFullName.Text;
                selected.PhoneNumber = txtPhone.Text;
                selected.IdNumber = txtIdNumber.Text;
                selected.Address = txtAddress.Text;
                selected.IsActive = chkIsActive.IsChecked == true;

                // Lấy giới tính từ ComboBox
                if (cmbGender.SelectedItem is ComboBoxItem genderItem)
                {
                    selected.Gender = genderItem.Content.ToString();
                }

                // Ngày sinh
                if (dpDob.SelectedDate.HasValue)
                {
                    selected.Dob = DateOnly.FromDateTime(dpDob.SelectedDate.Value);
                }

                // Gọi service để update
                tenantService.UpdateTenant(selected);
                MessageBox.Show("Tenant updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh DataGrid
                dgTenants.ItemsSource = tenantService.GetAllTenants();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a tenant to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool IsDigitsOnly(string input)
        {
            return input.All(char.IsDigit);
        }

        private bool IsValidFullName(string input)
        {
            return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtIdNumber.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                cmbGender.SelectedItem == null ||
                dpDob.SelectedDate == null ||
                chkIsActive == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            if (!IsValidFullName(txtFullName.Text))
            {
                MessageBox.Show("Full name should only contain letters and spaces.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtPhone.Text))
            {
                MessageBox.Show("Phone number must contain digits only.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtIdNumber.Text))
            {
                MessageBox.Show("ID Number (CCCD) must contain digits only.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Tenant newTenant = new Tenant
            {
                FullName = txtFullName.Text,
                PhoneNumber = txtPhone.Text,
                IdNumber = txtIdNumber.Text,
                Address = txtAddress.Text,
                IsActive = chkIsActive.IsChecked,
                Gender = (cmbGender.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Dob = dpDob.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDob.SelectedDate.Value) : null
            };

            tenantService.CreateTenant(newTenant);
            MessageBox.Show("Tenant added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dgTenants.ItemsSource = tenantService.GetAllTenants();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTenants.SelectedItem is not Tenant selected)
            {
                MessageBox.Show("Please select a tenant to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this tenant?", "Confirm",
                                  MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm != MessageBoxResult.Yes) return;

            try
            {
                tenantService.DeleteTenant(selected.TenantId);
                MessageBox.Show("Tenant deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                dgTenants.ItemsSource = tenantService.GetAllTenants();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
