   M S B A M L   `   `   `  ����L  HMoneyManager.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MoneyManager.MainMoneyManager.Main  5   	   "    MoneyManager.Main.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MoneyManager.Main     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  Money Manager��5	   	   $	��600��6   $
��1080��6/   $	��600��6?   $
��1080��6L    � Icon$ Assets/money.png��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $��* �6   6+   .+�5   
   � -   5         �Name$ GridMenu��5      $
��Left=�6!   $��0��6<   ��5      �� 5       �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value �#273d486E    �� Triggers 5      �� 5      	 �� Binding	 6&   �� *
IsLoggin+
 �� Value	
 False6C   .a�5      ��  � y�$ 	Collapsed=�6;   5      5(       � 	Resources 5+      ��%z   '��       �� 5,      " ��6   .�5-      ��  � ��$ Tahoma)�6=   �� 5.       � ��$ 18(�6;   5/      51      .+�52      �� $	��251��6   .+�53      �� $��Assets/6.jpg��6   $
��Fill=�6/   �� 55      $��0q�6   
�������$��18(�6:   $��Disabled=�6H   .@�56      �� $��40��6   $��0q�6)   $
��Left=�65   $��0q�6W   
�������$��Balance��6�   $	��251��6�   ��6�   �� *UpdateViewCommand+.��57      ��  �� Orientation$ 
Horizontal=�6%   .+�58      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountBalanceWallet=�66   $��20��6R   $��20��6]   
���\\��$��5q�6�   $��Center=�6�   �� 59      $��Баланс��6)   
���   �$��5q�6J   5:      5;      �� 5<      $��40��6   $��0q�6)   $��0q�65   $
��Left=�6J   
�������$��Schedule��6�   $	��251��6�   ��6�   �� *UpdateViewCommand+.��5=      �� $ 
Horizontal=�6%   .+�5>        $ Calendar=�66   $��20��6F   $��20��6Q   ���	#FFF08033$��5q�6t   $��Center=�6   �� 5?      
���   �$��5q�6=   '%Календарь изменений6]   5@      5A      �� 5B      $��40��6   $��0q�6)   $
��Left=�65   $��0q�6W   
�������$��
Statistics��6�   $	��251��6�   ��6�   �� *UpdateViewCommand+.��5C      �� $ 
Horizontal=�6%   .+�5D        $ 	DataUsage=�66   $��20��6G   $��20��6R   ���#1ABC9C$��5q�6t   $��Center=�6   �� 5E      
���   �$-��'Статистика изменений��6;   $��5q�6W   5F      5G      �� 5H      $��40��6   $��0q�6)   $
��Left=�65   $��0q�6W   
�������$��Settings��6�   $	��251��6�   ��6�   �� *UpdateViewCommand+.��5I      �� $ 
Horizontal=�6%   .+�5J        $ 
CreditCard=�66   $��20��6H   $��20��6S   ���#F1C40F$��5q�6t   $��Center=�6   �� 5K      
���   �$��Настройки��6<   $��5q�6M   5L      5M      5N      5O      5Q      � 5R   
   $��1��6   ��5S      �� 5T       �� Color$ #aed6dc��6"   .+�5V      �� ��6   �� *SelectedViewModel+ �� Mode$ TwoWay=�5Y      5Z      5[      