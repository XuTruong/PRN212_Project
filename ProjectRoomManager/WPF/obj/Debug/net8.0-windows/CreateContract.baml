   M S B A M L   `   `   `  ����  WPF    WPF.CreateContract   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Tạo Hợp Đồng��5   	   $	��600��6   $	��720��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\   ���#f0f2f5.��5      � $��20q�6   .+�5   
   ��  �� CornerRadius$ 10��6   
������� �� Padding$ 20q�66   ���#ccc$��1q�6V   ._�5      �� .+�5      �� $%��TẠO HỢP ĐỒNG THUÊ TRỌ��6   $��20(�69   $
��Bold"�6G   ���#333$��0,0,0,20q�6k   $��Center=�6}   � 5
      $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $	��160 �6+   �� 5      $��* �6+    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5      �� $��Phòng:��6    $��0��6.   $��0��6;   $��Center=�6K   $	��0,8q�6f   �� 5      -   5         ��Name$ cbRoom��5      $��0��6/   $��1��6<   $	��250��6L    �� DisplayMemberPath$ RoomName��6X   	 �� SelectedValuePath$	 RoomId��6u   $	��0,5q�6�   �� 5      $��Người thuê chính:��6    $��1��69   $��0��6F   $��Center=�6V   $	��0,8q�6q   �� 5      -   5        $ cbMainTenant��5      $��1��65   $��1��6B   $	��250��6R   $ DisplayInfo��6^   $	 TenantId��6~   $	��0,5q�6�   �� 5!      $��Ngày bắt đầu:��6    $��2��65   $��0��6B   $��Center=�6R   $	��0,8q�6m   (  "System.Windows.Controls.DatePicker  5"      -   5        
  Name$
 dpStartDate��5"   !   $��2��66   $��1��6C   $	��250��6S   $	��0,5q�6_   �� 5%      $��Ngày kết thúc:��6    $��3��66   $��0��6C   $��Center=�6S   $	��0,8q�6n     5&      -   5        $
 	dpEndDate��5&   !   $��3��64   $��1��6A   $	��250��6Q   $	��0,5q�6]   �� 5)      $��Tiền cọc (VNĐ):��6    $��4��67   $��0��6D   $��Center=�6T   $	��0,8q�6o   �� 5*      -   5         ��Name$ 
txtDeposit��5*      $��4��62   $��1��6?   $	��250��6O   $	��0,5q�6[   �� 5-      $��	Ghi chú:��6    $��5��60   $��0��6=   $	��Top=�6M   $��0,10,0,0q�6e   �� 5.      -   5        $ txtNote��5.      $��5��6/   $��1��6<   $��60��6L    �� TextWrapping$
 Wrap=�6X    �� AcceptsReturn$
 True��6l   $��	114,5,0,5q�6�   ���#f4f4f46�   5/      �� 52       �� Orientation$ 
Horizontal=�6   $��Right=�66   $��0,20,0,0q�6R   .+�53      �� -   5        $��Tạo Hợp Đồng��53      $	��150��64   $��35��6@   ���#0078D7
�������$��SemiBold"�54   E   $��0q�55       � Cursor$
 Hand��61    J� Effect 57      3  -System.Windows.Media.Effects.DropShadowEffect  58         Color$ Black��6/      Opacity$	 0.2Q�6=      ShadowDepth$ 3Q�6K   5:      5;      5<      5=      5>      5?      