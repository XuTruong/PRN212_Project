   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.AddRoomate   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	     � Title$  Thêm người ở ghép��5   	   $	��600��6#   $
��1000��60    � WindowStartupLocation$ CenterScreen=�6=   ���#f4f6f9.��5
      � $��20q�6   .+�5   
   �� 
������� �� CornerRadius$ 14��6$    �� Padding$ 20q�66   ���#ddd$��1q�6V   ._�5      �� $��Stretch=�6   .+�5      �� $��THÊM NGƯỜI Ở GHÉP��6   $��24(�5      $
��Bold"�6*   ���#2c3e50$��0,0,0,20q�5      $��Center=�5      �� 5       �� Orientation$ 
Horizontal=�6   $��0,0,0,15q�66   .+�5      �� $��Người thêm:��6    $	��120��63   $��Center=�6?   $��14(�5       ���#5556.   �� 5      -   5         ��Name$ cbOtherTenants��5      $	��300��5      $��14(�5      $��30��5       �� DisplayMemberPath$ DisplayInfo��5       �� SelectedValuePath$ TenantId��5      5      �� 5!      $ 10��6   $��1q�6+   ���#ccc$��0,0,0,20q�6R   $ 3q�6d   ._�5"      &   System.Windows.Controls.DataGrid  -   5          Name$ dgContracts��5"      	   AutoGenerateColumns$	 False��5#      
   
IsReadOnly$

 True��5$         CanUserAddRows$ False��5%         	RowHeight$ 34Q�5&         ColumnHeaderHeight$ 40Q�5'         HeadersVisibility$ Column=�5(         GridLinesVisibility$ 
Horizontal=�5)      
�������   RowBackground
 �����   AlternatingRowBackground �#f9f9f9$��0q�5-      $��Stretch=�5.      $
��Auto=�5/       � 	Resources 50      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 52      "  6$   .�53   "   ��  � �� �#2980b96?   �� 54   "    � ��
 �����6?   �� 55   "    � ��$ SemiBold"�6?   �� 56   "    � ��$ 14(�6=   �� 57   "    � ��$ Center=�6O   �� 58   "    � ��$ 0q�6D   59      5:         Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ Phòng��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.2* 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *
RoomName+6]     5=      $ Người thuê chính��61   $ 2* 6n    6K   �� *MainTenantName+6n     5>      $ Người ở ghép��61   $ 2* 6e    6G   �� *	Roommates+6e     5?      $ Bắt đầu��61   $
 1.3* 6p    6B   �� *	StartDate+ �� StringFormat$ d��6p     5@      $ Kết thúc��61   $
 1.3* 6o    6C   �� *	EndDate+$ d��6o     5A      $ Tiền cọc��61   $
 1.5* 6x    6C   �� *	Deposit+$ 
{0:N0} ₫��6x     5B      $ Ghi chú��61   $ 3* 6[    6B   �� *Note+6[   5D      5E      �� 5H      $ 
Horizontal=�6   $
��Left=�66   .+�5I      �� -   5        $��➕ Thêm vào phòng��5I      $	��180��5J      $��40��6)   $
��Bold"�5K      $��14(�6/   ���#3498db
�������$��0q�5M       � Cursor$
 Hand��61   $��0,0,0,10q�5O       J� Effect 5P      3  -System.Windows.Media.Effects.DropShadowEffect  5Q         Color$ Black��6/      Opacity$	 0.2Q�6=      ShadowDepth$ 2Q�6K       
BlurRadius$  5Q�6[   5S      5T      5V      5W      5X       5[         WrapTextStyle��%�   &	        �� 5\   
   " ��6&   .�5]      ��  � ��$
 Wrap=�6-   �� 5^       � ��$ Center=�62   �� 5_       � ��$ 5,0,5,0q�6'   5`      5a      5b      