   M S B A M L   `   `   `  ����  WPF    WPF.ReportManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản lý Báo cáo��5   	   $	��700��6!   $
��1200��6.    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��20,10q�6;   .+�5      �� $��QUẢN LÝ BÁO CÁO��6   $��24(�6/   $
��Bold"�6=   
����  �$��Center=�5   .   5      �� 5   
   $��1��6   
�������$��10q�65    �� Padding$ 15q�6A   ._�5      �� .+�5      �� $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5      �� $��Loại báo cáo:��6    $��Center=�65   $	��100��6P   $
��Bold"�6\   �� 5      -   5         ��Name$ cmbReportType��5      $	��200��66   $	��5,0q�6B   .@�5      �� $��Báo cáo Doanh thu��6'   
 � Tag$ Revenue��6C   �� 5      $��Báo cáo Phòng��6'   $
 Room��6?   �� 5      $��Báo cáo Thanh toán��6'   $ Payment��6D   �� 5      $��Báo cáo Điện nước��6'   $ Utility��6C   �� 5      $��Thống kê phòng��6'   $ RoomStatistics��6@   5      5      �� 5!      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5"      �� $��Từ ngày:��6    $��Center=�60   $	��100��6K   $
��Bold"�6W   (  "System.Windows.Controls.DatePicker  5#      -   5          Name$ 
dpFromDate��5#   !   $	��150��65   $	��5,0q�6A   �� 5%      $��Đến ngày:��6    $��Center=�61   $	��100��6L   $
��Bold"�6X   $��20,0,0,0q�6j     5&      -   5        $ dpToDate��5&   !   $	��150��63   $	��5,0q�6?   5'      �� 5)      $ 
Horizontal=�6   $��Center=�66   $��0,10,0,0q�6S   .+�5*      �� -   5         ��Name$ btnView��5*      $��Xem báo cáo��6.   $	��120��6D   $��35��6P   $��5q�5+      
�����F�
�������$
��Bold"�5,   G   �� 5-      -   5        $ 	btnExport��5-      $��Xuất Excel��60   $	��120��6E   $��35��6Q   $��5q�5.      
��� � �
�������$
��Bold"�5/   C   �� 50      -   5        $ btnClose��50      $��Đóng��6/   $	��120��6>   $��35��6J   $��5q�51      
�������
�������$
��Bold"�52   B   53      54      55      �� 58   
   $��2��6   $��10q�6   
�������$��1q�6=   ._�59      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dgReport��59      
   AutoGenerateColumns$
 False��6)      CanUserAddRows$ False��5:         CanUserDeleteRows$ False��6.      GridLinesVisibility$	 All=�5;         HeadersVisibility$ Column=�61      AlternatingRowBackground
 ��ح�
�������   RowBackground
 �����5?      5@      5A      5B      