   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       	WPF.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	     � Title$  Login��5   	   $	��300��6   $	��400��6$    � WindowStartupLocation$ CenterScreen=�60   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��	Username:��6-   $��Center=�6A   �� 5   
   -   5         ��Name$ txtUsername��5      $��0��6'   $��1��64   $��5q�6D   �� 5   
   $��1��6   $��0��6   $��	Password:��6-   $��Center=�6A   G� 5   
   -   5         G�Name$ txtPassword��5      $��1��6+   $��1��68   $��5q�6H   $y�Visible=�6S   �� 5   
   -   5        $ txtPasswordVisible��5      $��1��6.   $��1��6;   $��5q�6K   $y�	Collapsed=�6V   �� 5   
   -   5         ��Name$ chkShowPassword��5      $��2��6,   $��1��69   $��Show password��6I   $��5q�5      $��Center=�6   5       �� 5#   
   -   5        $��1��5#      $��Login��6!   $
��Left=�61   $��
46,31,0,45q�6L   $��3��6`   $��84��6m   6x   �� 5%   
   $��3��6   $��2��6!   $.��(* Only the host has access to the login.��5&      
���  ��$��	10,5,0,70q�5'   %   $��Italic$�5(      $��12(�6'   5+      5,      