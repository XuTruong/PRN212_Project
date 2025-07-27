using System.Windows;
using System.Windows.Controls;
using DataAccess.Models;
using Services;

namespace WPF
{
    /// <summary>
    /// Giao diện xử lý cho RoomManager.xaml
    /// </summary>
    public partial class RoomManager : Window
    {
        RoomService roomService;

        public RoomManager()
        {
            InitializeComponent();
            roomService = new RoomService();
            dgRooms.ItemsSource = roomService.GetAllRooms(); // Hiển thị danh sách phòng
        }

        private void dgRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgRooms.SelectedItem is Room selected)
            {
                txtRoomName.Text = selected.RoomName;
                txtArea.Text = selected.Area.ToString();
                txtPrice.Text = selected.Price.ToString();

                cmbStatus.SelectedItem = cmbStatus.Items.Cast<ComboBoxItem>()
                    .FirstOrDefault(i => i.Content.ToString() == selected.Status);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var result = roomService.SearchRooms(keyword);
            dgRooms.ItemsSource = result; // Tìm kiếm phòng theo từ khóa
        }

        private void ClearInputs()
        {
            txtRoomName.Clear();
            txtArea.Clear();
            txtPrice.Clear();
            cmbStatus.SelectedIndex = -1;
            dgRooms.SelectedItem = null;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs(); // Xóa dữ liệu nhập
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text) ||
                string.IsNullOrWhiteSpace(txtArea.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(txtArea.Text.Trim(), out double area) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho Diện tích và Giá thuê.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dgRooms.SelectedItem is Room selected)
            {
                selected.RoomName = txtRoomName.Text.Trim();
                selected.Area = area;
                selected.Price = price;
                selected.Status = (cmbStatus.SelectedItem as ComboBoxItem).Content.ToString();
                roomService.UpdateRoom(selected);
                dgRooms.ItemsSource = roomService.GetAllRooms();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để chỉnh sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            roomService = new RoomService();
            if (string.IsNullOrWhiteSpace(txtRoomName.Text) ||
                string.IsNullOrWhiteSpace(txtArea.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(txtArea.Text.Trim(), out double area) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho Diện tích và Giá thuê.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string roomName = txtRoomName.Text.Trim();
            if (roomService.RoomExists(roomName))
            {
                MessageBox.Show("Tên phòng đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Room newRoom = new Room
            {
                RoomName = roomName,
                Area = area,
                Price = price,
                Status = (cmbStatus.SelectedItem as ComboBoxItem).Content.ToString()
            };

            roomService.CreateRoom(newRoom);
            MessageBox.Show("Thêm phòng thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            dgRooms.ItemsSource = roomService.GetAllRooms();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is not Room selected)
            {
                MessageBox.Show("Vui lòng chọn một phòng để xóa.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?", "Xác nhận",
                                  MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm != MessageBoxResult.Yes) return;

            try
            {
                roomService.DeleteRoom(selected.RoomId);
                MessageBox.Show("Xóa phòng thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                dgRooms.ItemsSource = roomService.GetAllRooms();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
