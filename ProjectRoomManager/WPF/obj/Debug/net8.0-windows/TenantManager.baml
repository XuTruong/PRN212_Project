   M S B A M L   `   `   `  ����  WPF    WPF.TenantManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Tenant Manager��5   	   $	��550��6    $	��950��6-    � WindowStartupLocation$ CenterScreen=�69   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5	      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $��Tenant Management��6(   $��24(�5      $
��Bold"�6"   $��Center=�5      $��0,0,0,10q�61   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgTenants��5   0   $��1��6   $��0��6       AutoGenerateColumns$ False��5         SelectionMode$ Single=�6/   $��0,0,10,0q�5   A      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 40 6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *
TenantId+6N     5!      $
 Name��6%   $		 150 6P   
 63   �� *
FullName+6P     5"      $ Gender��6%   $	 80 6P   
 65   �� *Gender+6P     5#      $ Phone��6%   $		 100 6T   
 64   �� *PhoneNumber+6T     5$      $ 	ID Number��6%   $		 100 6U   
 68   �� *
IdNumber+6U     5%      $ 	Birthdate��6%   $		 100 6i   
 68   �� *Dob+ �� StringFormat$ 
dd/MM/yyyy��6i     5&      $ Address��6%   $		 200 6R   
 66   �� *	Address+6R     5'      $ Status��6%   $	 70 6R   
 65   �� *
IsActive+6R   5)      �� 5,   
   $��1��6   $��1��6"   $��0,0,0,10q�62   .+�5-      �� $��Tenant Info��6   $
��Bold"�6+   $��16(�6=   $��0,0,0,10q�6K   �� 5/      $��	Full Name��6   �� 50      -   5         ��Name$ txtFullName��50      $��0,0,0,10q�6+   �� 52      $��Gender��6   �� 53      -   5         ��Name$ 	cmbGender��53      $��0,0,0,10q�6*   .@�54      �� $
��Male��6   �� 55      $��Female��6   �� 56      $��Other��6   57      �� 5:      $��Phone Number��6   �� 5;      -   5        $ txtPhone��5;      $��0,0,0,10q�6(   �� 5=      $��ID Number (CCCD)��6   �� 5>      -   5        $ txtIdNumber��5>      $��0,0,0,10q�6+   �� 5@      $��Date of Birth��6   (  "System.Windows.Controls.DatePicker  5A      -   5          Name$ dpDob��5A      $��0,0,0,10q�6(   �� 5C      $��Address��6   �� 5D      -   5        $ 
txtAddress��5D      $��0,0,0,10q�6*   �� 5F      -   5         ��Name$ chkIsActive��5F      $��Currently Renting��6,    d� 	IsChecked$
 TrueY�6H   $��0,0,0,10q�6Y   �� 5G      -	   5        $��Refresh��5G      $	��100��6'    J� RenderTransformOrigin$ 1.436,3.269&�6L   5H      �� 5K   
   $��2��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��0,10,0,0q�6l   .+�5L      �� -
   5        $	��Add��5L      $	��100��6#   $��5q�6/   6:   �� 5M      -   5        $
��Edit��5M      $	��100��6$   $��5q�60   6;   �� 5N      -   5        $��Delete��5N      $	��100��6&   $��5q�62   6=   �� 5O      -   5        $ 	txtSearch��5O      $	��150��6)   $��10,0,5,0q�65   6H   �� 5P      -   5        $��Currently Renting��5P      $	��130��61   $��5q�6=   6H   �� 5Q      -   5        $��No Longer Renting��5Q      $	��140��61   $��5q�6=   6H   �� 5R      -   5        $��Show All��5R      $	��100��6(   $��5q�64   6?   5S      5T      5U      