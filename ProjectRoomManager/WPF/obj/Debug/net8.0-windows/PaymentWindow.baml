   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.PaymentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	     � Title$  Quản Lý Thanh Toán��5   	   $	��550��6$   $	��900��61    � WindowStartupLocation$ CenterScreen=�6=   ���#f9fafc$��14(�5	      .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0 0 0 10q�6.   $	��Top=�6@   .+�5      �� $��Tháng:��6   $��Center=�6%   �� 5      -   5         ��Name$ cbMonth��5      $��60��6(   $	��5 0q�63   $��28��6@   .@�5      �� $��01��6   �� 5      $��02��6   �� 5      $��03��6   �� 5      $��04��6   �� 5      $��05��6   �� 5      $��06��6   �� 5      $��07��6   �� 5      $��08��6   �� 5      $��09��6   �� 5      $��10��6   �� 5       $��11��6   �� 5!      $��12��6   5"      �� 5$      $��Năm:��6   $��Center=�6#   $��15,0,0,0q�6>   �� 5%      -   5        $ cbYear��5%      $	��100��6'   $	��5 0q�63   $��28��6@   �� 5'      -   5        $��🔍 Xem��5'      $��90��6&   $��28��61   $
��15 0q�6=   ���#4a90e2
�������$
��Bold"�5(   =   5)      5*      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ 
dgPayments��5-      $��1��6'   $��0 0 0 10q�64      AutoGenerateColumns$ False��5.         CanUserAddRows$ False��5/         HeadersVisibility$ Column=�50      	   RowHeaderWidth$	 0Q�51      
   ColumnHeaderHeight$
 30Q�52         	RowHeight$ 35Q�53         AlternatingRowBackground �#f0f4f8��55      �� *PaymentItems+   Columns 56      4  .System.Windows.Controls.DataGridCheckBoxColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$	 ✔��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
IsSelected+6S   0  *System.Windows.Controls.DataGridTextColumn  58      $ Phòng��6%   $ * 6Q    64   �� *
RoomName+6Q     59      $ Số tiền��6%   $ * 6b    66   �� *Amount+ �� StringFormat$ N0��6b     5:      $ Ngày thanh toán��6%   $ * 6y    6>   �� *PaymentDate+$ 
dd/MM/yyyy��6y     5;      $ Ghi chú��6%   $ 2* 6O    66   �� *Note+6O   5=      �� 5@   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0 10 0 0q�6W   .+�5A      �� -   5        $��📤 Xuất Excel��5A      $	��120��6-   $��35��69   $��0,0,10,0q�6E   ���#5cb85c
�������$
��Bold"�5B   =   5C      �� 5D      -   5        $��💾 Lưu Thanh Toán��5D      $	��160��61   $��35��6=   ���#0275d8
�������$
��Bold"�5E   =   5F      5G      5H      5I      