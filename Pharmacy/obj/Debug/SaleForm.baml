   M S B A M L   `   `   `  ����  Pharmacy    Pharmacy.Views.SaleForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$'  !Продажа лекарства��5   	   $	��300��6#   $	��400��60    � WindowStartupLocation$ CenterOwner=�6<   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Лекарство:��6   $��0��6%   $��0��62   �� 5   
   $��0��6C   $��1��6P   $��5q�6`   ��6   �� *Package.Medicine.MedicineName+6`   �� 5   
   $��Форма:��6   $��1��6!   $��0��6.   �� 5   
   $��1��6B   $��1��6O   $��5q�6_   ��6   �� *Package.PackageForm.FormName+6_   �� 5   
   $��	Цена:��6   $��2��6    $��0��6-   �� 5   
   $��2��6C   $��1��6P   $��5q�6`   ��6   �� *Package.Price+ �� StringFormat$ C��6`   �� 5   
   $��Количество:��6   $��3��6&   $��0��63   �� 5   
   -   5         ��Name$ QuantityTextBox��5      $��3��6+   $��1��68   $��5q�6H   $��1��6S   �� 5    
   $��Сотрудник:��6   $��4��6%   $��0��62   �� 5!   
   -   5         ��Name$ EmployeeComboBox��5!      $��4��6-   $��1��6:   $��5q�6J    �� DisplayMemberPath$ FullName��5"      �� 5$   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��6��6J   $��2��6W   .+�5%      �� -   5        $��OK��5%      $��80��6"   $��5q�6-   	 �� 	IsDefault	 . 6I   �� 5&      $��Отмена��6   $��80��6&   $��5q�61   
 �� IsCancel
 . 6<   5'      5(      5)      