   M S B A M L   `   `   `  ����L  HMoneyManager.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MoneyManager.Main.ViewsMoneyManager.Main.Views  5      K*clr-namespace:MoneyManager.Main.ComponentsMoneyManager.Main.Components  5      #    MoneyManager.Main.Views.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:MoneyManager.Main.Views     5      A
components*clr-namespace:MoneyManager.Main.Components     5      $	��600��5	        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �� $��170,25,170,25q�6    �� Padding$ 40 10q�6$   $	��480��64   $��Center=�5   	   $��Center=�5   	   $��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Color$
 Gray��6/   ��5   
   �� 5      .��5      �  � Color$ #7be9f6��6    � Offset$	 0.0Q�6/   � 5      $ #ff8a80��6   $ 1Q�6/   5      ._�5!   
   �  � IsSharedSizeScope . 	 � RowDefinitions	 5"      �� 5#      $
��auto �6    �� 5$      $
��auto �6    �� 5%      $
��auto �6    �� 5&      $
��auto �6    .+�5(      �� $��/Assets/money.png��6   $	��110��6/   �� 5*      $��1��6   $��Center=�5+      $��32(�5,      $��Money Manager��5-      �� 5/      $��2��6   $
��0 10q�6%   $��Center=�50      $
��17.5(�51      $
��Thin"�52      $j��dНельзя гоняться за деньгами — нужно идти им навстречу.��53      � 55      $��3��6   $
��0 10q�6    	 56      �� 57      $
��auto �6$   �� 58      $
��auto �6$   �� 59      $
��auto �6$   �� 5:      $
��auto �6$   �� 5;      $
��auto �6$   .+�5>      � $��0��6   $��Center=�6$   $��-40 15 0 10q�6A   
 � ColumnDefinitions
 5?      �� 5@      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5A      $	��230 �6+   .+�5D      �� $��0��6    $%��Имя пользователя��60   $��	Helvetica)�5E       $��20(�5F      $��Center=�5G      ���#1f4247
������ $��25��5J      �� 5K      $��1��6   $��20 0 0 0q�6.   $��	Helvetica)�5L      $��20(�5M      ���#1f4247
������ ��5Q      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5S      � 5U      $��1��6   $��Center=�6$   $��-40 10 0 15q�6A   
 5V      �� 5W      $
��auto �6+   $ Label��68   �� 5X      $	��230 �6+   .+�5[      �� $��0��6    $��Пароль��60   $��	Helvetica)�5\       $��20(�5]      $��Center=�5^      ���#1f4247
������ $��25��5a      6   0MoneyManager.Main.Components.BindablePasswordBox  5b      $��1��65   $��20 0 0 0q�6E   $��	Helvetica)�5c   6   $��20(�5d      ���#1f4247
������    Password 5g      �� *
Password+$ PropertyChanged=�5h      �� 5i      $��2��6   $	��0 7q�6)   $��Center=�5j      
���  ��$��18(�5n       � DataContext 5k      �� *ErrorMessageViewModel+��5m      �� *	Message+y�5p      �� *
HasMessage+ �� 	Converter# [  �� 5q      $��3��6   $	��0 5q�6&   $��18(�63   $��Center=�5r      $��
Войти��5t       �� 	IsDefault . ��5s      �� *LoginCommand+5u      �� 5w      $��4��6   $��0 5 0 0q�6&   $��Center=�5x      
������ $��Register��5{      $(��"У Вас нет аккаунта?��5|      $��18(�5}      
����  ���5z      �� *UpdateViewCommand+5~      5�      5�      5�      5�      