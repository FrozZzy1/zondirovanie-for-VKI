   M S B A M L   `   `   `  ����H  DGeophysicsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GeophysicsAppGeophysicsApp  5   	   '    !GeophysicsApp.AddEditPicketWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GeophysicsApp     5   	     � Title$  AddEditPicketWindow��5   	   $	��450��6%   $	��350��62   .��5	      � $��Center=�6   $��Center=�6&    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Координаты��6   $��0��6&   $��0��66   �� 5   
   -   5         ��Name$ listCoordinates��5      $	��100��6+   $��1��67   $��0��6G   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��2��6;   $��Center=�6O   .+�5      �� -   5         ��Name$ 
buttonBack��5      $��
Назад��6)   $��30��69   $��5q�6E   $��	10 0 10 0q�6P   �� 5      -   5        $ 
buttonSave��5      $��Сохранить��6)   $��30��6=   $��5q�6I   $��	10 0 10 0q�6T   5      5      5      