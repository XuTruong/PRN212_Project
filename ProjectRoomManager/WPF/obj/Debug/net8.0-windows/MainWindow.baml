   M S B A M L   `   `   `  ����  WPF    WPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản Lý Nhà Trọ��5   	   $	��960��5   	   $	��600��6    � WindowStartupLocation$ CenterScreen=�5   	   ���#f3f6fd$��Segoe UI)�5   	    � 	Resources 5
      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   Color   
BlurRadius   ShadowDepth   Opacity  MenuCardButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius �� Padding J� SnapsToDevicePixels J� Effect �� TextAlignment
 � Tag �� Triggers P� Property P� Value��%x  &	        &	 [     7   7     5   
   $ #2d2d2d��5      $ 15Q�5      $ 4Q�5      $	 0.2Q�5      �� 5   
   " ��6,   .�5      ��  � ��$		 200��6&   �� 5       � ��$		 120��6'   �� 5       � ��$	 15q�6'   �� 5       � ��$	 16(�6)   �� 5       � ��	 �#2d34366+   �� 5       � ��
	 �����6+   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��$
	 Bold"�6+   �� 5       � ��$	 0q�60   �� 5       �@J�Effect8	   6'   �� 5       � ��	 5      �� 5       "
 ��6&   .R�5!      �� #��z��6!   $ 16��5"   !   $ 10q�5#   !   $
 True��5$   !   8  ._�5&      �� $��Center=�6)   $��Center=�6D   .+�5'   "   �� #��z��6,   $��24(�5(   ,   $
��Bold"�5)   ,   ���#3498db$ Center=�5+   ,   $��0,10,0,5q�5,   ,   �� 5-   "   #��z 6,   $��14(�5.   ,   ���#636e72$��Center=�50   ,   51      52      53      55       56      P� 57       �@J�IsMouseOver$
 True��61   . �58      ��  � ��	 �#d6eaff63   �� 59       � ��	 �#0077c263   5:      5<      5=      .��5?      � ��5A   
   �� 5B       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5C      �  � Color$ #e0ecf8��6    � Offset$ 0Q�6/   � 5D      $ #ffffff��6   $ 1Q�6/   5E      .+�5H   
   �� $��Center=�6   $��Center=�60   .+�5J      �� $!��📋  Quản Lý Nhà Trọ��6   $��36(�5K      $
��Bold"�5L      ���#2c3e50$��Center=�5N      $��	0,20,0,40q�5O      � 5R      $��Center=�6   .+�5S      �� -   5        $
��🏠��5S      $ Phòng��6&   #��[ 62   6_   �� 5T      -   5        $
��👤��5T      $ Người thuê��6&   #��[ 67   6d   �� 5U      -   5        $
��📑��5U      $ Hợp đồng��6&   #��[ 65   6b   �� 5V      -   5        $
��💡��5V      $ 
Hóa đơn��6&   #��[ 64   6a   �� 5W      -   5        $
��💳��5W      $ Thanh toán��6&   #��[ 67   6d   �� 5X      -   5        $
��📊��5X      $ 	Báo cáo��6&   #��[ 64   6a   5Y      5Z      5[      5\      