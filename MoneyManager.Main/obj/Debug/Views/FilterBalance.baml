   M S B A M L   `   `   `  ����L  HMoneyManager.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MoneyManager.Main.ViewsMoneyManager.Main.Views  5      K*clr-namespace:MoneyManager.Main.ViewModelsMoneyManager.Main.ViewModels  5   W   +    %MoneyManager.Main.Views.FilterBalance   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:MoneyManager.Main.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5conv*clr-namespace:MoneyManager.Main.ViewModels  6W     � 	Resources  5	      2   ,MoneyManager.Main.ViewModels.ObjectConverter   ObjectConverter��%   &	          5
   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   � $	��Top=�6   $��0��6(   $��Center=�65   $��0,5,0,0q�6R   .+�5      �� $��0q�6    % !MaterialDesignFloatingHintTextBox#��[ 6"   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Введите категорию��6]   $��22(�6�   $��Center=�6�   ��6�   �� *HistoriesFilter+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      � 5   
   $��1��6   $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      (  "System.Windows.Controls.DatePicker  $��22(�6d   $	��140��6r      SelectedDate 6   �� *TbFrom+$ PropertyChanged=�6r     5      $��60,0,0,0q�6b   $��22(�6t   $	��140��6�    6   �� *TbTo+$ PropertyChanged=�6�   5!      5"      � 5#   
   $��2��6   $	��0,5q�6   $��0��6*   $��Center=�6:   .+�5$      	�  . *MaterialDesignChoiceChipOutlineRadioButton#���  6   ���#ff0000 J� Opacity$ 2Q�6t    	� 	GroupName$ ActivityTypes��6�   $��22(�6�   $��38��6�   $0��*Выбрать только расходы��6�   ��6�   �� *ChangeRadioButtonCommand+��6  �� *ActivityTypeExpence+5%      � 5&   
   $��2��6   $	��0,5q�6   $��1��6*   $��Center=�6:   .+�5(      	� #���  6   ���#008000$ 2Q�6w   $ ActivityTypes��6�   $��22(�6�   $��38��6�   $.��(Выбрать только доходы��6�   ��6�   �� *ChangeRadioButtonCommand+��6  �� *ActivityTypeEncome+5*      � 5+   
   $��2��6   $��40,20q�6"   $��1��62    5,      �� 5-      6"   �� 5.      6"   �� 5/      6"   .+�51      � $��0��6   $��
20,0, 0, 0q�6    .+�52      �� $��Bottom=�6   $ 
Horizontal=�6:   .+�53      �� $��20(�6    $��0,0,20,0q�6/   
Доход6H   �� 54      $��20(�6    ��6/   �� *Encome+6I   55      57      � 59      $��1��6   $��20, 0, 0, 0q�6    .+�5:      �� $��Center=�6   $ 
Horizontal=�68   .+�5;      �� $��20(�6    $��0,0,20,0q�6/   Расход6I   �� 5<      $��20(�6    ��6/   �� *	Expense+6J   5=      5?      � 5A      $��2��6   $��20, 0, 0, 0q�6    .+�5B      �� $	��Top=�6   $ 
Horizontal=�66   .+�5C      �� $��20(�6    $��0,0,20,0q�6/   #!Изменение баланса6T   �� 5D      $��20(�6    ��6/   �� *
Difference+6M   5F      5H      5I      � 5J   
   $��3��6   $��2��6   .+�5K      �� 
������ $��0q�6m   ��6   �� *HistoriesCollectionView+	 �� Mode$	 TwoWay=�
 �� 
GroupStyle
 5L      (  "System.Windows.Controls.GroupStyle  5M         ContainerStyle 5N      �� 5O       �� 
TargetType" ��6$   .�5P   "   ��  �� Property � �� �� Value$ 0,0,0,5q�6;   �� 5Q   "    � �� 5R   &   �� 5S   *    �� 
TargetType" ��6:   .R�5T   .   9�  9� 
IsExpanded . ���#ececec  MaterialDesignExpander#���  6_   $��0,0,0,1q�5U   -   ��5V   2   ]� 5W   6   .+�5X   :   �� $
��Bold"�6D   $��	Helvetica)�5Y   @   $
��19.5(�5Z   @   $��10,0,0,0q�5[   @   ���#1f4247$��
Дата: ��5]   @   �� 5^   :   $
��Bold"�6D   $��	Helvetica)�5_   @   ���#1f4247$
��19.5(�5b   @   ��5c   @   ��  �� Path$
 Name�5d   7   .��5f   2   �� 5g   /   5h   +   5j   #   5k      5m      ��5o      �� 5q      " ��6   .�5r      ��  � ��$ 50��63   �� 5s       � ��$ 	10 0 50 0q�63   �� 5t       � ��$ 15(�65   �� 5u       � �� 5v      �� 5w   "   " ��62   .R�5x   &   �� #��z��6-   #��z��6W   #��z��6�    �� CornerRadius$ 5��6�   ._�5y   *   �  5{   .   �� 5|   2   $	��10* �6C   �� 5}   2   $	��30* �6C   �� 5~   2   $	��20* �6C   �� 5   2   $	��70* �6C   .+�5�   .   �� $��0��64   $��25��6D   $��Right=�6w   $��Center=�6�   ��6O   �� $ Activity.Image�6�   �� 5�   .   $��1��68   $��Center=�6h   $��5,0,0,0q�6�   ��6H   �� *Activity.Title+6�   �� 5�   .   $��2��69   $ 
Horizontal=�6I   .+�5�   2   �� $��Center=�6Z   ��6<   �� $ Amount�6Z   �� 5�   2   $�� рублей��6<   $��Center=�6L   5�   /   �� 5�   .   $��3��68   $
��Left=�6f   $��Center=�6�   ��6I   �� *Description+6�   5�   +   5�   '    �� Triggers 5�   &   P� 5�   *    P� Property �@J�IsMouseOver P� Value . . �5�   .   ��  � ��
 �����6K   �� 5�   .    � ��$ 
17 0 50 0 q�6G   5�   +   P� 5�   *    �@��
IsSelected . . �5�   .   ��  � ��
 �����6K   5�   +   �� 5�   *    �� Value$ False��6�    �� Binding 66   �� $! Activity.ActivityType.Title� �� 	Converter# [  .a�5�   .   ��  � �� �#cce1b76K   5�   +   �� 5�   *   $
 True��6�    66   �� $! Activity.ActivityType.Title�# [  .a�5�   .   ��  � �� �#ffc2b36K   5�   +   5�   #   5�      5�      5�      5�      5�      5�      