   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.BackSIde   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  BackSIde��5   	   $��339.058��6   $��701.524��6+   ���	#FFE0A9AF � WindowStartupLocation$ CenterScreen=�6�   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $	��268��6@   $��	10,10,0,0q�6M   $	��Top=�6`   $	��673��6x      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Kategory��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+6P     5      $ 
Date Start��6%   $	 150 6    69   �� *	DateStart+ �� ConverterCulture$ ru-Ru��	 �� StringFormat$	 d��6     5      $ Date End��6%   $	 150 6{    67   �� *	DateEnd+$ ru-Ru��$	 d��6{     5      $ Status��6%   $	 150 6P    65   �� *Status+6P   
   	CellStyle
 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5      �� 5       �� Binding 6&   �� *Status+ �� Value 16A   .a�5      ��  �� Property � �� �� Value
 � � �6;   5      �� 5       6&   �� *Status+ 06A   .a�5      ��  � ��
 �  ��6;   5      5      5      �� 5    
   -   5         ��Name$ button��5       $
��Back��6!   $
��Left=�60   $��319,278,0,0q�6K   $	��Top=�6`   $��75��6x   ���	#FFB5D5CA6�   5"      5#      