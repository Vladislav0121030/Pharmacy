   M S B A M L   `   `   `  ����  Pharmacy!    Pharmacy.Views.EmployeeForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Сотрудник��5   	   $	��300��6   $	��400��6(    � WindowStartupLocation$ CenterOwner=�64   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Фамилия:��6   $��0��6#   $��0��60   �� 5   
   $��0��6,   $��1��69   $��5q�6I   ��6   �� *
LastName+6I   �� 5   
   $��Имя:��6   $��1��6   $��0��6,   �� 5   
   $��1��6-   $��1��6:   $��5q�6J   ��6   �� *	FirstName+6J   �� 5   
   $��Отчество:��6   $��2��6$   $��0��61   �� 5   
   $��2��6.   $��1��6;   $��5q�6K   ��6   �� *
MiddleName+6K   �� 5   
   $��Адрес:��6   $��3��6!   $��0��6.   �� 5    
   $��3��6+   $��1��68   $��5q�6H   ��6   �� *	Address+6H   �� 5"   
   $ ��Дата рождения:��6   $��4��6)   $��0��66   (  "System.Windows.Controls.DatePicker  5#   
   $��4��68   $��1��6E   $��5q�6U      SelectedDate 6   �� *	BirthDate+6U   �� 5%   
   $��Должность:��6   $��5��6%   $��0��62   �� 5&   
   $��5��6,   $��1��69   $��5q�6I   ��6   �� *
Position+6I   �� 5(   
   $��Оклад:��6   $��6��6!   $��0��6.   �� 5)   
   $��6��6*   $��1��67   $��5q�6G   ��6   �� *Salary+6G   �� 5+   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��8��6J   $��2��6W   .+�5,      �� -   5        $��OK��5,      $��80��6"   $��5q�6-    �� 	IsDefault . 6I   �� 5-      $��Отмена��6   $��80��6&   $��5q�61    �� IsCancel . 6<   5.      5/      50      