   M S B A M L   `   `   `  ����  	StocksWPF"    StocksWPF.PriceHistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $	��300��5   %   $	��400��62     � Title  6	   �� *	StockName+.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ priceHistoryDataGrid��5         AutoGenerateColumns$ False��6V      
IsReadOnly$
 True��6r   $
��Auto=�6�   ��61   �� *PriceHistory+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Price��6)      CellTemplate 5      �� 5      .R�5      �� ��5   "   `� 5   &    �� StringFormat$ 
{1} {0:F2}��63   .1�5   *   �� 	 �� Path$	 Price�62   �� 5   *   $	 PriceDirection�62   5   '   ��5   "   �� 5   &   $	 DirectionBrush�6.   5      5      5      0  *System.Windows.Controls.DataGridTextColumn  5      $
 Time��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Time+$ {0:G}��5       5!      5"      