   M S B A M L   `   `   `  ����L  HMoneyManager.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MoneyManager.Main.ViewsMoneyManager.Main.Views  5      K*clr-namespace:MoneyManager.Main.ComponentsMoneyManager.Main.Components  5      &     MoneyManager.Main.Views.Register   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:MoneyManager.Main.Views     5      A
components*clr-namespace:MoneyManager.Main.Components     5      .��5      �� $��25q�6     �� Padding$  35,20q�6   $��Center=�5   	   $��Center=�5   	   $��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Color$
 Gray��6/   ��5   
   �� 5      .��5      �  � Color$ #7be9f6��6    � Offset$	 0.0Q�6/   � 5      $ #ff8a80��6   $ 1Q�6/   5      ._�5   
   �  � IsSharedSizeScope .  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5!      �� $��0��6   $
��0 10q�6%   $��Center=�5"      $��38(�5#      $��Money Manager��5$      �� 5&      $��1��6   $	��0,5q�6%   $��Center=�5'      $
��16.5(�5(      $
��Thin"�5)      $v��pВсякая экономия в конечном счете сводится к экономии времени��5*      � 5,      $��2��6   $��20,10q�6     5-      �� 5.      $
��auto �6$   �� 5/      $
��auto �6$   �� 50      $
��auto �6$   �� 51      $
��auto �6$   �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   	 � 	Resources	 56      
 �� 
TargetType �� Property �� Value��%�   '��       �� 57      "
 ��6   .�58      ��  � ��$ 	Helvetica)�67   �� 59       � ��$ 20(�65   �� 5:       � �� �#1f424767   �� 5;       � ��
 ���� 67   �� 5<       � ��$ Center=�6>   5=      5?      .+�5B      � $��0��6   $
��0,10q�6$    � ColumnDefinitions 5C      �� 5D      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5E      $	��220 �6+   .+�5H      �� $��0��6    $��Имя аккаунта��60   �� 5I      $��1��6   $��20,0,0,0q�6.   $��20(�6@   ��5J      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5K      � 5M      $��1��6   $
��0,10q�6$    5N      �� 5O      $
��auto �6+   $ Label��68   �� 5P      $	��220 �6+   .+�5S      �� $��0��6    $��Пароль��60   6   0MoneyManager.Main.Components.BindablePasswordBox  5T      $��1��65   $��20,0,0,0q�6E   $��20(�6W      Password 5U      �� *
Password+$ PropertyChanged=�5V      � 5X      $��2��6   $
��0,10q�6$    5Y      �� 5Z      $
��auto �6+   $ Label��68   �� 5[      $	��220 �6+   .+�5^      �� $��0��6    $)��#Подтвердите пароль��60     5_      $��1��65   $��20,0,0,0q�6E   $��20(�6W    5`      �� *ConfirmPassword+$ PropertyChanged=�5a      � 5b      $��3��6   $
��0,10q�6$    5c      �� 5d      $
��auto �6+   $ Label��68   �� 5e      $	��220 �6+   .+�5h      �� $��0��6    $(��"Ваш текущий баланс��60   �� 5i      $��1��6   $��20,0,0,0q�6.   $��20(�6@   ��5j      �� *	Balance+$ PropertyChanged=�5k      �� 5l      $��4��6   $��0,5,0,0q�6)   $��Center=�5m      $��18(�5n      
���  �� � DataContext 5o      �� *ErrorMessageViewModel+��5q      �� *	Message+y�5r      �� *
HasMessage+    BooleanToVisibilityConverter �� 	Converter# [  �� 5u      $��5��6   $��0,10,0 5q�6&   $��Center=�5v      $��Регистрация��5x       �� 	IsDefault . ��5w      �� *RegisterCommand+5y      �� 5{      $��6��6   $��0,5,0,0q�6&   $��Center=�5|      
������ $��Login��5      $/��)У Вас уже есть аккаунт?��5�      $��14(�5�      ���#6200EE��5~      �� *UpdateViewCommand+5�      5�      5�      5�      5�      