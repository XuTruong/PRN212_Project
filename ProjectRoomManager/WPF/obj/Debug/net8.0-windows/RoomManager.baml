   M S B A M L   `   `   `  ����  WPF    WPF.RoomManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  RoomManager��5   	   $	��500��6   $	��900��6*    � WindowStartupLocation$ CenterScreen=�66   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5	      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $��Room Management��6(   $��24(�5      $
��Bold"�6"   $��Center=�5      $��0,0,0,10q�61   � 5   
   $��1��6   $��0��6   $��0,0,10,0q�6,   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgRooms��5         AutoGenerateColumns$ False��6(      CanUserAddRows$ False��5         SelectionMode$ Single=�6.      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *RoomId+6P     5#      $	 	Room Name��6)   $	
 150 6Y    6<   �� *
RoomName+6Y     5$      $
	 Area��6)   $	
 100 6P    67   �� *Area+6P     5%      $	 Price (VNĐ)��6)   $	
 100 6q    6>   �� *Price+ �� StringFormat$ 
{0:N0} ₫��6q     5&      $	 Status��6)   $	
 100 6T    69   �� *Status+6T   5(      5)      �� 5,   
   $��1��6   $��1��6"   $��10,0,0,0q�62   .+�5-      �� $��Search by Name��6   �� 5.      -   5         ��Name$ 	txtSearch��5.      6)   �� 50      $��Room Information��6   $
��Bold"�60   $��16(�6B   $��	0,10,0,10q�6P   �� 51      $��	Room Name��6   �� 52      -   5        $ txtRoomName��52      $��0,0,0,10q�6+   �� 54      $��
Area (m²)��6   �� 55      -   5        $ txtArea��55      $��0,0,0,10q�6'   �� 57      $��Price (VNĐ)��6   �� 58      -   5        $ txtPrice��58      $��0,0,0,10q�6(   �� 5:      $��Status��6   �� 5;      -   5         ��Name$ 	cmbStatus��5;      $��0,0,0,10q�6*   .@�5<      �� $��	Available��6   �� 5=      $��Occupied��6   5>      5A      �� 5D   
   $��2��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�5E      $��0,10,0,0q�62   .+�5F      �� -   5        $��Add Room��5F      $	��100��6(   64   �� 5G      -   5        $��	Edit Room��5G      $	��100��6)   65   �� 5H      -	   5        $��Delete Room��5H      $	��100��6+   67   �� 5I      -
   5        $��Refresh��5I      $	��100��6'   63   5J      5K      5L      