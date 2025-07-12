using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Services;

namespace WPF
{
    /// <summary>
    /// Interaction logic for RoomManager.xaml
    /// </summary>
    public partial class RoomManager : Window
    {
        RoomService roomService;
        public RoomManager()
        {
            InitializeComponent();
            roomService = new RoomService();
            dgRooms.ItemsSource = roomService.GetAllRooms();
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
            dgRooms.ItemsSource = result;
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
            ClearInputs();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtRoomName.Text) ||
                string.IsNullOrWhiteSpace(txtArea.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(txtArea.Text.Trim(), out double area) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Please enter valid numeric values for Area and Price.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dgRooms.SelectedItem is Room selected)
            {
                selected.RoomName = txtRoomName.Text.Trim();
                selected.Area = double.Parse(txtArea.Text.Trim());
                selected.Price = decimal.Parse(txtPrice.Text.Trim());
                selected.Status = (cmbStatus.SelectedItem as ComboBoxItem).Content.ToString();
                roomService.UpdateRoom(selected);
                dgRooms.ItemsSource = roomService.GetAllRooms();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a room to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtRoomName.Text) ||
                string.IsNullOrWhiteSpace(txtArea.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(txtArea.Text.Trim(), out double area) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Please enter valid numeric values for Area and Price.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Room newRoom = new Room
            {
                RoomName = txtRoomName.Text.Trim(),
                Area = area,
                Price = price,
                Status = (cmbStatus.SelectedItem as ComboBoxItem).Content.ToString()
            };

            roomService.CreateRoom(newRoom);
            MessageBox.Show("Room added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dgRooms.ItemsSource = roomService.GetAllRooms();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is not Room selected)
            {
                MessageBox.Show("Please select a room to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this room?", "Confirm",
                                  MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm != MessageBoxResult.Yes) return;

            try {
                roomService.DeleteRoom(selected.RoomId);
                MessageBox.Show("Room deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                dgRooms.ItemsSource = roomService.GetAllRooms();
                ClearInputs();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
