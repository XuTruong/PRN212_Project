   M S B A M L   `   `   `  ����  WPF    WPF.RoomManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản lý Phòng��5   	   $
��1000��5   	   $	��600��6    � WindowStartupLocation$ CenterScreen=�5   	   ���#f1f4f9$��Segoe UI)�5   	    � 	Resources 5
      3  -System.Windows.Media.Effects.DropShadowEffect 
  Shadow   Color   
BlurRadius   ShadowDepth   Opacity  PrimaryButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius J� Effect �� Triggers P� Property P� Value��%  &	        &	 H     7     5   
   $
 #000��6*   $ 10Q�67   $ 2Q�6G   $	 0.2Q�6W   �� 5   
   " ��6+   .�5      ��  � ��$		 120��6&   �� 5       � ��$	 40��6'   �� 5       � ��$	 10q�6'   �� 5       � ��$	 14(�6)   �� 5       � ��
	 �����6+   �� 5       � ��	 �#3498db6+   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��$	 0q�60   �� 5       � ��$
	 Bold"�6+   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� #��z��6!   $ 8��5   !   8   ._�5      �� $��Center=�6/   $��Center=�6L   5       5!      5#       5$      P� 5%       �@J�IsMouseOver$
 True��61   . �5&      ��  � ��	 �#2b7fc363   5'      5)      5*      .��5,      � $��20q�6    � ColumnDefinitions 5-   
   �� 5.      $��2* �6   �� 5/      $��* �6    � RowDefinitions 51   
   �� 52      $
��Auto �6   �� 53      $��* �6   �� 54      $
��Auto �6   .+�58   
   �� $��2��6   $��🛏️ Quản lý Phòng��6(   $��28(�59      $
��Bold"�6"   ���#2c3e50$��Center=�5;      $��0,0,0,20q�61   �� 5>   
   $��1��6   $��0��6   $��0,0,20,0q�6.   $ 10��6@   
������� �� Padding$ 10q�5?      # [  6   ._�5@      &   System.Windows.Controls.DataGrid  -   5          Name$ dgRooms��5@         AutoGenerateColumns$ False��5A         CanUserAddRows$ False��5B         HeadersVisibility$ Column=�5C         RowHeaderWidth$ 0Q�5D         GridLinesVisibility$ 
Horizontal=�5E         ColumnHeaderHeight$ 40Q�5F         SelectionMode$ Single=�5G      $��14(�5I         Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *RoomId+6P     5L      $ Tên Phòng��6)   $	 150 6Y    6<   �� *
RoomName+6Y     5M      $ Diện Tích��6)   $	 100 6U    6<   �� *Area+6U     5N      $ Giá (VNĐ)��6)   $	 120 6o    6<   �� *Price+ �� StringFormat$ 
{0:N0} ₫��6o     5O      $ Trạng Thái��6)   $	 120 6X    6=   �� *Status+6X   5Q      5R      �� 5U   
   $��1��6   $��1��6   
�������$ 10��6A   $ 15q�6S   # [  6`   ._�5V      �� .+�5W      �� $��🔍 Tìm theo tên��6   $��0,0,0,5q�63   $��SemiBold"�6D   �� 5X      -   5          ��Name$  	txtSearch��5X      $��0,0,0,10q�6Q   $��6q�6c   �� 5Z      $��📋 Thông tin phòng��6   $��16(�66   $
��Bold"�6D   $��	0,10,0,10q�6V   �� 5[      $��Tên phòng��6   �� 5\      -   5        $  txtRoomName��5\      $��0,0,0,10q�6/   $��6q�6A   �� 5^      $��Diện tích (m²)��6   �� 5_      -   5        $  txtArea��5_      $��0,0,0,10q�6+   $��6q�6=   �� 5a      $��Giá phòng (VNĐ)��6   �� 5b      -   5        $  txtPrice��5b      $��0,0,0,10q�6,   $��6q�6>   �� 5d      $��Trạng thái��6   �� 5e      -   5        ! ��Name$! 	cmbStatus��5e      $��0,0,0,10q�6.   $��6q�6@   .@�5f      �� $��Đang thuê��6#   �� 5g      $��Trống��6#   5h      5i      5j      �� 5m   
   $��2��6   $��2��6"   " �� Orientation$" 
Horizontal=�66   $��Center=�5n      $��0,20,0,0q�62   .+�5o      �� -   5        $��	➕ Thêm��5o      #��[ 6&   6R   �� 5p      -   5        $��✏️ Sửa��5p      #��[ 6&   6R   �� 5q      -	   5        $��🗑️ Xoá��5q      #��[ 6'   6S   �� 5r      -
   5        $��🔄 Làm mới��5r      #��[ 6*   6V   5s      5t      5u      