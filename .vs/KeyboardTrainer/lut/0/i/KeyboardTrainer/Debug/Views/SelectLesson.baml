   M S B A M L   `   `   `  ����J  FKeyboardTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MyApp.ToolsMyApp.Tools  5   	   1    +KeyboardTrainer.Views.MainMenu.SelectLesson   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +toolsclr-namespace:MyApp.Tools     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��550��5   	   $	��400��5   	    � WindowStyle$
 None=�5   	    � Title$ SelectLesson��5   	   ��5	   	   ��  �� Source# Z�� �� 	Converter     MyApp.Tools.RatioConverter   �� ConverterParameter$	 0.6����5
   	   �� # Z��   $
 0.25�� � 	Resources 5       �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius ��Name �� Triggers P� Property P� Value��%A  '��       �� 5   
   " ��6   .�5      ��  � ��	 �#3737376+   �� 5       � ��$	 10q�6'   �� 5       � ��
	 �����6+   �� 5       � ��$	 15(�6)   �� 5       �@J�SnapsToDevicePixels	 . 64   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $ 10��6!   #��z��63   ._�5      � .+�5   "   �� $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0,0,0,0q�6�   5      5       5!      P� 5"       �@J�IsMouseOver . . �5#   "   ��  � ��	 �#6a00ff6?   �� 5$   "    � ��
	 �����6?   5%      P� 5'       � �� . . �5(   "   ��  � ��	 �#0050ef6?   �� 5)   "    � ��
	 �����6?   5*      5,      5.      5/      51      .��53      � -   5         �Name$
 grid��53      
������� � RowDefinitions 54   
   �� 55      $��3* �6   �� 56      $	��50* �6   .+�59   
   ��  �� Orientation$ 
Horizontal=�6   .+�5:      �� -   5         ��Name$ btn_back��5:       � Cursor$
 Hand��6&   
���   �$��0q�6G   $	��←��6[   $��20(�6g   $��Center=�6u   $��Arial)�6�   $
��Left=�6�   �� 5;      -   5        $ btn_maximize��5;      $
 Hand��6*   
���   �$��0q�6K   $	��❏��6_   $��17(�6k   $��Center=�6y   $��Arial)�6�   $��Center=�6�   �� 5<      -   5        $ btn_normalize��5<      $
 Hand��6+   
���   �$��0q�6L   $	��▣��6`   $��17(�6l   $��Center=�6z   $��Arial)�6�   $��Right=�6�   5=      �� 5?   
   $��1��6   .��5@      �� -   5         ��Name$ 
stackPanel��5@       �� CanVerticallyScroll . 5B      5C      5D      5F      