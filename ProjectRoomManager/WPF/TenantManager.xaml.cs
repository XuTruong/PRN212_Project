using System.Windows;
using System.Windows.Controls;
using DataAccess.Models;
using Services;

namespace WPF
{
    /// <summary>
    /// Logic tương tác cho TenantManager.xaml
    /// </summary>
    public partial class TenantManager : Window
    {
        TenantService tenantService;

        public TenantManager()
        {
            InitializeComponent();
            tenantService = new TenantService();
            dgTenants.ItemsSource = tenantService.GetAllTenants(); // Hiển thị danh sách người thuê
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

                // Thiết lập giới tính
                if (selected.Gender != null)
                {
                    cmbGender.SelectedItem = cmbGender.Items.Cast<ComboBoxItem>()
                        .FirstOrDefault(i => i.Content.ToString().Trim() == selected.Gender);
                }
                else
                {
                    cmbGender.SelectedItem = null;
                }

                // Thiết lập trạng thái
                chkIsActive.IsChecked = selected.IsActive;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var result = tenantService.GetAllTenants()
                          .Where(t => (t.FullName ?? "").ToLower().Contains(keyword)
                                   || (t.PhoneNumber ?? "").Contains(keyword)
                                   || (t.IdNumber ?? "").Contains(keyword))
                          .ToList();
            dgTenants.ItemsSource = result;
        }

        private void btnActiveOnly_Click(object sender, RoutedEventArgs e)
        {
            dgTenants.ItemsSource = tenantService.GetActiveTenants(); // Chỉ hiển thị người đang thuê
        }

        private void btnInactiveOnly_Click(object sender, RoutedEventArgs e)
        {
            dgTenants.ItemsSource = tenantService.GetInactiveTenants(); // Người đã ngừng thuê
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            dgTenants.ItemsSource = tenantService.GetAllTenants(); // Hiển thị tất cả
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
            ClearInputs(); // Xóa form nhập liệu
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
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidFullName(txtFullName.Text))
            {
                MessageBox.Show("Họ tên chỉ được chứa chữ cái và khoảng trắng.", "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtIdNumber.Text))
            {
                MessageBox.Show("Số CCCD chỉ được chứa chữ số.", "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dgTenants.SelectedItem is Tenant selected)
            {
                // Cập nhật thông tin
                selected.FullName = txtFullName.Text;
                selected.PhoneNumber = txtPhone.Text;
                selected.IdNumber = txtIdNumber.Text;
                selected.Address = txtAddress.Text;
                selected.IsActive = chkIsActive.IsChecked == true;

                if (cmbGender.SelectedItem is ComboBoxItem genderItem)
                    selected.Gender = genderItem.Content.ToString();

                if (dpDob.SelectedDate.HasValue)
                    selected.Dob = DateOnly.FromDateTime(dpDob.SelectedDate.Value);

                tenantService.UpdateTenant(selected);
                MessageBox.Show("Cập nhật người thuê thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);

                dgTenants.ItemsSource = tenantService.GetAllTenants();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người thuê để chỉnh sửa.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidFullName(txtFullName.Text))
            {
                MessageBox.Show("Họ tên chỉ được chứa chữ cái và khoảng trắng.", "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(txtIdNumber.Text))
            {
                MessageBox.Show("Số CCCD chỉ được chứa chữ số.", "Dữ liệu không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var existingTenants = tenantService.GetAllTenants();
            if (existingTenants.Any(t => t.IdNumber == txtIdNumber.Text))
            {
                MessageBox.Show("Số CCCD đã tồn tại. Vui lòng nhập số khác.", "Trùng lặp", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            MessageBox.Show("Thêm người thuê thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);

            dgTenants.ItemsSource = tenantService.GetAllTenants();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTenants.SelectedItem is not Tenant selected)
            {
                MessageBox.Show("Vui lòng chọn người thuê để xoá.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xoá người thuê này không?", "Xác nhận",
                                          MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm != MessageBoxResult.Yes) return;

            try
            {
                tenantService.DeleteTenant(selected.TenantId);
                MessageBox.Show("Xoá người thuê thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                dgTenants.ItemsSource = tenantService.GetAllTenants();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
