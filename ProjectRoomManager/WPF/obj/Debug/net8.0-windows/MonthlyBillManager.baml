   M S B A M L   `   `   `  ����  WPF    WPF.MonthlyBillManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$(  "Quản lý Hóa Đơn Hàng Tháng��5   	   $	��550��6,   $
��1000��69    � WindowStartupLocation$ CenterScreen=�5   	   ���#f4f6f9.��5      � $��10q�6   .+�5	   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 10q�66   $��0,0,0,10q�6C   ���#ddd$��1q�6h   ._�5
      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   $	��Top=�6M   $��10,6,0,0q�6e   $	��413��6w   .+�5      �� $��Tháng:��6   $��Center=�6)   �� 5      -   5         ��Name$ cbMonth��5      $��80��6,   $	��5,0q�67   $��30��6D   $��Center=�6P   .@�5      �� $��01��6#   �� 5      $��02��6#   �� 5      $��03��6#   �� 5      $��04��6#   �� 5      $��05��6#   �� 5      $��06��6#   �� 5      $��07��6#   �� 5      $��08��6#   �� 5      $��09��6#   �� 5      $��10��6#   �� 5      $��11��6#   �� 5      $��12��6#   5      �� 5      $��Năm:��6   $��Center=�6'   $��10,0,0,0q�6B   �� 5      -   5        $ cbYear��5      $	��100��6+   $	��5,0q�67   $��30��6D   �� 5      -   5        $��🔍 Xem��5      $	��100��6*   $��30��66   $��10,0,0,0q�6B   ���#2196F3
�������$
��Bold"�5   A   $��0q�5        � Cursor$
 Hand��6-   5!      5"      5#      �� 5&   
   $��1��6   
�������$ 10��61   ���#ccc$��1q�6V   $��	0,60,0,60q�5'      $
}�True��6$   ._�5(      &   System.Windows.Controls.DataGrid  -   5          Name$ dgMonthlyBills��5(         AutoGenerateColumns$ False��5)      	   CanUserAddRows$	 False��5+      
   
IsReadOnly$

 True��5,         RowHeaderWidth$ 0Q�5-         HeadersVisibility$ Column=�5.         GridLinesVisibility$
 None=�5/      
�������$��0q�51      $��5q�52         RowBackground �#ffffff   AlternatingRowBackground �#f9f9f9$��0q�55      $��14(�56      "   VerticalScrollBarVisibility$
 Auto=�57      ��5*      �� *MonthlyBills+   RowStyle 58      �� 59       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5:      �� 5;       �� Binding 6*   �� *IsPaid+ �� Value	 False6E   .a�5<   "   ��  �� Property � �� �� Value
 �  ��6?   �� 5=   "    � ��$
 Bold"�6?   5>      5@         Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ Phòng��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
RoomName+6U     5D      $ Tháng��6)   $ 80 6V    68   �� *	MonthYear+6V     5E      $ Điện cũ��6)   $ 70 6]    6:   �� *ElectricityOld+6]     5F      $ Điện mới��6)   $ 70 6^    6;   �� *ElectricityNew+6^     5G      $ Nước cũ��6)   $ 70 6W    6:   �� *
WaterOld+6W     5H      $ Nước mới��6)   $ 70 6X    6;   �� *
WaterNew+6X     5I      $ 
Giá thuê��6)   $ 80 6j    6;   �� *	RoomPrice+ �� StringFormat$ N0��6j     5J      $ Tổng tiền��6)   $	 100 6m    6<   �� *TotalAmount+$ N0��6m   4  .System.Windows.Controls.DataGridCheckBoxColumn  5K      $ 
Đã trả��6-   $ 60 6X    6=   �� *IsPaid+6X     5L      $ Ngày trả��6)   $	 100 6;    5M      �� 5N       �� Path$ PaymentDate�6&   $ 
dd/MM/yyyy��69   5P      5R      5S      �� 5V   
   $ 
Horizontal=�6   $��Center=�5W      $��Bottom=�5X      $��0,0,0,10q�5Y      .+�5[      �� -   5         ��Name$ btnCreateBill��5[      $!��🧾 Tạo Hóa Đơn Mới��5\      $	��180��5]      $��35��6!   ���#4CAF50
�������$
��Bold"�5_      $
��10,0q�6'   $��0q�5`      $
 Hand��6)   5a      �� 5b      -   5        $ btnEditBill��5b      $$��✏️ Cập Nhật Hóa Đơn��5c      $	��180��5d      $��35��6!   ���#FF9800
�������$
��Bold"�5f      $
��10,0q�6'   $��0q�5g      $
 Hand��6)   5h      5i      5j      5k      