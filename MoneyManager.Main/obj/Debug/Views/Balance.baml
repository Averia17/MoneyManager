   M S B A M L   `   `   `  ����L  HMoneyManager.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MoneyManager.Main.ViewsMoneyManager.Main.Views  5      K*clr-namespace:MoneyManager.Main.ViewModelsMoneyManager.Main.ViewModels  5	      %    MoneyManager.Main.Views.Balance   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:MoneyManager.Main.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5conv*clr-namespace:MoneyManager.Main.ViewModels  5	      -   5          >�Name$  BalanceControl��5
       � 	Resources 5      2   ,MoneyManager.Main.ViewModels.ObjectConverter   ObjectConverter��%   &	          5   
   6   5      .��5      � .+�5   
   � $	��Top=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�63   $��Center=�6N   $��	30 15 0 0q�6i   .+�5      �� $��	Helvetica)�5      ���#1f4247$��Ваш баланс ��5      $��25(�6(   6:   �� 5      $��	Helvetica)�5      ���#1f4247$��25(�5      $��10 0 0 0q�5      ��5      �� *	Balance+ �� Mode$ TwoWay=�5   0   5!      �� 5"      $��Right=�6   $	��5 0q�62   $��	0 15 20 0q�6@   $��FilterBalance��6z   ���#fb6a50���#273d48��6T   �� *UpdateViewCommand+.��5#      �� $ 
Horizontal=�6   .+�5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6.   $��5q�6<   $��18(�6G   $��Center=�6U   �� 5%      $��2 0 6 0q�6    $��18(�62   $��Center=�6@   
Поиск6b   5&      5'      5(      �� 5,   
   
������ $��0q�6Z   $��	0 60 0 0 q�6p   ��6   �� *HistoryCollectionView+ �� 
GroupStyle 5-      (  "System.Windows.Controls.GroupStyle  5.         ContainerStyle 5/      �� 50       �� 
TargetType" ��6$   .�51   "   ��  �� Property � ��	 �� Value$	 0,0,0,5q�6;   �� 52   "    � ��	 53   &   �� 54   *   
 �� 
TargetType"
 ��6:   .R�55   .   9�  9� 
IsExpanded . ���#ececec  MaterialDesignExpander#���  6_   $��0,0,0,1q�56   -   ��57   2   ]� 58   6   .+�59   :   �� $
��Bold"�6D   $��	Helvetica)�5:   @   $
��19.5(�5;   @   $��10,0,0,0q�5<   @   ���#1f4247$��
Дата: ��5>   @   �� 5?   :   $
��Bold"�6D   $��	Helvetica)�5@   @   ���#1f4247$
��19.5(�5C   @   ��5D   @   ��  �� Path$
 Name�5E   7   .��5G   2   �� 5H   /   5I   +   5K   #   5L      5N      ��5P      �� 5R      " ��6   .�5S      ��  � ��$	 50��6/   �� 5T       � ��$	 	10 0 50 0q�6/   �� 5U       � ��$	 15(�61   �� 5V       � ��	 5W      �� 5X      "
 ��6.   .R�5Y   "   �� #��z��6)   #��z��6S   #��z��6    �� CornerRadius$ 5��6�   ._�5Z   &   �  � ColumnDefinitions 5\   *   �� 5]   .   $	��12* �6?   �� 5^   .   $	��36* �6?   �� 5_   .   $	��25* �6?   �� 5`   .   $	��70* �6?   �� 5a   .   $	��13* �6?   �� 5b   .   $	��13* �6?   .+�5e   *   �� $��0��60   $��25��6@   $��Right=�6s   $��Center=�6�   ��6K   �� $ Activity.Image�6�   �� 5g   *   $��1��64   $��Center=�6d   $��5,0,0,0q�6�   ��6D   �� *Activity.Title+6�   �� 5h   *   $��2��65   $ 
Horizontal=�6E   .+�5i   .   �� $��Center=�6V   ��68   �� $ Amount�6V   �� 5j   .   $�� рублей��68   $��Center=�6H   5k   +   �� 5m   *   $��3��64   $
��Left=�6b   $��Center=�6~   ��6E   �� *Description+6~   �� 5q   *   $��4��61   $��5q�6B   $��Right=�6M   ���#545d78���#aed6dc��6�   �� *DataContext.LinkToEditCommand+ �� ElementName$ BalanceControl��$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6  �� ��62  0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ModeEdit=�6g  �� 5r   *   $��5��61   $��5q�6B   $��Right=�6M   ���#545d78���#ff341a��6�   �� *DataContext.DeleteCommand+$ BalanceControl��$ TwoWay=�$ PropertyChanged=���6  �� ��6.    *Delete+6\  5s   '   5t   #    �� Triggers 5u   "   P� 5v   &    P� Property �@J�IsMouseOver P� Value . . �5w   *   ��  � ��
	 �����6G   �� 5z   *    � ��$	 
17 0 50 0 q�6C   5{   '   P� 5|   &    �@��
IsSelected . . �5}   *   ��  � ��
	 �����6G   5~   '   �� 5   &    �� Value$ False��6�    �� Binding 62   �� $! Activity.ActivityType.Title� �� 	Converter# [  .a�5�   *   ��  � ��	 �#cce1b76G   5�   '   �� 5�   &   $
 True��6�    62   �� $! Activity.ActivityType.Title�# [  .a�5�   *   ��  � ��	 �#ffc2b36G   5�   '   5�      5�      5�      5�      � 5�   
   $��25q�6   $��Bottom=�6   $��Right=�66   .+�5�      �� $��CreateHistory��5�   ?   ���#fb6a50���#273d48 * &MaterialDesignFloatingActionDarkButton#���  5�      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible .    Value$ 1Q�5�         IsIndeterminate . ��5�      �� *UpdateViewCommand+��5�        *Add+5�      5�      5�      