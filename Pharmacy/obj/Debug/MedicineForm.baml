   M S B A M L   `   `   `  ����  Pharmacy!    Pharmacy.Views.MedicineForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Лекарство��5   	   $	��500��6   $	��600��6(    � WindowStartupLocation$ CenterOwner=�64   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Название:��6   $��0��6$   $��0��61   �� 5   
   $��0��69   $��1��6F   $��5q�6V   ��6   �� *Medicine.MedicineName+6V   �� 5   
   $��Описание:��6   $��1��6$   $��0��61   �� 5   
   $��1��68   $��1��6E   $��5q�6U   ��6   �� *Medicine.Description+6U   �� 5   
   $��Упаковки:��6   $��2��6$   $��0��61   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ PackagesGrid��5      $��2��6)   $��1��66   $��5q�6F      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   A   ��5      �� *Medicine.Packages+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Форма��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *PackageForm.FormName+6]     5      $	 Цена��6%   $
 * 6]    63   �� *Price+ �� StringFormat$ C��6]     5       $	 Количество��6%   $
 * 6V    69   �� *
Quantity+6V   5"      �� 5$   
   $��Заменители:��6   $��3��6&   $��0��63     5%   
   -   5        $ SubstitutesGrid��5%      $��3��6,   $��1��69   $��5q�6I    .   . $ Single=�5'   A   ��5&      �� *Medicine.Substitutes+ 5(        5)      $	 Название��6%   $
 * 6X    67   �� *MedicineName+6X     5*      $	 Описание��6%   $
 * 6W    67   �� *Description+6W   5,      �� 5.   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��5��6J   $��2��6W   .+�5/      �� -   5        $��OK��5/      $��80��6"   $��5q�6-    �� 	IsDefault . 6I   �� 50      $��Отмена��6   $��80��6&   $��5q�61    �� IsCancel . 6<   51      52      53      